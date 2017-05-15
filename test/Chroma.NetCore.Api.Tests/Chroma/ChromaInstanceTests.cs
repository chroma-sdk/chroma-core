using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Chroma.NetCore.Api.Chroma;
using Chroma.NetCore.Tests.Base;
using Xunit;

namespace Chroma.NetCore.Api.Tests.Chroma
{
    public class ChromaInstanceTests
    {
        [Fact]
        public async Task<ChromaInstance> Instance_ReturnValidInstance()
        {
            var tests = new ChromaHttpClientTests();
            var client = await tests.Register_ReturnRegisteredClient();
            var instance = new ChromaInstance(client);

            Assert.NotNull(instance);

            return instance;
        }

        [Fact]
        public async Task SetAll_ColorRed()
        {

            var instance = await Instance_ReturnValidInstance();
            
            instance.SetAll(Color.Red);
            var result =  await instance.Send();
            Assert.True(result.Count > 0);
            Assert.All(result,x => Assert.Contains(x,TestBase.VALID_RESULT));

        }

        private void HttpClientOnClientMessage(HttpStatusCode httpStatusCode, string device, string s)
        {
           Console.WriteLine($"{httpStatusCode}:{device}:{s}");
        }
    }
}
