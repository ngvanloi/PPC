﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PropertyManagement.Models;
using System.Data.Entity;

namespace PropertyManagement.Areas.Admin.Controllers
{
    public class FullContractAdminController : Controller
    {
        PPCDBEntities2 model = new PPCDBEntities2();
        // GET: Admin/FullContractAdmin
        public ActionResult Index()
        {
            var fullContract = model.Full_Contract.ToList();
            return View(fullContract);
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
            var fullContract = model.Full_Contract.FirstOrDefault(x => x.ID == id);
            PopularData(fullContract.Property_ID);
            return View(fullContract);
        }

        public ActionResult Print(int id)
        {
            var fullContract = model.Full_Contract.FirstOrDefault(x => x.ID == id);
            if (fullContract != null)
            {
                FullContractPrintModel fc = new FullContractPrintModel();
                fc.Ful_contract_Code = fullContract.Full_Contract_Code;
                fc.Customer_Name = fullContract.Customer_Name;
                fc.Customer_Address = fullContract.Customer_Address;
                fc.Date_of_Contract = fullContract.Date_Of_Contract;
                fc.Deposit = fullContract.Deposit;
                fc.Price = fullContract.Price;
                fc.SSN = fullContract.SSN;
                fc.Mobile = fullContract.Mobile;

                fc.Property_Code = fullContract.Property.Property_Code;
                fc.Address = fullContract.Property.Address;
                return View(fc);
            }
            else
            {
                return View();
            }
            
        }
      


        [HttpPost]
        public ActionResult Create(Full_Contract fullContract)
        {
            if (ModelState.IsValid)
            {
                model.Full_Contract.Add(fullContract);
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
        public ActionResult Edit(Full_Contract p, int id)
        {
            var fullContract = model.Full_Contract.FirstOrDefault(x => x.ID == id);
            fullContract.Customer_Name = p.Customer_Name;
            fullContract.Year_Of_Birth = p.Year_Of_Birth;
            fullContract.SSN = p.SSN;
            fullContract.Customer_Address = p.Customer_Address;
            fullContract.Mobile = p.Mobile;
            fullContract.Property_ID = p.Property_ID;
            fullContract.Date_Of_Contract = p.Date_Of_Contract;
            fullContract.Price = p.Price;
            fullContract.Deposit = p.Deposit;
            fullContract.Remain = p.Remain;
            fullContract.Status = p.Status;

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

        public void PopularData(object PropertyIDSelected = null)
        {

            ViewBag.property_id = new SelectList(model.Properties.ToList(), "ID", "Property_Name", PropertyIDSelected);

        }
    }
}