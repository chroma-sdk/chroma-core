using System.Threading;
using Chroma.NetCore.Api.Chroma;
using Chroma.NetCore.Api.Devices;
using Chroma.NetCore.Api.Extensions;
using Chroma.NetCore.Api.Interfaces;
using Newtonsoft.Json;

namespace Chroma.NetCore.Api.Messages
{
    public class EffectMessage : IHttpRequestMessage
    {
        private string effectId;

        public EffectMessage(string effectId)
        {
            this.effectId = effectId;
        }

        public IDevice Device => new DevNull();
        public Enums.HttpMessageMethod HttpMessageMethod => Enums.HttpMessageMethod.Put;
        public string UrlPath => $"chromasdk/effect";
        public string Message => JsonConvert.SerializeObject(new {id = effectId});
    }
}

