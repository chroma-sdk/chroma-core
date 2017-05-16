using System;
using System.Collections.Generic;
using System.Text;
using Chroma.NetCore.Api.Interfaces;

namespace Chroma.NetCore.Api.Chroma
{
    public class RequestResponse
    {
        public RequestResponse(IDevice device, string response)
        {
            Device = device;
            Response = response;
        }


        public IDevice Device { get;  }
        public string Response { get; }
    }
}
