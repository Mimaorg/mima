using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Threading;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class BankLGController : Controller
    {
        // GET: BankLG1

        Mima_Finance_DevEntities ddb = new Mima_Finance_DevEntities();
        Mima_Finance_Entities db = new Mima_Finance_Entities();
        public ActionResult Index()
        {
            try
            {
                DateTime EDate = DateTime.Now;
                DateTime startDate = new DateTime(2020, 6, 10);
                DateTime endDate = new DateTime(2020, 12, 1);
                var data = ddb.Usp_BankGL(startDate, endDate, 1,0).ToList();
                // ViewBag.banks = ddb.Banks.Select(i=> new {i.Bank_Name }).Distinct().ToList();
                //var a = ddb.Accounts.ToList();
                //ViewBag.banks = ddb.Banks.ToList();
                ViewBag.banks = ddb.sp_Mima_Finance_Dev_BankList().ToList();
                ViewBag.Category = ddb.Sp_Mima_Finance_Dev_SelectCategory().ToList();
                return View(data);
            }
            catch (Exception ex)
            {
                throw;
                
            }
          
        }
        public ActionResult Usp_APLG()
        {//'1/1/2020','12/1/2020',18
            DateTime EDate = DateTime.Now;
            DateTime startDate = new DateTime(2020, 1, 1);
            DateTime endDate = new DateTime(2020, 12, 1);
            var data = ddb.Usp_APGL(startDate, endDate, 1,0).ToList();
            ViewBag.Paid_To = ddb.Paid_To.ToList();
            ViewBag.Category = ddb.Sp_Mima_Finance_Dev_SelectCategory().ToList();
            return View(data);
        }
        public ActionResult Usp_ProjectLG()
        {
            DateTime EDate = DateTime.Now;
            DateTime startDate = new DateTime(2020, 6, 1);
            DateTime endDate = new DateTime(2020, 12, 1);
            var data = ddb.Usp_ProjectGL(startDate, endDate, 1,0).ToList();
            ViewBag.controll = ddb.Controls.ToList();
            ViewBag.Category = ddb.Sp_Mima_Finance_Dev_SelectCategory().ToList();
            return View(data);
        }


        public ActionResult FilterData(DateTime startDate,DateTime endDate, int id,string idd, int type , int category) {
           

            if (type == 1)
            {
                return PartialView("Index_", ddb.Usp_BankGL(startDate, endDate, id, category).ToList());
            }
            else if (type == 2)
            {
                return PartialView("Usp_APLG_", ddb.Usp_APGL(startDate, endDate, id, category).ToList());
            }
            else 
            {
                return PartialView("Usp_ProjectLG_Result_", ddb.Usp_ProjectGL(startDate, endDate, id, category).ToList());
            }
           

        }

        public JsonResult spCall() {
           bool status= true;
            Thread.Sleep(2000);
            try
            {
                ddb.Usp_Populate_Dev();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                
            }


            return Json(status, JsonRequestBehavior.AllowGet); 


        }

        public JsonResult categoryBaseDropdown(int category, int type) {
            
         var   ToJson = JsonConvert.SerializeObject(ddb.sp_Mima_Finance_Dev_categoryBasedDropdown(category).ToList());

            return Json(ToJson, JsonRequestBehavior.AllowGet);
        }
    }
}