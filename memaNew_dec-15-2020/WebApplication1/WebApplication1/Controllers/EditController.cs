using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class EditController : Controller
    {
        Mima_Finance_Entities db = new Mima_Finance_Entities();
        Mima_Finance_DevEntities ddb = new Mima_Finance_DevEntities();
        // GET: Edit
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult ReturnDataById(int? id)
        //{
        //    var accountList = db.cashPaymentVouchers.Where(x => x.id == id).ToList();
        //    var accountsList = JsonConvert.SerializeObject(accountList);
        //    // return Json(accountsList, JsonRequestBehavior.AllowGet);
        //    return View();
        //}
        
        public ActionResult CashPaymentVoucherEdit(int? id)
        {
            var data = db.cashPaymentVouchers.Where(x => x.id == id).ToList();
            ViewBag.paidto = db.Paid_to_Details.ToList();
            ViewBag.contorl = db.Control_Details.ToList();
            ViewBag.Data = JsonConvert.SerializeObject(data);
            // ViewBag.category = db.Categories.ToList();
            ViewBag.category = ddb.Sp_Mima_Finance_Dev_SelectCategory().ToList();
            // return Json(accountsList, JsonRequestBehavior.AllowGet);
            //ViewBag.Data = data;
            return View();
           
        }


        public ActionResult CashPaymentVoucherUpdate(cashPaymentVoucher data)
        {
            db.Entry(data).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("CashpendingRecord", "Home");

        }


        public ActionResult CashPaymentVoucherSubmitByID(int ? id) {


            cashPaymentVoucher data = new cashPaymentVoucher();
       
            db.sp_pendingToSubmit(id,"cashPaymentVoucher");


            return RedirectToAction("CashpendingRecord", "Home");

        }


        public ActionResult BankPaymentVoucherSubmitByID(int? id)
        {


            cashPaymentVoucher data = new cashPaymentVoucher();

            db.sp_pendingToSubmit(id, "BankPaymentVoucher");


            return RedirectToAction("pendingRecord", "Home");

        }

        public ActionResult GetDatabyIDBankPaymentVoucher(int ? id) {
            var data = db.bankPaymentVouchers.Where(x => x.id == id).ToList();
            
           // ViewBag.banksList = db.Banks.ToList();
          
            ViewBag.paidTo = db.Paid_to_Details.ToList();
            ViewBag.ControlDetails = db.Control_Details.ToList();
            ViewBag.bank_Details = db.Bank_Details.ToList();
            //ViewBag.category = db.Categories.ToList();
            ViewBag.category = ddb.Sp_Mima_Finance_Dev_SelectCategory().ToList();
            ViewBag.Data = JsonConvert.SerializeObject(data);
            return View();
        }


        public ActionResult BankPaymentVoucherUpdate(bankPaymentVoucher data)
        {
            db.Entry(data).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("pendingRecord", "Home");

        }

        public ActionResult Cancel(int ? id, string table) {

            db.sp_Cancel(id,table);
            if (table != "cashPaymentVoucher")
            {
                return RedirectToAction("pendingRecord", "Home");
            }
            else
            {
                return RedirectToAction("CashpendingRecord", "Home");
            }
                        

           

        }
    }
}