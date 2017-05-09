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
        private Grid Keys { get; }


        private const int ROWS = 6;
        private const int COLUMNS = 22;

        public Keyboard(IClient client) : base(client)
        {
            Grid = new Grid(ROWS, COLUMNS);
            Keys = new Grid(ROWS, COLUMNS);
        }

        public bool SetPosition(int row, int col, Color color)
        {
            return Grid.SetPosition(row, col, color);
        }

        public bool SetKey(List<Key> keys, Color color)
        {
            var result = false;

            foreach (var key in keys)
            {
                result = SetKey(key, color);

                if (!result)
                    return false;
            }

            return result;
        }

        public bool SetKey(Key key, Color color)
        {
            var row = (int)key >> 8;
            var col = (int)key & 0xFF;

            return SetPosition(row, col, color);
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
