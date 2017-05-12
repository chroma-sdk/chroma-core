using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Chroma.NetCore.Api.Interfaces;

namespace Chroma.NetCore.Api.Chroma
{
    public class ChromaInstance : DeviceContainer
    {
        private IClient client;

        public ChromaInstance(IClient client) : base(client)
        {
            this.client = client;
        }

        public  async Task<bool> Destroy()
        {
            var result = await client.UnRegister();

            return Convert.ToInt32(result) == 0;
        }
        
    }
}
