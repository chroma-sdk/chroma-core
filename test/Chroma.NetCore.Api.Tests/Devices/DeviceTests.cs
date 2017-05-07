using System;
using System.Net;
using Chroma.NetCore.Api.Chroma;
using Xunit;

namespace Chroma.NetCore.Api.Tests.Devices
{
    public class DeviceTests
    {
        [Fact]
        public async void SetPosition_SetMousePadDifferentColors()
        {
            var tests = new ChromaHttpClientTests();

            var httpClient = await tests.Register_ReturnRegisteredClient();
            
            httpClient.ClientMessage += HttpClientOnClientMessage;

            var container = new DeviceContainer(httpClient);
            //For FireFly Chroma
            Assert.True(container.Mousepad.SetPosition(0, 0, Color.Orange));
            Assert.True(container.Mousepad.SetPosition(0, 6, Color.Green));
            Assert.True(container.Mousepad.SetPosition(0, 7, Color.Red));
            Assert.True(container.Mousepad.SetPosition(0, 8, Color.Yellow));

            await container.Mousepad.SetDevice();
        }

        [Fact]
        public async void SetPosition_SetMouseDifferentColors()
        {
            var tests = new ChromaHttpClientTests();

            var httpClient = await tests.Register_ReturnRegisteredClient();
            httpClient.ClientMessage += HttpClientOnClientMessage;
            var container = new DeviceContainer(httpClient);
            
            //For DeathAdder Chroma Wheel
            Assert.True(container.Mouse.SetPosition(2, 3, Color.Blue));
            //For DeathAdder Chroma Logo
            Assert.True(container.Mouse.SetPosition(7, 3, Color.Purple));
            await container.Mouse.SetDevice();
        }


        private void HttpClientOnClientMessage(HttpStatusCode httpStatusCode, string device, string s)
        {
           Console.WriteLine($"{httpStatusCode}:{device}:{s}");
        }
    }
}
