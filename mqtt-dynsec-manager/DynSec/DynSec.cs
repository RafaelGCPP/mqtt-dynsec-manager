﻿using GreenDonut;
using mqtt_dynsec_manager.DynSec.Commands;
using mqtt_dynsec_manager.DynSec.Commands.Abstract;
using mqtt_dynsec_manager.DynSec.Commands.Helpers;
using mqtt_dynsec_manager.DynSec.Interfaces;
using mqtt_dynsec_manager.DynSec.Responses.Helpers;
using mqtt_dynsec_manager.Helpers;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Exceptions;
using MQTTnet.Internal;
using MQTTnet.Protocol;
using System.Collections.Concurrent;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace mqtt_dynsec_manager.DynSec
{
    public class DynSec : IDisposable, IDynSec
    {

        readonly IMqttClient client;

        private bool disposedValue;
        private const string commandTopic = "$CONTROL/dynamic-security/v1";
        private const string responseTopic = "$CONTROL/dynamic-security/v1/response";

        public DynSec(IMqttClient mqttClient)
        {
            client = mqttClient;
            client.ApplicationMessageReceivedAsync += HandleApplicationMessageReceivedAsync;

        }
        readonly ConcurrentDictionary<string, AsyncTaskCompletionSource<ResponseList>> _waitingCalls = new();
       
        public ResponseList Teste()
        {

            var cmds = new CommandsList(new List<AbstractCommand>        {
                new ListClients(true),
                new Commands.GetClient("rafael"),
            });

            var result = Task.Run(() => ExecuteAsync(TimeSpan.FromSeconds(10), cmds)).Result;



            result.DumpToConsole();

            return result ;
        }

        
        public async Task<ResponseList> ExecuteAsync(TimeSpan timeout, CommandsList commands)
        {
            using (var timeoutToken = new CancellationTokenSource(timeout))
            {
                try
                {
                    return await ExecuteAsync(commands, timeoutToken.Token).ConfigureAwait(false);
                }
                catch (OperationCanceledException exception)
                {
                    if (timeoutToken.IsCancellationRequested)
                    {
                        throw new MqttCommunicationTimedOutException(exception);
                    }

                    throw;
                }
            }
        }


        public async Task<ResponseList> ExecuteAsync(CommandsList commands, CancellationToken cancellationToken = default)
        {
            try
            {
                var awaitable = new AsyncTaskCompletionSource<ResponseList>();

                if (!_waitingCalls.TryAdd(responseTopic, awaitable))
                {
                    throw new InvalidOperationException();
                }

                var message = new MqttApplicationMessageBuilder()
                    .WithTopic(commandTopic)
                    .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.ExactlyOnce)
                    .WithPayload(commands.AsJSON())
                    .Build();

                var subscribeOptions = new MqttClientSubscribeOptionsBuilder()
                    .WithTopicFilter(responseTopic)
                    .Build();


                await client.SubscribeAsync(subscribeOptions, cancellationToken).ConfigureAwait(false);
                await client.PublishAsync(message, cancellationToken).ConfigureAwait(false);
                using (cancellationToken.Register(
                    () =>
                    {
                        awaitable.TrySetCanceled();
                    }))
                {
                    return await awaitable.Task.ConfigureAwait(false);
                }
            }
            finally
            {
                _waitingCalls.TryRemove(responseTopic, out _);
                await client.UnsubscribeAsync(responseTopic, CancellationToken.None).ConfigureAwait(false);
            }

        }

        Task HandleApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs eventArgs)
        {
            if (!_waitingCalls.TryRemove(eventArgs.ApplicationMessage.Topic, out var awaitable))
            {
                return CompletedTask.Instance;
            }

            var payloadBuffer = eventArgs.ApplicationMessage.PayloadSegment.ToArray();
            var payloadStr= Encoding.UTF8.GetString(payloadBuffer);

            var jsonoptions = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin),
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNameCaseInsensitive = true,
            };

            var data = JsonSerializer.Deserialize<ResponseList>(payloadStr, jsonoptions) ?? new();

            

            awaitable.TrySetResult(data);

            // Set this message to handled to that other code can avoid execution etc.
            eventArgs.IsHandled = true;

            return CompletedTask.Instance;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    client.ApplicationMessageReceivedAsync -= HandleApplicationMessageReceivedAsync;
                }

                disposedValue = true;
            }
        }


        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
