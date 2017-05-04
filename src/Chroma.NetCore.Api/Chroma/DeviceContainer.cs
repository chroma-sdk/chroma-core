using System;
using System.Collections.Generic;
using System.Text;
using Chroma.NetCore.Api.Devices;

namespace Chroma.NetCore.Api.Chroma
{
    public class DeviceContainer
    {
        public Keyboard Keyboard => new Keyboard();
        public Headset Headset => new Headset();

    }
}
