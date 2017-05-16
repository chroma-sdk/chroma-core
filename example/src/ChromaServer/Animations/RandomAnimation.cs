using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chroma.NetCore.Api.Chroma;

namespace ChromaServer.Animations
{
    public class RandomAnimation : Animation
    {
        public override void CreateFrames()
        {
           
            var keys = new List<Key>()
            {
                Key.A,
                Key.S,
                Key.D,
                Key.F
            };


            var keys2 = new List<Key>()
            {
                Key.H,
                Key.J,
                Key.K,
                Key.L
            };

            var fKeys = new List<Key>()
            {
                Key.F1,
                Key.F2,
                Key.F3,
                Key.F4,
                Key.F5,
                Key.F6,
                Key.F7,
                Key.F8,
                Key.F9,
                Key.F10,
                Key.F11,
                Key.F12,
                
            };

            var numberKeys = new List<Key>()
            {
                Key.D1,
                Key.D2,
                Key.D3,
                Key.D4,
                Key.D5,
                Key.D6,
                Key.D7,
                Key.D8,
                Key.D9,
            };

            const int frames = 100;

            for (int f = 0; f < frames; f++)
            {
                var animationFrame = new AnimationFrame(new Random(f).Next(50, 250));

                var rndR = new Random(f + DateTime.Now.Millisecond);
                var rndG = new Random(f + DateTime.Now.Minute);
                var rndB = new Random(f + DateTime.Now.Second);

                if (f == frames - 2)
                {
                    animationFrame.Delay = 1000;
                    animationFrame.Keyboard.SetKey(Key.End, Color.Red);
                    animationFrame.Keyboard.SetDevice();
                    AddFrame();
                    continue;
                }
                
                if (f == frames - 1)
                {
                    animationFrame.Devices.ForEach(x => x.SetNone());
                    AddFrame();
                    continue;
                }

                var color = new Color(rndR.Next(0, 255), rndG.Next(0, 255), rndB.Next(0, 255));

                animationFrame.Keyboard.SetKey(keys, color);

                if (f % 2 == 0)
                    animationFrame.Keyboard.SetKey(keys2,
                        new Color(rndB.Next(0, 255), rndG.Next(0, 255), rndR.Next(0, 255)));

                if (f % 3 == 0)
                {
                    foreach (var fKey in fKeys)
                    {
                        animationFrame.Keyboard.SetKey(fKey,
                            new Color(rndG.Next(0, 255), rndB.Next(0, 255), rndR.Next(0, 255)));
                    }
                }

                if (f % 5 == 0)
                    animationFrame.Keyboard.SetKey(Key.Enter,
                        new Color(rndB.Next(22, 255), rndG.Next(33, 255), rndR.Next(44, 255)));

                var index = f.ToString().Contains("9") ? 0 : (f % 10);

                animationFrame.Keyboard.SetKey(numberKeys[index], new Color(rndG.Next(200, 255), 0, 0));

                animationFrame.Keyboard.SetDevice();

                if (f % 4 == 0)
                    animationFrame.Mouse.SetStatic(new Color(rndB.Next(0, 255),
                        rndG.Next(DateTime.Now.Second, 255), rndR.Next(0, 255)));

                if (f % 2 == 0)
                    animationFrame.Headset.SetStatic(new Color(rndB.Next(f/2, 255),
                        rndG.Next(DateTime.Now.Second, 255), rndR.Next(f, 255)));

                AddFrame();

                void AddFrame()
                {
                    Frames.Add(animationFrame);
                }
            }

            
        }

        public RandomAnimation(ChromaInstance instance) : base(instance)
        {
        }
    }
}
