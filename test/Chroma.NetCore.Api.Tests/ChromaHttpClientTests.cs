using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Chroma.NetCore.Api.Interfaces;
using Chroma.NetCore.Tests.Base;
using Xunit;

namespace Chroma.NetCore.Api.Tests
{
    public class ChromaHttpClientTests
    {
        private readonly string testFilePath;

        private readonly ClientConfiguration clientConfiguration;

        private ChromaHttpClient chromaHttpClient;

        private readonly Uri baseUri = new Uri(Bootsrapper.DebugMode ? "http://localhost.fiddler/" : "http://localhost/");

        public ChromaHttpClientTests()
        {


            testFilePath = Path.Combine(TestBase.AssemblyDirectory, "Files");

            clientConfiguration = new ClientConfiguration()
            {
                BaseAddress = baseUri
            };


            chromaHttpClient = chromaHttpClient ?? new ChromaHttpClient();
            chromaHttpClient.ClientMessage += (code, device, s) => Debug.WriteLine($"{code}:{device}:{s}");
            chromaHttpClient.Init(clientConfiguration);
        }

        [Fact]
        public async void Unregister_ReturnResultString0()
        {

            Assert.NotNull(await Register_ReturnRegisteredClient());

            var response = await chromaHttpClient.UnRegister();

            var resultCode = Convert.ToInt32(response);

            Assert.IsType<int>(resultCode);
            Assert.True(resultCode == 0);
        }


        [Fact]
        public async void Heartbeat_ReturnResultTick()
        {
            Assert.NotNull(await Register_ReturnRegisteredClient());

            var response = await chromaHttpClient.Heartbeat();

            var resultCode = Convert.ToInt32(response);

            Assert.IsType<int>(resultCode);
            Assert.True(resultCode >= 0);
        }


        [Fact]
        public async Task<IClient> Register_ReturnRegisteredClient()
        {
            var initMessage = File.ReadAllText(Path.Combine(testFilePath,"initMessage.json"));

            var response = await chromaHttpClient.Register(initMessage);

            Assert.IsType<int>(Convert.ToInt32(response));

            Debug.WriteLine("SessionId: " + response);

            return chromaHttpClient;
        }



    }
}
