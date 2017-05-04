using System;
using System.Net;
using System.Threading.Tasks;

namespace Chroma.NetCore.Api.Interfaces
{


    public interface IClient
    {
     
        event Action<HttpStatusCode, string, string> ClientMessage;

        ClientConfiguration ClientConfiguration { get; }

        bool Init(ClientConfiguration clientConfiguration);

        Task<string> Register(string jsonMessage);

        Task<string> UnRegister();

        Task<string> Request(IHttpRequestMessage requestMessage);

    }
}
