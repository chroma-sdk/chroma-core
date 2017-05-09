using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Chroma.NetCore.Api.Chroma;
using Chroma.NetCore.Api.Interfaces;

namespace Chroma.NetCore.Api.Devices
{
    public class Keyboard : DeviceBase, IGridDevice
    {
        public override string Device => "keyboard";

        public Grid Grid { get; }
        public Grid Keys { get; }

        private const int ROWS = 22;
        private const int COLUMNS = 6;

        public Keyboard(IClient client) : base(client)
        {
            Grid = new Grid(ROWS, COLUMNS);
            Keys = new Grid(ROWS, COLUMNS);
        }

        public bool SetPosition(int row, int col, Color color)
        {
            return Grid.SetPosition(row, col, color);
        }

        public Task<string> SetDevice()
        {
            var customKeyEffect = new
            {
                color = Grid.ToMatrix(),
                key = Keys.ToMatrix()
            };

          return SetDeviceEffect(Effect.ChromaCustomKey, customKeyEffect);
        }
    }
}
