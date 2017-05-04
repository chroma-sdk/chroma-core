using Chroma.NetCore.Api.Chroma;
using Chroma.NetCore.Api.Extensions;
using Chroma.NetCore.Api.Interfaces;
using Newtonsoft.Json;

namespace Chroma.NetCore.Api.Messages
{
    public class DeviceMessage : IHttpRequestMessage
    {
        private readonly DeviceBase device;
        

        public DeviceMessage(DeviceBase device)
        {
            this.device = device;
        }
        
        public Enums.HttpMessageMethod HttpMessageMethod => Enums.HttpMessageMethod.Put;
        public string UrlPath => $"chromasdk/{device.Device}";
        public string Message => device.EffectData.ToString();


    }
}
