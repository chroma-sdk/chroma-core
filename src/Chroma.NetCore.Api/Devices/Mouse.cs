using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Chroma.NetCore.Api.Chroma;
using Chroma.NetCore.Api.Interfaces;

namespace Chroma.NetCore.Api.Devices
{
    public class Mouse : DeviceBase, IGridDevice
    {
        public override string Device => "mouse";

        public Grid Grid { get; }

        public Mouse(IClient client) : base(client)
        {
            Grid = new Grid(9,7);
        }
        
        public bool SetPosition(int row, int col, Color color)
        {
            return Grid.SetPosition(row, col, color);
        }

        public Task SetDevice()
        {
            return SetDeviceEffect(Effect.ChromaCustom2, this.Grid.ToMatrix());
        }
    }
}
