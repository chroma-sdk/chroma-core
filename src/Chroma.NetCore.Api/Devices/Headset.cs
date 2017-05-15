using System;
using System.Collections.Generic;
using System.Text;
using Chroma.NetCore.Api.Chroma;
using Chroma.NetCore.Api.Interfaces;

namespace Chroma.NetCore.Api.Devices
{
    public class ChromaLink : DeviceBase
    {
        public override string Device => "chromalink";

        public override List<Effect> Supports => new List<Effect>
        {
            Effect.ChromaNone,
            Effect.ChromaCustom,
            Effect.ChromaStatic
        };

    }
}
