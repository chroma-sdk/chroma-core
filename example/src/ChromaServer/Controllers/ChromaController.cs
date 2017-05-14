using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chroma.NetCore.Api.Chroma;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChromaServer.Controllers
{
    public class ChromaController : Controller
    {
        private readonly ChromaApp chromaApp;

        public ChromaController(ChromaApp chromaApp)
        {
            this.chromaApp = chromaApp;

        }

        // GET: Chroma
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Route("/chroma/all/{hexColor}")]
        public async Task<ActionResult> All(string hexColor)
        {
            var instance = await chromaApp.Instance();

            var color = new Color(hexColor);

            instance.SetAll(color);

            return Ok(true);
        }



        [HttpGet]
        [Route("/chroma/static/{device}/{hexColor}")]
        public async Task<ActionResult> Satic(string device, string hexColor)
        {
            var instance = await chromaApp.Instance();

            var color = new Color(hexColor);

            var assignedDevice = instance.Devices.FirstOrDefault(
                x => string.Equals(x.Device, device, StringComparison.CurrentCultureIgnoreCase));

            await assignedDevice.SetStatic(color);

            return Ok(true);
        }

    }
}