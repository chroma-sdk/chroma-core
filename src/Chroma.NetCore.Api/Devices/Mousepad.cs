using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Chroma.NetCore.Api.Chroma;
using Chroma.NetCore.Api.Interfaces;

namespace Chroma.NetCore.Api.Devices
{
    public class Mousepad : DeviceBase, IGridDevice
    {
        public override string Device => "mousepad";

        public Grid Grid { get; }

        public Mousepad(IClient client) : base(client)
        {
            Grid = new Grid(1,15);
        }
    
        public bool SetPosition(int row, int col, Color color)
        {
            return Grid.SetPosition(row, col, color);
        }

        public Task<string> SetDevice()
        {
          return SetDeviceEffect(Effect.ChromaCustom, Grid.ToMatrix()[0]);
        }
    }
}
