using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Chroma.NetCore.Tests.Base;
using Xunit;

namespace Chroma.NetCore.Api.Tests
{
    public class ChromaHttpClientTests
    {
        private readonly string testFilePath;

        private ClientConfiguration clientConfiguration;

        private ChromaHttpClient chromaHttpClient;

        private readonly Uri baseUri = new Uri("http://localhost/");

        public ChromaHttpClientTests()
        {
            testFilePath = Path.Combine(TestBase.AssemblyDirectory, "Files");

            clientConfiguration = new ClientConfiguration()
            {
                BaseAddress = baseUri
            };


            chromaHttpClient = chromaHttpClient ?? new ChromaHttpClient();
            chromaHttpClient.Init(clientConfiguration);
        }

        [Fact]
        public async void Unregister_ReturnResultString0()
        {

            Assert.True(await Register_ReturnSessionId());

            var response = await chromaHttpClient.UnRegister();

            var resultCode = Convert.ToInt32(response);

            Assert.IsType<int>(resultCode);
            Assert.True(resultCode == 0);
        }

        [Fact]
        public async Task<bool> Register_ReturnSessionId()
        {
            var initMessage = File.ReadAllText(Path.Combine(testFilePath,"initMessage.json"));

            var response = await chromaHttpClient.Register(initMessage);

            Assert.IsType<int>(Convert.ToInt32(response));

            Debug.WriteLine("SessionId: " + response);

            return true;
        }


        [Fact]
        public async void Headset_ReturnResultString0()
        {
            Assert.True(await Register_ReturnSessionId());

            var response = await chromaHttpClient.Headset();

            Assert.IsType<int>(Convert.ToInt32(response));
            var resultCode = Convert.ToInt32(response);

            Assert.IsType<int>(resultCode);
            Assert.True(resultCode == 0);
        }



    }
}
