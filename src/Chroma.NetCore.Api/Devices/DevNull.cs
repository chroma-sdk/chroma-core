using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Chroma.NetCore.Api.Chroma;
using Chroma.NetCore.Api.Interfaces;

namespace Chroma.NetCore.Api.Devices
{
    public class DevNull : IDevice
    {
       
        public  string Device => "devnull";
        public List<Effect> Supports { get; }
        public Effect ActiveEffect { get; }
        public string EffectId { get; }
        public dynamic EffectData { get; set; }

        public Task SetStatic(Color color)
        {
            throw new NotImplementedException();
        }

        public Task SetAll(Color color)
        {
            throw new NotImplementedException();
        }

        public Task SetNone()
        {
            throw new NotImplementedException();
        }
    }
}
