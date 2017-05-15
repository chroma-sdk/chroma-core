using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Chroma.NetCore.Api.Chroma;
using Xunit;

namespace Chroma.NetCore.Api.Tests.Chroma
{
    public class DeviceContainerTests
    {
        [Fact]
        public async void SetAll_ColorRed()
        {
            var tests = new ChromaHttpClientTests();

            var httpClient = await tests.Register_ReturnRegisteredClient();
            
            httpClient.ClientMessage += HttpClientOnClientMessage;

            var container = new DeviceContainer();
            container.SetAll(Color.Red);
        }

        private void HttpClientOnClientMessage(HttpStatusCode httpStatusCode, string device, string s)
        {
           Console.WriteLine($"{httpStatusCode}:{device}:{s}");
        }
    }
}
