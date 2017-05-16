using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chroma.NetCore.Api.Devices;
using Chroma.NetCore.Api.Interfaces;
using Newtonsoft.Json;

namespace Chroma.NetCore.Api.Chroma
{
    public class Animation
    {
        public List<AnimationFrame> Frames { get; }
        public bool IsPlaying { get; set; }
        public int CurrentFrame { get; set; }

        public delegate void AnimationStateDelegate(List<IDevice> devices, int currentFrame, List<string> result = null);

        public event AnimationStateDelegate AnimationState = delegate { };

        private ChromaInstance instance;

        private Dictionary<int, List<IDevice>> effects;

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
        /// <returns></returns>
        internal async Task CreateEffects()
        {
            int f = 0;
            effects = new Dictionary<int, List<IDevice>>();
            foreach (var frame in Frames)
            {
                frame.Number = f++;
                var response = await instance.SendDeviceUpdate(frame.Devices, true);

                var devices = new List<IDevice>();

                foreach (var deviceResponse in response)
                {
                    deviceResponse.Device.EffectId = ExtractEffectId(deviceResponse.Response);
                    devices.Add(deviceResponse.Device);
                }

                effects.Add(frame.Number, devices);
            }

            string ExtractEffectId(string jsonResponse)
            {
                var response = JsonConvert.DeserializeObject<dynamic>(jsonResponse);
                return response.id;
            }
        }
        
        public async Task Play(bool playLoop = true)
        {
            if (Frames.Count <= 0)
            {
                IsInit = true;
                CreateFrames();
            }

            IsPlaying = true;
            CurrentFrame = 0;
            await CreateEffects();

            await PlayLoop(playLoop);
        }
        private async Task PlayLoop(bool playLoop)
        {
            int f = 0;
            CurrentFrame = f;

            foreach (var frame in Frames)
            {
                var result = await instance.Send(frame);
                await Task.Delay(frame.Delay);

                if (!IsPlaying)
                {
                    effects = null;
                    break;
                }
                AnimationState(effects[f], f, result.Select(x => x.Response).ToList());
                CurrentFrame = f++;
            }
            if (IsPlaying && playLoop)
                await PlayLoop(true);

            if (!playLoop)
                await Stop();
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
       
    }
}
