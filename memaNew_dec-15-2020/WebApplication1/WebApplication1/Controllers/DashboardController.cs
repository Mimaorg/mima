using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class DashboardController : Controller
    {
        
        Mima_Finance_Entities db = new Mima_Finance_Entities();
        // GET: Dashboard
        //bank dashboard
        public ActionResult Index(bankPaymentVoucher data)
        {
            

            if (Session["UserDetails"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if (data.E_Date!=null && data.S_Date != null)
                {
                    ViewBag.Total_Bank_Details = db.Total_Bank_Details(DateTime.Parse(data.S_Date), DateTime.Parse(data.E_Date), false).ToList();
                    ViewBag.Total_Bank_Pending_Details = db.Total_Bank_Pending_Details(DateTime.Parse(data.S_Date), DateTime.Parse(data.E_Date), true).ToList();
                   
                    ViewBag.Total_Pending_Volume = db.Total_Bank_Volume(DateTime.Parse(data.S_Date), DateTime.Parse(data.E_Date), true).ToArray()[0].ToString();
                    ViewBag.Total_Paid_Volume = db.Total_Bank_Volume(DateTime.Parse(data.S_Date), DateTime.Parse(data.E_Date), false).ToArray()[0].ToString();

                    ViewBag.Total_Bank_Pending_Units = db.Total_Bank_Pending_Units(DateTime.Parse(data.S_Date), DateTime.Parse(data.E_Date), true).ToArray()[0].ToString();
                    ViewBag.Total_Bank_Units = db.Total_Bank_Units(DateTime.Parse(data.S_Date), DateTime.Parse(data.E_Date), false).ToArray()[0].ToString();

                    ViewBag.Bank_Payment_Details_Chart = JsonConvert.SerializeObject(db.Bank_Payment_Details_Chart(DateTime.Parse(data.S_Date), DateTime.Parse(data.E_Date), true).ToList());
                    ViewBag.Controller_Volum_Chart = JsonConvert.SerializeObject(db.Controller_Volum_Chart(DateTime.Parse(data.S_Date), DateTime.Parse(data.E_Date), true).ToList());

                    ViewBag.sumAmount = db.SumOfAmountBilling(DateTime.Parse(data.S_Date), DateTime.Parse(data.E_Date), false).ToArray()[0].ToString();
                    ViewBag.Countbill = db.CountOfBilling(DateTime.Parse(data.S_Date), DateTime.Parse(data.E_Date), false).ToArray()[0].ToString();


                    ViewBag.modalStatus = "openModal";
                    ViewBag.S_date = data.S_Date.ToString();
                    ViewBag.E_date = data.E_Date.ToString();
                }
                else
                {
                    
                    var idList = db.bankPaymentVouchers.ToList();
                    var list = idList.First();
                    DateTime date = DateTime.Now.Date;
                    var day = date.Date.Day;
                    var month = date.Month;
                    var year = date.Year;
                    var todayDate =  string.Format("{0}/{1}/{2}", year, month, day);
                    ViewBag.Total_Bank_Details = db.Total_Bank_Details(DateTime.Parse(list.filterDate), DateTime.Parse(todayDate), false).ToList();
                    ViewBag.Total_Bank_Pending_Details = db.Total_Bank_Pending_Details(DateTime.Parse(list.filterDate), DateTime.Parse(todayDate), true).ToList();

                    ViewBag.Total_Bank_Pending_Units = db.Total_Bank_Pending_Units(DateTime.Parse(list.filterDate), DateTime.Parse(todayDate), true).ToArray()[0].ToString();
                    ViewBag.Total_Pending_Volume = db.Total_Bank_Volume(DateTime.Parse(list.filterDate), DateTime.Parse(todayDate), true).ToArray()[0].ToString();

                    ViewBag.Total_Paid_Volume = db.Total_Bank_Volume(DateTime.Parse(list.filterDate), DateTime.Parse(todayDate), false).ToArray()[0].ToString();
                    ViewBag.Total_Bank_Units = db.Total_Bank_Units(DateTime.Parse(list.filterDate), DateTime.Parse(todayDate), false).ToArray()[0].ToString();

                    ViewBag.Bank_Payment_Details_Chart = JsonConvert.SerializeObject(db.Bank_Payment_Details_Chart(DateTime.Parse(list.filterDate), DateTime.Parse(todayDate), true).ToList());
                    ViewBag.Controller_Volum_Chart = JsonConvert.SerializeObject(db.Controller_Volum_Chart(DateTime.Parse(list.filterDate), DateTime.Parse(todayDate), true).ToList());
                    ViewBag.sumAmount = db.Billings.Sum(s => s.Amount).ToString();
                    ViewBag.Countbill = db.Billings.Count().ToString();

                    ViewBag.Bank_RecieptUnits = db.BankReceiptVouchers.Count().ToString();
                    ViewBag.Bank_RecieptSum = db.BankReceiptVouchers.Sum(s=>s.Amount).ToString();
                    


                    ViewBag.modalStatus = "closeModal";
                    
                }
                
              
                return View();
            }
        }

        //cash dashboard
        public ActionResult CashDashboard(cashPaymentVoucher data)
        {


            if (Session["UserDetails"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if (data.E_Date != null && data.S_Date != null)
                {
                    ViewBag.Total_paid_Volume = db.Total_Cash_Volume(DateTime.Parse(data.S_Date), DateTime.Parse(data.E_Date), false).ToArray()[0].ToString();
                    ViewBag.Total_Pending_Volume = db.Total_Cash_Volume(DateTime.Parse(data.S_Date), DateTime.Parse(data.E_Date), true).ToArray()[0].ToString();

                    ViewBag.Total_paid_Units = db.Total_Cash_Units(DateTime.Parse(data.S_Date), DateTime.Parse(data.E_Date), false).ToArray()[0].ToString();
                    ViewBag.Total_Pending_Units = db.Total_Cash_Units(DateTime.Parse(data.S_Date), DateTime.Parse(data.E_Date), true).ToArray()[0].ToString();

                    ViewBag.Total_Cash_paid_Details = JsonConvert.SerializeObject(db.Total_Cash_Details(DateTime.Parse(data.S_Date), DateTime.Parse(data.E_Date), false).ToList());
                    ViewBag.Total_Cash_pending_Details = JsonConvert.SerializeObject(db.Total_Cash_Details(DateTime.Parse(data.S_Date), DateTime.Parse(data.E_Date), true).ToList());



                    ViewBag.modalStatus = "openModal";
                    ViewBag.S_date = data.S_Date.ToString();
                    ViewBag.E_date = data.E_Date.ToString();
                }
                else
                {

                    var idList = db.cashPaymentVouchers.ToList();
                    var list = idList.First();
                    DateTime date = DateTime.Now.Date;
                    var day = date.Date.Day;
                    var month = date.Month;
                    var year = date.Year;
                    var todayDate = string.Format("{0}/{1}/{2}", year, month, day);


                    ViewBag.Total_paid_Volume = db.Total_Cash_Volume(DateTime.Parse(list.filterDate), DateTime.Parse(todayDate), false).ToArray()[0].ToString();
                    ViewBag.Total_Pending_Volume = db.Total_Cash_Volume(DateTime.Parse(list.filterDate), DateTime.Parse(todayDate), true).ToArray()[0].ToString();

                    ViewBag.Total_paid_Units = db.Total_Cash_Units(DateTime.Parse(list.filterDate), DateTime.Parse(todayDate), false).ToArray()[0].ToString();
                    ViewBag.Total_Pending_Units = db.Total_Cash_Units(DateTime.Parse(list.filterDate), DateTime.Parse(todayDate), true).ToArray()[0].ToString();

                    ViewBag.Total_Cash_paid_Details = db.Total_Cash_Details(DateTime.Parse(list.filterDate), DateTime.Parse(todayDate), false).ToList();
                    ViewBag.Total_Cash_pending_Details =db.Total_Cash_Details(DateTime.Parse(list.filterDate), DateTime.Parse(todayDate), true).ToList();

                    ViewBag.Cash_RecieptUnits = db.CashReceiptVouchers.Count().ToString();
                    ViewBag.Cash_RecieptSum = db.CashReceiptVouchers.Sum(s => s.Amount).ToString();


                    ViewBag.sumAmount = db.Billings.Sum(s => s.Amount).ToString();
                    ViewBag.Countbill = db.Billings.Count().ToString();


                    ViewBag.modalStatus = "closeModal";

                }
                return View();
            }
        }




    }
}