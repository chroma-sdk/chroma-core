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

        private ChromaInstance instance;

        private bool IsInit;

        public Animation(ChromaInstance instance)
        {
            this.instance = instance;
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
        internal async Task CreateEffects()
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

        public async Task Play()
        {
            if (Frames.Count <=0)
            {
                IsInit = true;
                CreateFrames();
            }

            IsPlaying = true;
            CurrentFrame = 0;
            await CreateEffects();

           await PlayLoop();
        }

        public async Task Stop()
        {
            IsPlaying = false;
            
            var effectIds = new List<string>();

            foreach (var frame in Frames)
            {
                foreach (var frameDevice in frame.Devices)
                {
                    if(String.IsNullOrEmpty(frameDevice.EffectId))
                        continue;

                    effectIds.Add(frameDevice.EffectId);
                }
            }

            await instance.DeleteEffect(effectIds);

        }

        internal async Task PlayLoop()
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
                await PlayLoop();
        }
    }
}
