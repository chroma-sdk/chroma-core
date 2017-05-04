using Chroma.NetCore.Api.Interfaces;

namespace Chroma.NetCore.Api.Messages
{
    class HeartbeatMessage : IHttpRequestMessage
    {
        public Enums.HttpMessageMethod HttpMessageMethod => Enums.HttpMessageMethod.Put;
        public string UrlPath => "chromasdk/heartbeat";
        public string Message => null;
    }
}
