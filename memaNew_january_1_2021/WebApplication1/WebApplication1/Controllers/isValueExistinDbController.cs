using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class isValueExistinDbController : Controller
    {
        Mima_Finance_Entities db = new Mima_Finance_Entities();

        // GET: isValueExistinDb
        public JsonResult Index(string type,string Value)
        {
            var result = false;
            if (type == "1")
            {
                var a = db.Paid_to_Details.Where(x => x.Paid_to == Value).ToList().FirstOrDefault();
                result = a == null ? false : true;
            } else if (type =="2") {
                var a = db.Control_Details.Where(x => x.Control == Value).ToList().FirstOrDefault();
                result = a == null ? false : true;

            }
            
           return  Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult isExistBankData( Bank_Details BankformData)
        {
            var result = false;
                var a = db.Bank_Details.Where(x => x.Bank == BankformData.Bank && x.Branch == BankformData.Branch && x.Org == BankformData.Org && x.Account == BankformData.Account).ToList().FirstOrDefault();
                result = a == null ? false : true;

            

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}