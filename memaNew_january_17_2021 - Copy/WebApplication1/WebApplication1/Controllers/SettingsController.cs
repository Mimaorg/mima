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
        
        public ActionResult Index()
        {

            
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


            return View(db.Paid_to_Details.ToList());
        }
        
        public ActionResult paidTo_New(int? id)
        {


            return PartialView("paidTo_New", db.Paid_to_Details.Find(id));
        }
        [HttpPost]
        public ActionResult paidTo_New(Paid_to_Details data)
        {
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