using dethicovid.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dethicovid.Controllers
{
    public class DiemcachlyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string InsertKH(Diemcachlymodel cl)
        {

            int count;
            Storectx context = HttpContext.RequestServices.GetService(typeof(Storectx)) as Storectx;
            count = context.Insertcachly(cl);
            if (count > 0)
                return "Insert thành công";
            else
                return "Insert không thành công";
            
        }
        public IActionResult lsdiemcachly()
        {
            Storectx context = HttpContext.RequestServices.GetService(typeof(Storectx)) as Storectx;
            return View(context.sqldiemcachly());
        }

        [HttpPost]
        public IActionResult lscongnhancachly(string macachly)
        {
            Storectx context = HttpContext.RequestServices.GetService(typeof(Storectx)) as Storectx;
            return View(context.lscongnhan(macachly));
        }
    }
}

