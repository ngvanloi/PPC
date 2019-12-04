using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PropertyManagement.Models;

namespace PropertyManagement.Controllers
{
    public class PPCController : Controller
    {
        PPCDBEntities2 db = new PPCDBEntities2();

        // GET: PPC
        [HttpGet]
        public ActionResult Details(int id)
        {
            var property = db.Properties.FirstOrDefault(x => x.ID == id);
            return View(property);
        }
    }
}