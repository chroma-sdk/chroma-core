using Chroma.NetCore.Api.Devices;
using Chroma.NetCore.Api.Interfaces;

namespace Chroma.NetCore.Api.Messages
{
    class HeartbeatMessage : IHttpRequestMessage
    {
        public IDevice Device => new DevNull(); 
        public Enums.HttpMessageMethod HttpMessageMethod => Enums.HttpMessageMethod.Put;
        public string UrlPath => "chromasdk/heartbeat";
        public string Message => null;
    }
}
