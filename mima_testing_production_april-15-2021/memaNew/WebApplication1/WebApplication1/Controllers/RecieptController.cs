﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RecieptController : Controller
    {
        Mima_Finance_Entities db = new Mima_Finance_Entities();
        Mima_Finance_DevEntities ddb = new Mima_Finance_DevEntities();
        // GET: Reciept
        public ActionResult Index()
        {
            //dicarded
            return View();
        }
        public ActionResult Reciept()
        {//dicarded
            return View();

        }


      

        public ActionResult BankReceiptVoucher()
        {
            if (Session["UserDetails"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var id = 0;
            string finalVoucherNum;
            var idList = db.BankReceiptVouchers.Select(x => x.VNumber).ToList();
            var maxID = db.BankReceiptVouchers.Max(x => x.ID).ToString();
            var rcdAgainstmaxID = db.BankReceiptVouchers.Find(Convert.ToInt32(maxID));
            if (idList.Count != 0)
            {
                //var idd = idList.Last();
                var idd = rcdAgainstmaxID.VNumber;
                var iddd = Convert.ToInt16(idd);
                id = iddd + 1;

                finalVoucherNum = Convert.ToString(id);
                ViewBag.vNum = finalVoucherNum;
            }
            else
            {
                finalVoucherNum = Convert.ToString(1);
                ViewBag.vNum = finalVoucherNum;
            }
            ViewBag.bank_Details_ = db.Bank_Details.Select(x => x.Bank).Distinct().ToList();
            ViewBag.bank_Details = db.Bank_Details.ToList();
            ViewBag.ControlDetails = db.Control_Details.ToList();
            ViewBag.category = ddb.Sp_Mima_Finance_Dev_SelectCategory().ToList();
            //ViewBag.category = db.Categories.ToList();
            return View();

        }

        public ActionResult BankRecieptList() {

            if (Session["UserDetails"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View(db.BankReceiptVouchers.ToList());
        }

        [HttpPost]
        public ActionResult AddBankReceiptVoucher(BankReceiptVoucher data) {

            if (data.ID == 0)
            {
                data.Amount = Convert.ToInt32(data.AmountWithComma.Replace(",", ""));
                db.BankReceiptVouchers.Add(data);
            }
            else {
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;

            }
            db.SaveChanges();

            return RedirectToAction("BankReceiptVoucher", "Reciept");
        }

        public ActionResult CashReceiptVoucher() {

            if (Session["UserDetails"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var id = 0;
            string finalVoucherNum;
            var idList = db.CashReceiptVouchers.Select(x => x.VNumber).ToList();
            var maxID = db.CashReceiptVouchers.Max(x => x.ID).ToString();
            var rcdAgainstmaxID = db.CashReceiptVouchers.Find(Convert.ToInt32(maxID));
            if (idList.Count != 0)
            {

                //var idd = idList.Last();
                var idd = rcdAgainstmaxID.VNumber;
                var iddd = Convert.ToInt16(idd);
                id = iddd + 1;

                finalVoucherNum = Convert.ToString(id);
                ViewBag.vNum = finalVoucherNum;
            }
            else
            {
                finalVoucherNum = Convert.ToString(1);
                ViewBag.vNum = finalVoucherNum;
            }
            ViewBag.ControlDetails = db.Control_Details.ToList();
            ViewBag.category = ddb.Sp_Mima_Finance_Dev_SelectCategory().ToList();
           // ViewBag.category = db.Categories.ToList();
            return View();

        }

        public ActionResult CashRecieptList()
        {
            if (Session["UserDetails"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View(db.CashReceiptVouchers.ToList());
        }


        [HttpPost]
        public ActionResult AddCashReceiptVoucher(CashReceiptVoucher data) {

            if (data.ID == 0)
            {
                data.Amount = Convert.ToInt32(data.AmountWithComma.Replace(",", ""));
                db.CashReceiptVouchers.Add(data);
            }
            else {
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;

            }
            db.SaveChanges(); 

            return RedirectToAction("CashReceiptVoucher", "Reciept");
        }
    }
}