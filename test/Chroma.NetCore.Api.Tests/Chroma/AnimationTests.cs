using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Chroma.NetCore.Api.Chroma;
using Xunit;

namespace Chroma.NetCore.Api.Tests.Chroma
{
    public class AnimationTests
    {
        [Fact]
        public async void TestAnimationCreateFrames()
        {
            var tests = new ChromaInstanceTests();
            var instance =  await tests.Instance_ReturnValidInstance();

            var testAnimation = new TestAnimation();
            testAnimation.CreateFrames();
             await testAnimation.Play(instance);
            await Task.Delay(10000);
        }

        private void HttpClientOnClientMessage(HttpStatusCode httpStatusCode, string device, string s)
        {
           Console.WriteLine($"{httpStatusCode}:{device}:{s}");
        }

        
        public class TestAnimation : Animation
        {
            public override void CreateFrames()
            {
                for (var i = 0; i < 255; i += 10)
                {
                    var frame = new AnimationFrame();
                    frame.Keyboard.SetAll(new Color(0, i, 0));
                    this.Frames.Add(frame);
                }
            }
        }

    }
}
