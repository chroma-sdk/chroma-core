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

        [Fact]
        public async void SetPosition_SetKeyboardDifferentColors()
        {
            var tests = new ChromaHttpClientTests();

            var httpClient = await tests.Register_ReturnRegisteredClient();
            httpClient.ClientMessage += HttpClientOnClientMessage;
            var container = new DeviceContainer(httpClient);
            Assert.True(container.Keyboard.SetPosition(1, 2, Color.Yellow));
            Assert.True(container.Keyboard.SetPosition(1, 3, Color.Blue));
            Assert.True(container.Keyboard.SetPosition(1, 4, Color.Green));

            Assert.True(container.Keyboard.SetPosition(2, 3, Color.Red));
            
            var result = await container.Keyboard.SetDevice();

            Assert.True(result.Contains("\"result\":0"));

        }


        private void HttpClientOnClientMessage(HttpStatusCode httpStatusCode, string device, string s)
        {
           Console.WriteLine($"{httpStatusCode}:{device}:{s}");
        }
    }
}
