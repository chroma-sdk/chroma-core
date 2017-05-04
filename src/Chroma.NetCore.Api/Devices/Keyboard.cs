using System;
using System.Collections.Generic;
using System.Text;
using Chroma.NetCore.Api.Chroma;
using Chroma.NetCore.Api.Interfaces;

namespace Chroma.NetCore.Api.Devices
{
    public class Keyboard : DeviceBase
    {
        public override string Device => "keyboard";
    }
}
