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


            }
           

            return PartialView("userList",db.Users.ToList());

        }
    }
}