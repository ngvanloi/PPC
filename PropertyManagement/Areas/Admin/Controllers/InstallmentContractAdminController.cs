using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PropertyManagement.Models;
using System.Data.Entity;

namespace PropertyManagement.Areas.Admin.Controllers
{
    public class InstallmentContractAdminController : Controller
    {
        PPCDBEntities1 model = new PPCDBEntities1();
        // GET: Admin/InstallmentContract
        public ActionResult Index()
        {
            var installmentContract = model.Installment_Contract.ToList();
            return View(installmentContract);
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
            var installmentContract = model.Installment_Contract.FirstOrDefault(x => x.ID == id);
            PopularData(installmentContract.Property_ID);
            return View(installmentContract);
        }

        [HttpGet]
        public ActionResult Print(int id)
        {
            var installmentContract = model.Installment_Contract.FirstOrDefault(x => x.ID == id);
            return View(installmentContract);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var installmentContract = model.Installment_Contract.FirstOrDefault(x => x.ID == id);
            return View(installmentContract);
        }

       

        [HttpPost]
        public ActionResult Create(Installment_Contract installmentContract)
        {
            if (ModelState.IsValid)
            {
                model.Installment_Contract.Add(installmentContract);
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
        public ActionResult Edit(Installment_Contract p, int id)
        {
            var installmentContract = model.Installment_Contract.FirstOrDefault(x => x.ID == id);
            installmentContract.Customer_Name = p.Customer_Name;
            installmentContract.Year_Of_Birth = p.Year_Of_Birth;
            installmentContract.SSN = p.SSN;
            installmentContract.Customer_Address = p.Customer_Address;
            installmentContract.Mobile = p.Mobile;
            installmentContract.Property_ID = p.Property_ID;
            installmentContract.Date_Of_Contract = p.Date_Of_Contract;
            installmentContract.Installment_Payment_Method= p.Installment_Payment_Method;
            installmentContract.Payment_Period = p.Payment_Period;
            installmentContract.Price = p.Price;
            installmentContract.Deposit = p.Deposit;
            installmentContract.Loan_Amount = p.Loan_Amount;
            installmentContract.Taken = p.Taken;
            installmentContract.Remain = p.Remain;
            installmentContract.Status = p.Status;

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