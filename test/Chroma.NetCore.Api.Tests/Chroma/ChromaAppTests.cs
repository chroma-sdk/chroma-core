using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Chroma.NetCore.Api.Chroma;
using Chroma.NetCore.Tests.Base;
using Xunit;

namespace Chroma.NetCore.Api.Tests.Chroma
{
    public class ChromaAppTests
    {
        [Fact]
        public async void Instance_ReturnValidInstance()
        {
            var app = new ChromaApp(title: "Chroma Test App", description: "App for Tests" );
            var instance = await app.Instance();

            Assert.NotNull(instance);

            instance.SetAll(Color.Red);
            var result = await instance.Send();
            Assert.All(result,x => Assert.Contains(x.Response, TestBase.VALID_RESULT));
        }

        private void HttpClientOnClientMessage(HttpStatusCode httpStatusCode, string device, string s)
        {
           Console.WriteLine($"{httpStatusCode}:{device}:{s}");
        }
    }
}
