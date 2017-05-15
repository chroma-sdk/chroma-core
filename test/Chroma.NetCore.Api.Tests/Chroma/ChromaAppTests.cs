using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Chroma.NetCore.Api.Chroma;
using Xunit;

namespace Chroma.NetCore.Api.Tests.Chroma
{
    public class AnimationTests
    {
        [Fact]
        public async void Instance_ReturnValidInstance()
        {
            var app = new ChromaApp(title: "Chroma Test App", description: "App for Tests" );
            var instance = await app.Instance();

            Assert.NotNull(instance);

        }

        [Fact]
        public async void SendDeviceUpdate_ReturnValidResponseList()
        {
            var app = new ChromaApp(title: "Chroma Test App", description: "App for Tests");
            var instance = await app.Instance();
            

            Assert.NotNull(instance);

        }

        private void HttpClientOnClientMessage(HttpStatusCode httpStatusCode, string device, string s)
        {
           Console.WriteLine($"{httpStatusCode}:{device}:{s}");
        }
    }
}
