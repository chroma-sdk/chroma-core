using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Chroma.NetCore.Api.Chroma;
using Xunit;

namespace Chroma.NetCore.Api.Tests.Chroma
{
    public class ChromaAppTests
    {
        [Fact]
        public async void TestAnimationCreateFrames()
        {
            var testAnimation = new TestAnimation();
            testAnimation.CreateFrames();
         
        }

        private void HttpClientOnClientMessage(HttpStatusCode httpStatusCode, string device, string s)
        {
           Console.WriteLine($"{httpStatusCode}:{device}:{s}");
        }

        
        public class TestAnimation : Animation
        {
            public void CreateFrames()
            {
                for (var i = 0; i < 255; i += 10)
                {
                    var frame = new AnimationFrame();
                    frame.Keyboard.SetAll(new Color(0, i, 0));
                    this.Frames.Push(frame);
                }
            }
        }

    }
}
