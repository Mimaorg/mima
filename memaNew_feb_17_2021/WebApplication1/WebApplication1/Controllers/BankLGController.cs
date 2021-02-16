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
                //var data = ddb.Usp_BankGL(startDate, endDate, 1,0).ToList();
                var data = ddb.Usp_BankGL(startDate, endDate, 0, 0).ToList();

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
            //var data = ddb.Usp_APGL(startDate, endDate, 1,0).ToList();
            var data = ddb.Usp_APGL(startDate, endDate, 1, 100).ToList();

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


        public ActionResult market()
        {
            try
            {
                ddb.Usp_Populate_Dev();
                DateTime EDate = DateTime.Now;
                DateTime startDate = new DateTime(2020, 6, 10);
                DateTime endDate = new DateTime(2020, 12, 1);
                var data = ddb.Usp_Market_GL(startDate, endDate, "999","7744", 0).ToList();
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
        public ActionResult projectcost()
        {//'1/1/2020','12/1/2020',18
            ddb.Usp_Populate_Dev();
            DateTime EDate = DateTime.Now;
            DateTime startDate = new DateTime(2020, 1, 1);
            DateTime endDate = new DateTime(2020, 12, 1);
            //var data = ddb.Usp_Project_Cost_GL(startDate, endDate, "All", "25", 0).ToList();
            //var data = ddb.Usp_Project_Cost_GL(startDate, endDate, "All", "25", 90).ToList();
            var data = ddb.Usp_Project_Cost_GL().ToList();
            ViewBag.Paid_To = ddb.Paid_To.ToList();
            ViewBag.banks = ddb.sp_Mima_Finance_Dev_BankList().ToList();
            ViewBag.Category = ddb.Sp_Mima_Finance_Dev_SelectCategory().ToList();
            return View("projectcostsummery", data);
        }
        public ActionResult projectcostDrill1(string porject) {
            var data = ddb.Usp_Project_Cost_GL_Drill1(porject).ToList();
            return PartialView("projectcost_", data);
        }

        public ActionResult projectrevenu()
        {
            ddb.Usp_Populate_Dev();
            DateTime EDate = DateTime.Now;
            DateTime startDate = new DateTime(2020, 6, 1);
            DateTime endDate = new DateTime(2020, 12, 1);
            //var data = ddb.Usp_Project_Rev_GL(startDate, endDate, "All", "25", 0).ToList();
            var data = ddb.Usp_Project_Rev_GL().ToList();
            ViewBag.controll = ddb.Controls.ToList();
            ViewBag.banks = ddb.sp_Mima_Finance_Dev_BankList().ToList();
            ViewBag.Category = ddb.Sp_Mima_Finance_Dev_SelectCategory().ToList();
            return View(data);
        }

        public ActionResult projectrevDrill1(string porject)
        {
            var data = ddb.Usp_Project_Rev_GL_Drill1(porject).ToList();
            return PartialView("projectrevDrill1", data);
        }

        public ActionResult marketsummery() {
            var a = ddb.Usp_Market_Summary().ToList();
         
            return View(a);
        }

        public ActionResult marketsummerydrill1(string vendor)
        {
            var drill1 = ddb.Usp_Market_Summary_Drill1(vendor).ToList();
            return PartialView("marketsummery_drill1", drill1);
        }

        public ActionResult marketsummerydrill2(string vendor, string project)
        {
            var drill2 = ddb.Usp_Market_Summary_Drill2(vendor, project).ToList();
            return PartialView("marketsummery_drill2", drill2);
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

        public ActionResult filterMarketGl(DateTime startDate, DateTime endDate, string contractor , string project , int category) {

            return PartialView("market_", ddb.Usp_Market_GL(startDate, endDate, contractor, project, category).ToList());
        }

        public ActionResult filterProjectCostGl(DateTime startDate, DateTime endDate, string contractor, string project, int category)
        {
            return PartialView("projectcost_", ddb.Usp_Project_Cost_GL().ToList());

            //return PartialView("projectcost_", ddb.Usp_Project_Cost_GL(startDate, endDate, contractor, project, category).ToList());
        }
        public ActionResult filterProjectRevenuGl(DateTime startDate, DateTime endDate, string contractor, string project, int category)
        {

            return PartialView("projectrevenu_", ddb.Usp_Project_Rev_GL().ToList());
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
           
            //if (category == 0)
            //{
            //   var  ToJson = JsonConvert.SerializeObject(ddb.sp_Mima_Finance_Dev_categoryBasedDropdown_All().ToList());
            //    return Json(ToJson, JsonRequestBehavior.AllowGet);
            //}
           // else
            //{
                var ToJson = JsonConvert.SerializeObject(ddb.sp_Mima_Finance_Dev_categoryBasedDropdown(category).ToList());
                return Json(ToJson, JsonRequestBehavior.AllowGet);
            //}

            
        }

        public JsonResult binddropdwonProjVend(DateTime sdate, DateTime edate)
        {


            var ToJson = JsonConvert.SerializeObject(ddb.Usp_Get_Vendors_Par(sdate,edate).ToList());
            return Json(ToJson, JsonRequestBehavior.AllowGet);
            


        }

        public JsonResult bindprojectDropdown(DateTime sdate, DateTime edate, string commaseperatedVender)
        {


            var ToJson = JsonConvert.SerializeObject(ddb.Usp_Get_Projects_Par(sdate, edate, commaseperatedVender).ToList());
            return Json(ToJson, JsonRequestBehavior.AllowGet);



        }
        




    }
}