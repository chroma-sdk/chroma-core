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
        public Keyboard Keyboard { get; }
        public Headset Headset { get; }
        public Mouse Mouse { get; }
        public Mousepad Mousepad { get; }
        public List<IDevice> Devices { get; }

        public DeviceContainer(IClient client)
        {
            this.client = client;
            Keyboard = new Keyboard(client);
            Headset = new Headset(client);
            Mouse = new Mouse(client);
            Mousepad = new Mousepad(client);

            Devices = new List<IDevice>()
            {
                Keyboard,
                Headset,
                Mouse,
                Mousepad
            };
        }

        
        public void SetAll(Color color)
        {
            Devices.ForEach(x => x.SetAll(color));
        }
    }
}
