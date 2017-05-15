using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Chroma.NetCore.Api.Chroma;
using Chroma.NetCore.Api.Interfaces;

namespace Chroma.NetCore.Api.Devices
{
    public class Keypad : DeviceBase, IGridDevice
    {
        public override string Device => "keypad";

        public Grid Grid { get; }

        public Keypad()
        {
            Grid = new Grid(4,5);
        }
        
        public bool SetPosition(int row, int col, Color color)
        {
            return Grid.SetPosition(row, col, color);
        }

        public bool SetDevice()
        {
            return SetDeviceEffect(Effect.ChromaCustom, this.Grid.ToMatrix());
        }
    }
}
