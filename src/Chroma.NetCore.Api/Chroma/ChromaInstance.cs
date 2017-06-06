using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Chroma.NetCore.Api.Devices;
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
            var result = await client.UnRegister().ConfigureAwait(false);

            var unregistered = Convert.ToInt32(result) == 0;

            if (unregistered)
                DestroyMessage();

            return unregistered;
        }

        public async Task<List<RequestResponse>> Send(DeviceContainer deviceContainer = null)
        {
            container = deviceContainer ?? this;
            var effectIds = new List<string>();
            var devices = new List<IDevice>();
            var responses = new List<RequestResponse>();

            foreach (var device in container.Devices)
            {
                if(device.ActiveEffect == Effect.Undefined)
                    continue;

                if (!string.IsNullOrEmpty(device.EffectId))
                    effectIds.Add(device.EffectId);
                else
                    devices.Add(device);
            }

            responses.AddRange(await SetEffect(effectIds).ConfigureAwait(false));
            responses.AddRange( await SendDeviceUpdate(devices).ConfigureAwait(false));

            return responses;
        }

        internal async Task<List<RequestResponse>> SendDeviceUpdate(List<IDevice> devices, bool store = false)
        {
            var responses = new List<RequestResponse>();

            foreach (var device in devices)
            {
                //ignore devices with no effects
                if(device.EffectData == null)
                    continue;

                IHttpRequestMessage message;

                if(store)
                    message = new DeviceMessage(device);
                else
                    message = new DeviceUpdateMessage(device);

                responses.Add( new RequestResponse(device,await client.Request(message).ConfigureAwait(false)));
            }

            return responses;
        }

        internal async Task<List<string>> DeleteEffect(List<string> effectIds)
        {
            var responses = new List<string>();

            if (effectIds.Count <= 0)
                return responses;

            var message = new EffectMessage(effectIds, true);

            responses.Add(await client.Request(message).ConfigureAwait(false));
            return responses;
        }

        internal async Task<List<RequestResponse>> SetEffect(List<string> effectIds)
        {
            var responses = new List<RequestResponse>();

            if (effectIds.Count <= 0)
                return responses;

            var message = new EffectMessage(effectIds);

            responses.Add(new RequestResponse(message.Device, await client.Request(message).ConfigureAwait(false)));

            return responses;
        }
    }
}
