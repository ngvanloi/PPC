using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using PropertyManagement.Models;
using System.Data.Entity;

namespace PropertyManagement.Areas.Admin.Controllers
{
    public class PropertyAdminController : Controller
    {
        PPCDBEntities1 model = new PPCDBEntities1();
        //
        // GET: /Admin/PropertyAdmin/
        public ActionResult Index()
        {
            var property = model.Properties.ToList();
            return View(property);
        }
        [HttpGet]
        public ActionResult Create()
        {
            PopularData();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var property = model.Properties.FirstOrDefault(x => x.ID == id);
            PopularData(property.Property_Type_ID, property.District_ID, property.Property_Status_ID);
            return View(property);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var property = model.Properties.FirstOrDefault(x => x.ID == id);
            return View(property);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var property = model.Properties.FirstOrDefault(x => x.ID == id);
            return View(property);
        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var property = model.Properties.FirstOrDefault(x => x.ID == id);
            model.Properties.Remove(property);
            model.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(Property property)
        {

            if (ModelState.IsValid)
            {
                //if (file != null && file.ContentLength > 0)
                //{
                //    string filename = Path.GetFileName(file.FileName);
                //    string path = Path.Combine(Server.MapPath("~/images/"), filename);
                //    file.SaveAs(path);
                //}
                //property.Avatar = file.FileName;
                model.Properties.Add(property);
                model.SaveChanges();
                PopularMessage(true);
            }
            else
            {

                PopularMessage(false);

            }
            return RedirectToAction("Index");




        }
        public ActionResult Image(string id)
        {
            var path = Server.MapPath("~/images");
            path = System.IO.Path.Combine(path, id);
            return File(path, "image/*");
        }

        [HttpPost]
        public ActionResult Edit(Property p, int id)
        {
            var property = model.Properties.FirstOrDefault(x => x.ID == id);
            property.Property_Name = p.Property_Name;
            property.Property_Status_ID = p.Property_Status_ID;
            property.Property_Type_ID = p.Property_Type_ID;
            property.Description = p.Description;
            property.District_ID = p.District_ID;
            property.Address = p.Address;
            property.Area = p.Area;
            property.Bed_Room = p.Bed_Room;
            property.Bath_Room = p.Bath_Room;
            property.Price = p.Price;
            property.Installment_Rate = p.Installment_Rate;
            property.Avatar = p.Avatar;
            property.Album = p.Album;


            model.SaveChanges();

            return RedirectToAction("Index");
        }
        public void PopularMessage(bool success)
        {
            if (success)
                Session["success"] = "Successfull!";
            else
                Session["success"] = "Fail!";
        }




        public void PopularData(object propertyTypeSelected = null, object districtSelected = null, object propertyStatusSelected = null)
        {
            ViewBag.Property_Type_ID = new SelectList(model.Property_Type.ToList(), "ID", "Property_Type_Name", propertyTypeSelected);
            ViewBag.District_ID = new SelectList(model.Districts.ToList(), "ID", "District_Name", districtSelected);
            ViewBag.Property_Status_ID = new SelectList(model.Property_Status.ToList(), "ID", "Property_Status_Name", propertyStatusSelected);

        }


    }
}