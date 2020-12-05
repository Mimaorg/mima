using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        Mima_Finance_Entities db = new Mima_Finance_Entities();
        Mima_Finance_DevEntities ddb = new Mima_Finance_DevEntities();
        // GET: Home
        public ActionResult Index()
        {
            if (Session["UserDetails"]==null)
            {
                return RedirectToAction("Index","Login");
            }
            else
            {
                return View();
            }

        }

        public ActionResult AllReporting() {

            return View();
        }

        public ActionResult PaymentRecieving()
        {
            if (Session["UserDetails"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }
        public ActionResult BankCashPayment()
        {
            if (Session["UserDetails"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }

        public ActionResult BankCashReciept()
        {
            if (Session["UserDetails"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }

        public ActionResult CashPayment()
        {
            if (Session["UserDetails"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }
        //[ActionName("BankPaymentVoucher")]
        public ActionResult PaymentForm()
        {
            if (Session["UserDetails"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var id = 0;
                string finalVoucherNum;
                var idList = db.bankPaymentVouchers.Select(x => x.Vnumber).ToList();

                if (idList.Count != 0)
                {
                    var idd = idList.Last();
                    var iddd = Convert.ToInt16(idd);
                     id = iddd + 1;

                    finalVoucherNum = Convert.ToString("000" + id);
                    ViewBag.vNum = finalVoucherNum;
                }
                else
                {
                    finalVoucherNum = Convert.ToString("000" + 1);
                    ViewBag.vNum = finalVoucherNum;
                }

                List<Banksss> Banks = new List<Banksss>();
                Banksss objBank = new Banksss();

                //ViewBag.banksList = JsonConvert.SerializeObject(db.Banks.Select(x => x.Bank1).Distinct().ToArray());
                //ViewBag.banksList = db.Banks.ToList();
                ViewBag.paidTo = db.Paid_to_Details.OrderBy(x=>x.Paid_to).ToList();
                ViewBag.ControlDetails = db.Control_Details.ToList();
                var Bank_ = db.Bank_Details.Select(x => x.Bank).Distinct().ToList();

                ViewBag.bank_Details = db.Bank_Details.ToList();

                ViewBag.bank_Details_ = Bank_;
                //ViewBag.category = db.Categories.ToList();
                ViewBag.category = ddb.Sp_Mima_Finance_Dev_SelectCategory().ToList();
                return View();
            }

           
        }

        public ActionResult cashPaymentVoucher(dynamic data)
        {
            if (Session["UserDetails"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var id = 0;
                string finalVoucherNum;
                var idList = db.cashPaymentVouchers.Select(x => x.Vnumber).ToList();

                if (idList.Count != 0)
                {
                    var idd = idList.Last();
                    var iddd = Convert.ToInt16(idd);
                    id = iddd + 1;

                    finalVoucherNum = Convert.ToString("000" + id);
                    ViewBag.vNum = finalVoucherNum;
                }
                else
                {
                    finalVoucherNum = Convert.ToString("000" + 1);
                    ViewBag.vNum = finalVoucherNum;
                }

                //ViewBag.banksList = JsonConvert.SerializeObject(db.Banks.Select(x => x.Bank1).Distinct().ToArray());
                //ViewBag.banksList = db.Banks.ToList();
                ViewBag.paidto = db.Paid_to_Details.ToList();
                ViewBag.contorl = db.Control_Details.ToList();
                //ViewBag.category = db.Categories.ToList();
                ViewBag.category = ddb.Sp_Mima_Finance_Dev_SelectCategory().ToList();
                return View();
            }


        }
        public ActionResult bankPaymentVoucherSubmit(bankPaymentVoucher data)
        {
            int Account;
            bool result;
            
            data.isPending = data.isPending == true ? true : false;
            result  = int.TryParse(data.Account.ToString(),out Account);

          //  data.Account = result == true ? data.Account : null;

            //db.sp_AddBanks(data.Bank);
            DateTime date = DateTime.Now.Date;
            var filterDate = date.ToString("yyyy-MM-dd");
            data.isCancel = false;
            data.Amount = Convert.ToInt32(data.AmountWithComma.Replace(",", ""));
            data.createAT = DateTime.Now;
            data.filterDate = filterDate;
            db.bankPaymentVouchers.Add(data);
            db.SaveChanges();

            return RedirectToAction("PaymentForm", "Home");
        }
        public ActionResult cashPaymentVoucherSubmit(cashPaymentVoucher data)
        {
            int AccountID;
            bool result;
            data.isPending = data.isPending == true ? true : false;
           
            //db.sp_AddBanks(data.Bank);
            //data.isPending = false;

            DateTime date = DateTime.Now.Date;
            var filterDate = date.ToString("yyyy-MM-dd");
            data.filterDate = filterDate;
            data.isCancel = false;
            data.Amount = Convert.ToInt32(data.AmountWithComma.Replace(",", ""));
            data.createAT = DateTime.Now;
            db.cashPaymentVouchers.Add(data);
            db.SaveChanges();
            
            return RedirectToAction("cashPaymentVoucher", "Home");
        }

        public ActionResult PendingSubmit(cashPaymentVoucher data)
        {

           
            data.isPending = true;
            data.createAT = DateTime.Now;
            db.cashPaymentVouchers.Add(data);
            db.SaveChanges();

            return RedirectToAction("cashPaymentVoucher", "Home");
        }

        public JsonResult AccountsByBankId(string Bank ,string Branck ,string org, string  type)
        {
            var ToJson="";
            if (type == "1")
            {
                ToJson = JsonConvert.SerializeObject(db.Bank_Details.Where(x => x.Bank == Bank).ToList());
            }
            else if (type =="2")
            {
                ToJson = JsonConvert.SerializeObject(db.Bank_Details.Where(x => x.Bank == Bank && x.Branch==Branck).ToList());
            }
            else if (type == "3")
            {
                ToJson = JsonConvert.SerializeObject(db.Bank_Details.Where(x => x.Bank == Bank && x.Branch == Branck &&  x.Org==org).ToList());
            }
            else
            {
                //ToJson = JsonConvert.SerializeObject(db.Bank_Details.Where(x => x.Bank == Bank && x.Branch == Branck && x.Org == org).ToList());
            }
            return Json(ToJson, JsonRequestBehavior.AllowGet);
        }
     //Bank payment pending 
        public ActionResult pendingRecord() {
            //   ViewBag.pendingRcd=  db.sp_PendingRecord().ToList();
            ViewBag.pendingRcd = db.bankPaymentVouchers.Where(x => x.isPending == true).ToList().OrderByDescending(x=>x.Vnumber);
            return View();
        }



        //Cash payment pending 
        public ActionResult CashpendingRecord()
        {
            //   ViewBag.pendingRcd=  db.sp_PendingRecord().ToList();
            ViewBag.pendingRcd = db.cashPaymentVouchers.Where(x => x.isPending == true).ToList();
            return View();
        }





    }

    public class Banksss {

        public string Banks { get; set; }
    }

}