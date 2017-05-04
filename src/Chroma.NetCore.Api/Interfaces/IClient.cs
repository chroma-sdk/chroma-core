using System.Threading.Tasks;

namespace Chroma.NetCore.Api.Interfaces
{
    public interface IClient
    {
        ClientConfiguration ClientConfiguration { get; }

        bool Init(ClientConfiguration clientConfiguration);

        Task<string> Register(string jsonMessage);

        Task<string> UnRegister();

        Task<string> Request(IHttpRequestMessage requestMessage);

    }
}
