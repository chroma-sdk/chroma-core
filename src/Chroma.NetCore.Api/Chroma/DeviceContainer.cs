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

        public Keyboard Keyboard { get; }
        public Headset Headset { get; }
        public Mouse Mouse { get; }
        public Mousepad Mousepad { get; }
        public Keypad Keypad { get; }
        public ChromaLink ChromaLink { get; }

        public List<IDevice> Devices { get; }

        public DeviceContainer()
        {
            Keyboard = new Keyboard();
            Headset = new Headset();
            Mouse = new Mouse();
            Mousepad = new Mousepad();
            Keypad = new Keypad();
            ChromaLink = new ChromaLink();

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
            foreach (var device in Devices)
                device.SetAll(color);
        }
    }
}
