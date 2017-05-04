using System;
using System.Collections.Generic;
using System.Text;
using Chroma.NetCore.Api.Devices;
using Chroma.NetCore.Api.Interfaces;

namespace Chroma.NetCore.Api.Chroma
{
    public class DeviceContainer
    {
        private readonly IClient client;

        public DeviceContainer(IClient client)
        {
            this.client = client;

            Devices = new List<IDevice>()
            {
                Keyboard,
                Headset,
                Mouse
            };
        }

        public Keyboard Keyboard => new Keyboard(client);
        public Headset Headset => new Headset(client);

        public Mouse Mouse => new Mouse(client);

        public List<IDevice> Devices  { get; }
        
        public void SetAll(Color color)
        {
            Devices.ForEach(x => x.SetAll(color));
        }
    }
}
