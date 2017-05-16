using System;
using System.Collections.Generic;
using System.Net;
using Chroma.NetCore.Api.Chroma;
using Chroma.NetCore.Api.Devices;
using Xunit;

namespace Chroma.NetCore.Api.Tests.Devices
{
    public class KeyboardTests
    {
        private const string VALID_RESULT = "\"result\":0";

        [Fact]
        public async void SetKey_ListOfKeys()
        {
            var tests = new ChromaHttpClientTests();

            var httpClient = await tests.Register_ReturnRegisteredClient();
            httpClient.ClientMessage += HttpClientOnClientMessage;
            var keyboard = new Keyboard();

            var keys = new List<Key>()
            {
                Key.R,
                Key.O,
                Key.F,
                Key.L,
            };

            Assert.True(keyboard.SetKey(keys, Color.Red));

            var result = keyboard.SetDevice();

            Assert.True(result);

        }

        [Fact]
        public async void SetKey_SetOneKey()
        {
            var tests = new ChromaHttpClientTests();

            var httpClient = await tests.Register_ReturnRegisteredClient();
            httpClient.ClientMessage += HttpClientOnClientMessage;
            var keyboard = new Keyboard();
            Assert.True(keyboard.SetKey(Key.Enter, Color.Red));

            var result = keyboard.SetDevice();

            Assert.True(result);
        }

        private void HttpClientOnClientMessage(HttpStatusCode httpStatusCode, string device, string s)
        {
           Console.WriteLine($"{httpStatusCode}:{device}:{s}");
        }
    }
}
