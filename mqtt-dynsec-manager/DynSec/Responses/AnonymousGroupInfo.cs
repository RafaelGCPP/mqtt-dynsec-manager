﻿using mqtt_dynsec_manager.DynSec.Model;
using mqtt_dynsec_manager.DynSec.Responses.Abstract;

namespace mqtt_dynsec_manager.DynSec.Responses
{
    public sealed class AnonymousGroupInfo : AbstractResponse
    {

        public AnonymousGroupInfoData? Data { get; set; }
    }

    public sealed class AnonymousGroupInfoData : AbstractResponseData
    {
        public GroupNameClass? Group { get; set; }
    }
}
