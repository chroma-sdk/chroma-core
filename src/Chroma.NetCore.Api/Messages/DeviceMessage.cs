﻿using Chroma.NetCore.Api.Chroma;
using Chroma.NetCore.Api.Extensions;
using Chroma.NetCore.Api.Interfaces;
using Newtonsoft.Json;

namespace Chroma.NetCore.Api.Messages
{
    public class DeviceMessage : IHttpRequestMessage
    {
        public DeviceMessage(IDevice device)
        {
            Device = device;
        }

        public IDevice Device { get; }
        public Enums.HttpMessageMethod HttpMessageMethod => Enums.HttpMessageMethod.Post;
        public string UrlPath => $"chromasdk/{Device.Device}";
        public string Message => Device.EffectData.ToString();
    }
}
