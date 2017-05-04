using System;
using Chroma.NetCore.Api.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Chroma.NetCore.Api.Chroma
{
    [Flags]
    public enum Effect
    {
        [StringValue("CHROMA_UNDEFINED")]
        Undefined = 0,
        [StringValue("CHROMA_NONE")]
        ChromaNone = 1,
        [StringValue("CHROMA_STATIC")]
        ChromaStatic = 2,
        [StringValue("CHROMA_CUSTOM")]
        ChromaCustom = 4,
        [StringValue("CHROMA_CUSTOM2")]
        ChromaCustom2 = 8,
        [StringValue("CHROMA_CUSTOM_KEY")]
        ChromaCustomKey = 16
    }
}
