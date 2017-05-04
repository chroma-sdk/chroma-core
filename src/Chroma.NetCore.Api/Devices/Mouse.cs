using System;
using System.Collections.Generic;
using System.Text;
using Chroma.NetCore.Api.Chroma;
using Chroma.NetCore.Api.Interfaces;

namespace Chroma.NetCore.Api.Devices
{
    public class Mouse : DeviceBase
    {
        public override string Device => "mouse";

        public Mouse(IClient client) : base(client)
        {
        }
    }
}
