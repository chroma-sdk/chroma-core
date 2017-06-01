using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chroma.NetCore.Api.Devices;
using Chroma.NetCore.Api.Interfaces;
using Newtonsoft.Json;

namespace Chroma.NetCore.Api.Chroma
{
    public class ChromaApp
    {
        private ChromaInstance instance;

        private const string DEFAULT_BASE_ADDRESS = "http://localhost:54235";

        internal string jsonAppDefinition;

        public ChromaApp(string jsonAppDefinition)
        {
            this.jsonAppDefinition = jsonAppDefinition;
        }

        public ChromaApp(string title, string description = "", string author = "", string contact = "",
            List<string> devices = null, string category = "application")
        {
            devices = devices ?? new List<string>
            {
                "keyboard",
                "mouse",
                "headset",
                "mousepad",
                "keypad",
                "chromalink"
            };

            var appDefinition = new
            {
                title = title,
                description = description,
                author = new
                {
                    name = author,
                    contact = contact
                },
                device_supported = devices,
                category = category
            };

            this.jsonAppDefinition = JsonConvert.SerializeObject(appDefinition, Formatting.Indented);
        }

        public async Task<ChromaInstance> Instance(string apiBaseAddress = DEFAULT_BASE_ADDRESS)
        {
            if (instance != null)
                return instance;

            var clientConfiguration = new ClientConfiguration()
            {
                BaseAddress = new Uri(apiBaseAddress)
            };

            var client = new ChromaHttpClient();
            client.Init(clientConfiguration);
            await client.Register(jsonAppDefinition);
            await client.Heartbeat();
            instance = new ChromaInstance(client);
            instance.DestroyMessage += () => instance = null;
            
            return instance;
        }

    }
}
