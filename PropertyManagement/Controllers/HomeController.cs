using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PropertyManagement.Models;

namespace PropertyManagement.Controllers
{
    public class HomeController : Controller
    {
        PPCDBEntities1 db = new PPCDBEntities1();
        public ActionResult Index()
        {
            var property = db.Properties.ToList();

            var installment = db.Installment_Contract.ToList();

            var full_Contracts = db.Full_Contract.ToList();
            //var model = [property, installment, full_Contracts];
            return View(property);
        }

        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}