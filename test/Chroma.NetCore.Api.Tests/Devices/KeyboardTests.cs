using System;
using System.Collections.Generic;
using System.Net;
using Chroma.NetCore.Api.Chroma;
using Chroma.NetCore.Api.Devices;
using Chroma.NetCore.Tests.Base;
using Xunit;

namespace Chroma.NetCore.Api.Tests.Devices
{
    public class KeyboardTests : IDisposable
    {
        private ChromaHttpClientTests tests;

        public KeyboardTests()
        {
            tests = new ChromaHttpClientTests();
        }

        public void Dispose()
        {
            tests.Unregister_ReturnResultString0();
        }



        private const string VALID_RESULT = "\"result\":0";

        [Fact]
        [Trait("Category", TraitCategory.UNIT_TEST)]
        public void SetKey_ListOfKeys()
        {
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
        [Trait("Category", TraitCategory.UNIT_TEST)]
        public void SetKey_SetOneKey()
        {

            var keyboard = new Keyboard();
            Assert.True(keyboard.SetKey(Key.Enter, Color.Red));

            var result = keyboard.SetDevice();

            Assert.True(result);
        }
    }
}
