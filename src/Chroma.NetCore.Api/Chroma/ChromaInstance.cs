using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Chroma.NetCore.Api.Interfaces;
using Chroma.NetCore.Api.Messages;

namespace Chroma.NetCore.Api.Chroma
{
    public class ChromaInstance : DeviceContainer
    {
        private readonly IClient client;
        private DeviceContainer container;

        public event Action DestroyMessage = delegate { };

        public ChromaInstance(IClient client)
        {
            this.client = client;
            container = this;
        }

        public  async Task<bool> Destroy()
        {
            var result = await client.UnRegister();

            var unregistered = Convert.ToInt32(result) == 0;

            if (unregistered)
                DestroyMessage();

            return unregistered;
        }

        public async Task<List<string>> Send(DeviceContainer container = null)
        {
            this.container = container ?? this.container;
            var effectIds = new Stack<string>();
            var devices = new Stack<IDevice>();
            var responses = new List<string>();

            foreach (var device in this.Devices)
            {
                if(device.ActiveEffect == Effect.Undefined)
                    continue;

                if (!string.IsNullOrEmpty(device.EffectId))
                    effectIds.Push(device.EffectId);
                else
                    devices.Push(device);
            }

            responses.AddRange(await SetEffect(effectIds));
            responses.AddRange(await SendDeviceUpdate(devices));

            return responses;
        }

        internal async Task<List<string>> SendDeviceUpdate(Stack<IDevice> devices, bool store = false)
        {
            var responses = new List<string>();

            foreach (var device in devices)
            {
                IHttpRequestMessage message;

                if(store)
                    message = new DeviceMessage(device);
                else
                    message = new DeviceUpdateMessage(device);

                responses.Add(await client.Request(message));
            }

            return responses;
        }


        internal async Task<List<string>> SetEffect(Stack<string> effectIds)
        {
            var responses = new List<string>();

            if (effectIds.Count <= 0)
                return responses;

            foreach (var effectId in effectIds)
            {
                var message = new EffectMessage(effectId);

                responses.Add(await client.Request(message));
            }

            return responses;
        }
    }
}
