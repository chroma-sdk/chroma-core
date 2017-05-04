using System;
using Chroma.NetCore.Api.Interfaces;

namespace Chroma.NetCore.Api.Messages
{
    public class UnRegisterMessage : IHttpRequestMessage
    {
        public Enums.HttpMessageMethod HttpMessageMethod => Enums.HttpMessageMethod.Delete;
        public string UrlPath => String.Empty;
        public string Message => null;
    }
}
