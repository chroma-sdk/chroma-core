using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChromaServer.Controllers
{
    public class ChromaController : Controller
    {
        // GET: Chroma
        public ActionResult Index()
        {
            return View();
        }

        // GET: Chroma/Details/5
        public ActionResult Play(int id)
        {
            return Ok(true);
        }

        // GET: Chroma/Create
        public ActionResult Static()
        {
            return Ok(true);
        }

    }

}