using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
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

            return View("AllReporting1");
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

              var maxID =   db.bankPaymentVouchers.Max(x=>x.id).ToString();
              var rcdAgainstmaxID = db.bankPaymentVouchers.Find(Convert.ToInt32(maxID));
                
                if (idList.Count != 0)
                {
                    //var idd = idList.Last();
                    var idd = rcdAgainstmaxID.Vnumber;
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

                var maxID = db.cashPaymentVouchers.Max(x => x.id).ToString();
                var rcdAgainstmaxID = db.cashPaymentVouchers.Find(Convert.ToInt32(maxID));

                if (idList.Count != 0)
                {
                    //var idd = idList.Last();
                    var idd = rcdAgainstmaxID.Vnumber;
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
            data.TaxAmount = Convert.ToInt32(data.TaxAmountWithComma.Replace(",", ""));
            data.Amount = Convert.ToInt32(data.AmountWithComma.Replace(",", ""));
            data.createAT = DateTime.Now;
            data.filterDate = filterDate;
            data.isMultiplecheque = data.chequesArray != null ? true : false;

             db.bankPaymentVouchers.Add(data);
             db.SaveChanges();

            if (data.chequesArray != null )
            {
                //int[] chequearray = data.chequesArray.Split(',').Select(long.Parse).ToArray();
                //int[] amountarray = data.amountArray.Split(',').Select(int.Parse).ToArray();

                string chequenumbers = data.chequesArray;
                string[] chequearray = chequenumbers.Split(new string[] { "," }, StringSplitOptions.None);

                string amount_ = data.amountArray;
                string[] amountArray = amount_.Split(new string[] { "," }, StringSplitOptions.None);

                for (int i = 0; i < chequearray.Length ; i++)
                {
                    multipleCheque multicheqdata = new multipleCheque();
                    multicheqdata.amount = Convert.ToInt32(data.Amount);
                    multicheqdata.mainTableRowID = data.id;
                    multicheqdata.voucher_id = data.Vnumber;
                    multicheqdata.createAt = DateTime.Now;
                    multicheqdata.chequeno = Convert.ToInt32(chequearray[i]);
                    multicheqdata.amount = Convert.ToInt32(amountArray[i]);

                   db.multipleCheques.Add(multicheqdata);
                   db.SaveChanges();
                }



            }



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

            if (Session["UserDetails"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            //   ViewBag.pendingRcd=  db.sp_PendingRecord().ToList();
            // ViewBag.pendingRcd = db.bankPaymentVouchers.Where(x => x.isPending == true).ToList().OrderByDescending(x=>x.Vnumber);

            ViewBag.pendingRcd = db.sp_bankPaymentVoucherList_ORDER_BY_desc().ToList();

            return View();
        }
        

        public ActionResult imgae()
        {
            var img = "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";
            var arr =  Convert.FromBase64String(img);
            return File(arr,"image/png","image.png");
        }


        //Cash payment pending 
        public ActionResult CashpendingRecord()
        {
            if (Session["UserDetails"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            //   ViewBag.pendingRcd=  db.sp_PendingRecord().ToList();
            //ViewBag.pendingRcd = db.cashPaymentVouchers.Where(x => x.isPending == true).ToList();
           //db.sp_CashPaymentVoucherList_ORDER_BY_desc
           ViewBag.pendingRcd = db.sp_CashPaymentVoucherList_ORDER_BY_desc().ToList();
          

            return View();
        }



        public ActionResult uploadimageforbankpaymentvoucher(pendingVoucherChequeImg data) {

            //var a = data.ImageFile.InputStream;
            //string path = @"C:\Documents and Settings\lszk\Moje dokumenty\Moje obrazy\excel.PNG";
            //System.IO.Stream stream = System.IO.File.OpenRead(path);
            //byte[] fileBytes = new byte[stream.Length];
            //int byteCount = stream.Read(fileBytes, 0, (int)stream.Length);
            //string fileContent = Convert.ToBase64String(fileBytes);
            //stream.Close();

            ////frombase64
            //System.IO.MemoryStream str = new System.IO.MemoryStream(fileBytes);

            //return new FileContentResult(str.ToArray(), "type/png") { FileDownloadName = "file.png" };
            var bankpaymentrdc = db.bankPaymentVouchers.Where(x => x.id == data.sqlRowID).ToList();
            var multipchequetable = db.pendingVoucherChequeImgs.Where(x => x.sqlRowID == data.sqlRowID).ToList();
            if (multipchequetable.Count  == 0)
            {
            data.voucherID = bankpaymentrdc[0].Vnumber;
            data.createat = DateTime.Now;
            db.pendingVoucherChequeImgs.Add(data);
            db.SaveChanges();
        }
            
            return RedirectToAction("pendingRecord", "Home");
            
        }

        public JsonResult ApplicationStatus() {
             bool isTestingEnv = Convert.ToBoolean(ConfigurationManager.AppSettings["isTesting"].ToString());
            return Json(isTestingEnv, JsonRequestBehavior.AllowGet);
        }

    }

    public class Banksss {

        public string Banks { get; set; }
    }

}