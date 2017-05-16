using System;
using System.Collections.Generic;
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
        private readonly List<string> effectIds;

        public EffectMessage(string effectIds)
        {
            HttpMessageMethod = Enums.HttpMessageMethod.Put;
            this.effectIds = new List<string>() {effectIds};
        }
        
        public EffectMessage(List<string> effectIds, bool delete = false)
        {
            HttpMessageMethod = delete ? Enums.HttpMessageMethod.Delete : Enums.HttpMessageMethod.Put;
            this.effectIds = effectIds;
            GenerateEffectMessage();
        }

        private void GenerateEffectMessage()
        {
            var result = JsonConvert.SerializeObject(new { ids = effectIds });

            Message = result;
        }

        public IDevice Device => new DevNull();
        public Enums.HttpMessageMethod HttpMessageMethod { get; }
        public string UrlPath => $"chromasdk/effect";
        public string Message { get; private set; }
    }
}

