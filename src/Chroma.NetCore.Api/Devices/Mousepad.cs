using System;
using System.Collections.Generic;
using System.Text;
using Chroma.NetCore.Api.Chroma;
using Chroma.NetCore.Api.Interfaces;

namespace Chroma.NetCore.Api.Devices
{
    public class Mousepad : DeviceBase
    {
        public override string Device => "mousepad";

        public Mousepad(IClient client) : base(client)
        {
        }
    }
}
