using Chroma.NetCore.Api.Interfaces;

namespace Chroma.NetCore.Api.Messages
{
    class RegisterMessage : IHttpRequestMessage
    {
        private string jsonMessage;

        public RegisterMessage(string jsonMessage)
        {
            this.jsonMessage = jsonMessage;
        }

        public Enums.HttpMessageMethod HttpMessageMethod => Enums.HttpMessageMethod.Post;
        public string UrlPath => "razer/chromasdk";
        public string Message => jsonMessage;
    }
}
