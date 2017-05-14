using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
        public Keypad Keypad { get; }
        public ChromaLink ChromaLink { get; }

        public List<IDevice> Devices { get; }

        public DeviceContainer(IClient client)
        {
            this.client = client;
            Keyboard = new Keyboard(client);
            Headset = new Headset(client);
            Mouse = new Mouse(client);
            Mousepad = new Mousepad(client);
            Keypad = new Keypad(client);
            ChromaLink = new ChromaLink(client);

            Devices = new List<IDevice>()
            {
                Keyboard,
                Headset,
                Mouse,
                Mousepad,
                Keypad,
                ChromaLink
            };
        }

        
        public void SetAll(Color color)
        {
            Devices.ForEach(x => x.SetAll(color));
        }
    }
}
