using mqtt_dynsec_manager.DynSec.Responses.Abstract;
using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace mqtt_dynsec_manager.DynSec.Responses.Helpers
{
    public class ResponseConverter : JsonConverter<AbstractResponse>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(AbstractResponse).IsAssignableFrom(typeToConvert);






        public override AbstractResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            Utf8JsonReader readerClone = reader;

            if (readerClone.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            readerClone.Read();
            if (readerClone.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            string? propertyName = readerClone.GetString();
            if (propertyName != "command")
            {
                throw new JsonException();
            }

            readerClone.Read();
            if (readerClone.TokenType != JsonTokenType.String)
            {
                throw new JsonException();
            }

            string? command = readerClone.GetString();

            AbstractResponse response = command switch
            {
                "listClients" => JsonSerializer.Deserialize<Responses.ClientList>(ref reader, options)!,
                "listGroups" => JsonSerializer.Deserialize<Responses.GroupList>(ref reader, options)!,
                "listRoles" => JsonSerializer.Deserialize<Responses.RoleList>(ref reader, options)!,
                "getDefaultACLAccess" => JsonSerializer.Deserialize<Responses.DefaultACLAccess>(ref reader, options)!,
                "getClient" => JsonSerializer.Deserialize<Responses.ClientInfo>(ref reader, options)!,
                "getGroup" => JsonSerializer.Deserialize<Responses.GroupInfo>(ref reader, options)!,
                _ => JsonSerializer.Deserialize<GeneralResponse>(ref reader, options)!,
            };

            return response;
        }






        public override void Write(Utf8JsonWriter writer, AbstractResponse response, JsonSerializerOptions options)
        {
            var options2 = new JsonSerializerOptions(options)
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };


            switch (response)
            {
                case Responses.ClientList l:
                    JsonSerializer.Serialize<Responses.ClientList>(writer, l, options2);
                    break;
                case Responses.GroupList l:
                    JsonSerializer.Serialize<Responses.GroupList>(writer, l, options2);
                    break;
                case Responses.RoleList l:
                    JsonSerializer.Serialize<Responses.RoleList>(writer, l, options2);
                    break;
                case Responses.DefaultACLAccess d:
                    JsonSerializer.Serialize<Responses.DefaultACLAccess>(writer, d, options2);
                    break;
                case Responses.ClientInfo c:
                    JsonSerializer.Serialize<Responses.ClientInfo>(writer, c, options2);
                    break;
                case Responses.GroupInfo g:
                    JsonSerializer.Serialize<Responses.GroupInfo>(writer, g, options2);
                    break;
                case Responses.Helpers.GeneralResponse g:
                    JsonSerializer.Serialize<Responses.Helpers.GeneralResponse>(writer, g, options2);
                    break;
                default:
                    writer.WriteStartObject();
                    writer.WriteEndObject();
                    break;
            }

        }
    }
}
