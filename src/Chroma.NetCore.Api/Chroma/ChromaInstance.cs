using System;
using System.Collections.Generic;
using System.Text;
using Chroma.NetCore.Api.Interfaces;

namespace Chroma.NetCore.Api.Chroma
{
    public class ChromaInstance : DeviceContainer
    {
        public ChromaInstance(IClient client) : base(client)
        {

        }
    }
}
