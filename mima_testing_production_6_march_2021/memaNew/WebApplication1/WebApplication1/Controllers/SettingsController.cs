using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class SettingsController : Controller
    {
        Mima_Finance_Entities db = new Mima_Finance_Entities();
        Mima_Finance_DevEntities ddb = new Mima_Finance_DevEntities();
        public ActionResult Index()
        {

            if (Session["UserDetails"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(db.Bank_Details.ToList());
        }

 
        public ActionResult _New(int? id)
        {


            return PartialView("_New",db.Bank_Details.Find(id));
        }
        [HttpPost]
        public ActionResult _New(Bank_Details data)
        {
            if (data.Bank_ID > 0)
            {
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
            }
            else {
                db.Bank_Details.Add(data);

            }
            db.SaveChanges();
            return PartialView("_Index",db.Bank_Details.ToList());
        }

        //-----------------

        public ActionResult paidToIndex()
        {
            if (Session["UserDetails"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.category_ = ddb.Sp_Mima_Finance_Dev_SelectCategory().ToList();
            // ViewBag.category_ = db.Categories.ToList(); ;
            return View(db.Paid_to_Details.ToList());
        }
        
        public ActionResult paidTo_New(int? id)
        {
            var data = db.Paid_to_Details.Find(id);
            ViewBag.category = ddb.Sp_Mima_Finance_Dev_SelectCategory().ToList();
            if (id!=0)
            {
                ViewBag.categorySelected = data.category;
            }
            else
            {
                ViewBag.categorySelected = "null";
            }
            
            return PartialView("paidTo_New", data);
        }
        [HttpPost]
        public ActionResult paidTo_New(string nameVender, string category, int id)
        {
            //public ActionResult paidTo_New(Paid_to_Details data)       
            Paid_to_Details data = new Paid_to_Details();
            data.category = category;
            data.Paid_to = nameVender;
            data.Paid_to_ID = id;
            
            if (data.Paid_to_ID > 0)
            {
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                
                db.Paid_to_Details.Add(data);

            }
            db.SaveChanges();
            return PartialView("_paidToIndex", db.Paid_to_Details.ToList());
        }

        //-----------------

        public ActionResult ControlIndex()
        {
            if (Session["UserDetails"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View(db.Control_Details.ToList());
        }

        public ActionResult Controll_New(int? id)
        {

            return PartialView("Controll_New", db.Control_Details.Find(id));
        }
        [HttpPost]
        public ActionResult Control_New(Control_Details data)
        {
            if (data.Control_ID > 0)
            {
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                db.Control_Details.Add(data);

            }
            db.SaveChanges();
            return PartialView("_ControlIndex", db.Control_Details.ToList());
        }










    }
}