using System;
using System.Collections.Generic;
using System.Text;
using Chroma.NetCore.Api.Chroma;
using Chroma.NetCore.Api.Interfaces;

namespace Chroma.NetCore.Api.Devices
{
    public class Headset : DeviceBase
    {
        public override string Device => "headset";

        public override List<Effect> Supports => new List<Effect>
        {
            Effect.ChromaNone,
            Effect.ChromaCustom,
            Effect.ChromaStatic
        };


    }
}
