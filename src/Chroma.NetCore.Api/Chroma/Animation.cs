using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Chroma.NetCore.Api.Interfaces;

namespace Chroma.NetCore.Api.Chroma
{
    public class Animation
    {
        public Stack<AnimationFrame> Frames { get; }
        public bool IsPlaying { get; set; }
        public int CurrentFrame { get; set; }

        //private ChromaInstance instance;

        private bool IsInit;

        public Animation()
        {
            Frames = new Stack<AnimationFrame>();
        }

        public virtual void CreateFrames()
        {
            for (var i = 0; i < 10; i++)
            {
                var frame = new AnimationFrame();
                frame.Keyboard.SetAll(new Color("ff0000"));
                this.Frames.Push(frame);
            }
        }

        //internal async Task CreateEffects(ChromaInstance instance)
        //{
           
           
        //    var response = await instance.SendDeviceUpdate([device], true);
        //    var keyboardids = response[0];

        //    for (let i = 0; i < keyboardids.length; i++)
        //    {
        //        this.Frames[i].Keyboard.effectId = keyboardids[i].id;
        //    }
        //    return;
        //}


        public async Task Play(ChromaInstance instance)
        {
            if (Frames.Count <=0)
            {
                IsInit = true;
                CreateFrames();
            }

            //this.instance = instance;
            IsPlaying = true;
            CurrentFrame = 0;
            //await CreateEffects(instance);

           await PlayLoop(instance);
        }



        internal async Task PlayLoop(ChromaInstance instance)
        {
            foreach (var frame in Frames)
            {
                 await instance.Send(frame);
                 await Task.Delay(frame.Delay);

                if (!IsPlaying)
                    break;
            }
            if (IsPlaying)
                await PlayLoop(instance);
        }


    }
}
