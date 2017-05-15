using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chroma.NetCore.Api.Interfaces;
using Newtonsoft.Json;

namespace Chroma.NetCore.Api.Chroma
{
    public class Animation
    {
        public List<AnimationFrame> Frames { get; }
        public bool IsPlaying { get; set; }
        public int CurrentFrame { get; set; }

        //private ChromaInstance instance;

        private bool IsInit;

        public Animation()
        {
            Frames = new List<AnimationFrame>();
        }

        public virtual void CreateFrames()
        {
            for (var i = 0; i < 10; i++)
            {
                var frame = new AnimationFrame();
                frame.Keyboard.SetAll(new Color("ff0000"));
                this.Frames.Add(frame);
            }
        }

        /// <summary>
        /// Create a effect for every frame and device
        /// </summary>
        /// <param name="instance">The instance of Chroma</param>
        /// <returns></returns>
        internal async Task CreateEffects(ChromaInstance instance)
        {
         
            foreach (var frame in Frames)
            {
                var response = await instance.SendDeviceUpdate(frame.Devices, true);

                foreach (var deviceResponse in response)
                {
                    deviceResponse.Key.EffectId = ExtractEffectId(deviceResponse.Value);
                }
            }

            string ExtractEffectId(string jsonResponse)
            {
                var response = JsonConvert.DeserializeObject<dynamic>(jsonResponse);
                return response.id;
            }

        }

        public async Task Play(ChromaInstance instance)
        {
            if (Frames.Count <=0)
            {
                IsInit = true;
                CreateFrames();
            }

            IsPlaying = true;
            CurrentFrame = 0;
            await CreateEffects(instance);

           await PlayLoop(instance);
        }

        internal async Task PlayLoop(ChromaInstance instance)
        {
            int f = 0;
            CurrentFrame = f;

            foreach (var frame in Frames)
            {
                 await instance.Send(frame);
                 await Task.Delay(frame.Delay);

                CurrentFrame = f++;

                if (!IsPlaying)
                    break;
            }
            if (IsPlaying)
                await PlayLoop(instance);
        }
    }
}
