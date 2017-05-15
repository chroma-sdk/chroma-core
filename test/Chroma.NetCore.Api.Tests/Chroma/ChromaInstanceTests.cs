using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Chroma.NetCore.Api.Chroma;
using Chroma.NetCore.Tests.Base;
using Xunit;

namespace Chroma.NetCore.Api.Tests.Chroma
{
    public class ChromaInstanceTests
    {
        [Fact]
        public async void SetAll_ColorRed()
        {
            var tests = new ChromaHttpClientTests();
            var client = await tests.Register_ReturnRegisteredClient();
            
            var instance = new ChromaInstance(client);
            instance.SetAll(Color.Red);
            var result =  await instance.Send();

            Assert.All(result,x => Assert.Contains(x,TestBase.VALID_RESULT));

        }

        private void HttpClientOnClientMessage(HttpStatusCode httpStatusCode, string device, string s)
        {
           Console.WriteLine($"{httpStatusCode}:{device}:{s}");
        }
    }
}
