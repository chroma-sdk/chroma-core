

using System;
using Chroma.NetCore.Api.Interfaces;

namespace Chroma.NetCore.Api

{
    public static class Bootstrapper
    {
        public static bool DebugMode { get; set; }
        
        public static IClient DefaultClient { get; }
        
        static Bootstrapper()

        {
            DebugMode = false;
            
            if (DefaultClient != null)

                return;

            DefaultClient = new ChromaHttpClient();

            var defaultClientConfig = new ClientConfiguration
            {
                BaseAddress = new Uri("http://localhost/")
            };

            DefaultClient.Init(defaultClientConfig);
        }
    }
}

