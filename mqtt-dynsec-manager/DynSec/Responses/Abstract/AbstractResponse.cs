﻿using mqtt_dynsec_manager.DynSec.Converters;
using System.Text.Json.Serialization;

namespace mqtt_dynsec_manager.DynSec.Responses.Abstract
{
    [JsonConverter(typeof(ResponseConverter))]
    public class AbstractResponse

    {
        public string? Command { get; set; }

    }
}
