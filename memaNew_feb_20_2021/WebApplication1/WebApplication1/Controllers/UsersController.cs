using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Content
{
    public class UsersController : Controller
    {
        // GET: Users

        Mima_Finance_Entities db = new Mima_Finance_Entities();
        public ActionResult allUsers()
        {
            if (Session["UserDetails"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(db.Users.ToList());
        }

        public JsonResult getDatabyid(int id)
        {
            var a = db.Users.Find(id);
            var ToJson = JsonConvert.SerializeObject(db.Users.Find(id));
            return Json(ToJson, JsonRequestBehavior.AllowGet);


        }


        public ActionResult addEditUsers(User formdata)
        {
            if (formdata.User_ID == 0)
            {
                db.Users.Add(formdata);
                db.SaveChanges();
            }
            else
            {
                db.Entry(formdata).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }


            return PartialView("userList", db.Users.ToList());

        }

        public JsonResult changepassword(int id , string newpass, string oldpass) {

            var db_result = db.Users.Where(x => x.Password == oldpass && x.User_ID == id).ToList().FirstOrDefault();
            string status = "";
            if (db_result == null)
            {

                status = "old password is not correct.";


            }
            else
            {
                db_result.Password = newpass;
                db.Entry(db_result).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                status = "password changes successfully.";
            }


            //var a = db.Users.Find(id);
            //var ToJson = JsonConvert.SerializeObject(db.Users.Find(id));
            return Json(status , JsonRequestBehavior.AllowGet);


        }
    }
}