using Chroma.NetCore.Api.Chroma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaFormsApp
{
    internal class ChromaManager
    {

        private ChromaApp chromaApp;

        internal void Init()
        {
            chromaApp = new ChromaApp(title: "Chroma WinForms Test App",
                description: "Chroma Test App for Windows Forms", author: "sdc4");
        }

        internal async Task<List<RequestResponse>> SetColor(Color color)
        {
            var chromaInstance = await chromaApp.Instance().ConfigureAwait(false);
            chromaInstance.SetAll(color);
            return await chromaInstance.Send().ConfigureAwait(false);
        }

        internal async Task<List<RequestResponse>> SetDevice(string device, Color color)
        {
            var chromaInstance = await chromaApp.Instance().ConfigureAwait(false);
            chromaInstance.Devices.ForEach(x=>x.SetNone());
            chromaInstance.Devices.Single(x=>x.Device == device).SetStatic(color);
            return await chromaInstance.Send().ConfigureAwait(false);

        }

        internal async Task<bool> Unregister()
        {
            var chromaInstance = await chromaApp.Instance().ConfigureAwait(false);
            return await chromaInstance.Destroy().ConfigureAwait(false);
        }

    }
}
