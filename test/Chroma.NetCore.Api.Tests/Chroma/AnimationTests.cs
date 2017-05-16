using System;
using System.Linq;
using System.Threading.Tasks;
using Chroma.NetCore.Api.Chroma;
using ChromaServer.Animations;
using Xunit;

namespace Chroma.NetCore.Api.Tests.Chroma
{
    public class AnimationTests
    {
        [Fact]
        public async void TestAnimationCreateFrames()
        {
            var tests = new ChromaInstanceTests();
            var instance = await tests.Instance_ReturnValidInstance();

            var testAnimation = new TestAnimation(instance);
            testAnimation.AnimationState += (devices, frame, result) =>
            {
                Console.WriteLine($"Devices: {string.Join(",", devices)}, Frame: {frame} of {testAnimation.Frames.Count}, Effects: {string.Join(",", devices.Select(x=>x.EffectId))} Result: {string.Join(",", result)}");
            };

            testAnimation.CreateFrames();

            var playTask = testAnimation.Play();
            await Task.Delay(20000);
            await testAnimation.Stop();
        }

        [Fact]
        public async void TestAnimationRandomCreateFrames()
        {
            Bootsrapper.DebugMode = true;
            var tests = new ChromaInstanceTests();
            var instance = await tests.Instance_ReturnValidInstance();

            var testAnimation = new RandomAnimation(instance);
            testAnimation.AnimationState += (devices, frame, result) =>
            {
                Console.WriteLine($"Devices: {string.Join(",", devices)}, Frame: {frame} of {testAnimation.Frames.Count}, Effects: {string.Join(",", devices.Select(x => x.EffectId))} Result: {string.Join(",", result)}");
            };

            testAnimation.CreateFrames();

            await testAnimation.Play(false);
            
        }


        public class TestAnimation : Animation
        {
            public override void CreateFrames()
            {
                for (var i = 0; i < 255; i += 10)
                {
                    var frame = new AnimationFrame();

                    frame.Keyboard.SetAll(new Color(0, i, 0));
                    frame.Mouse.SetStatic(new Color(i,0,100));
                    this.Frames.Add(frame);
                }
            }

            public TestAnimation(ChromaInstance instance) : base(instance)
            {
            }
        }

    }
}
