using Chroma.NetCore.Api.Messages;

namespace Chroma.NetCore.Api.Interfaces
{
    public interface IHttpRequestMessage
    {
        IDevice Device { get; }

        Enums.HttpMessageMethod HttpMessageMethod { get; }
        string UrlPath { get; }

        string Message { get; }

    }
}
