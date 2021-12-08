using dethicovid.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dethicovid.Controllers
{
    public class TrieuchungController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Lietkesolan(int solan)
        {
            Storectx context = HttpContext.RequestServices.GetService(typeof(Storectx)) as Storectx;

            return View(context.lietketrieuchung(solan));
        }
    }
}
