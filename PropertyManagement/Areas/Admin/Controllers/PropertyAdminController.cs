using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PropertyManagement.Models;
using System.Data.Entity;

namespace PropertyManagement.Areas.Admin.Controllers
{
    public class PropertyAdminController : Controller
    {
        PPCDBEntities model = new PPCDBEntities();
        //
        // GET: /Admin/PropertyAdmin/
        public ActionResult Index()
        {
            var property = model.Properties.ToList();
            return View(property);
        }

        public ActionResult Create()
        {
            PopularData();
            return View();
        }

        public ActionResult Edit(int id)
        {
            var property = model.Properties.FirstOrDefault(x => x.ID == id);
            PopularData(property.Property_Type_ID, property.District_ID, property.Property_Status_ID);
            return View(property);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include="Property_Name, Property_Type_ID, Description, District_ID, Address, Area, Bed_Room, Bath_Room, Price, Installment_Rate, Avatar, Album, Property_Status_ID")] Property property)
        {
            if (ModelState.IsValid)
            {
                model.Properties.Add(property);
                model.SaveChanges();
                PopularMessage(true);
            }
            else
            {

                PopularMessage(false);
            }
            return Redirect("index");
           
        }

        [HttpPost]
        public ActionResult Edit(Property model)
        {
            if (ModelState.IsValid)
            {
                model.Entry(model).State = EntityState.Modified;
                model.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public void PopularMessage(bool success)
        {
            if (success)
                Session["success"] = "Successfull!";
            else
                Session["success"] = "Fail!";
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Property_Name, Property_Type_ID, Description, District_ID, Address, Area, Bed_Room, Bath_Room, Price, Installment_Rate, Avatar, Album, Property_Status_ID")] Property property)
        {

            model.Properties.Add(property);
            model.SaveChanges();
            return Redirect("index");
        }


        public void PopularData(object propertyTypeSelected = null, object districtSelected = null, object propertyStatusSelected = null)
        {
            ViewBag.Property_Type_ID = new SelectList(model.Property_Type.ToList(), "ID", "Property_Type_Name", propertyTypeSelected);
            ViewBag.District_ID = new SelectList(model.Districts.ToList(), "ID", "District_Name", districtSelected);
            ViewBag.Property_Status_ID = new SelectList(model.Property_Status.ToList(), "ID", "Property_Status_Name", propertyStatusSelected);

        }

       
	}
}