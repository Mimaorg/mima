using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        Mima_Finance_Entities db = new Mima_Finance_Entities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(Login data)
        {
            var db_result = db.Users.Where(x => x.User_Name == data.username && x.Password == data.passwordq).ToList().FirstOrDefault();
            //var db_result = db.Logins.Where(x => x.username == data.username && x.passwordq == data.passwordq).ToList().FirstOrDefault();
            if (db_result != null)
            {
                Session["UserDetails"] = db_result.User_ID;
                Session["UserName"] = db_result.User_Name;
                Session["userRole"] = db_result.User_Role;
                Session.Timeout = 60000;
                

                var id = db.Recievables.Select(x => x.id).ToList();
                var id_ = id.Last();
                ViewBag.vNum = id_ + 1;
                ViewBag.company = db.Companies.ToList();
                //ViewBag.Departments = db.Departments.ToList();
                ViewBag.customer = db.Customers.ToList();
                //return Redirect("Home/Index");

                switch (db_result.User_Role)
                {
                    case "Receptionist":
                        return RedirectToAction("UnVerifiedBillsV", "Billing");
                        break;
                    case "Accountant":
                        return RedirectToAction("Index", "Home");
                        break;
                    case "Accounts Head":
                        return RedirectToAction("Index", "Home");
                        break;
                    case "Q.S":
                        return RedirectToAction("Index", "Home");
                        break;
                    case "Executive":
                        return RedirectToAction("Index", "Home");
                        break;
                    case "Procurement":
                        return RedirectToAction("Index", "Home");
                        break;
                    case "Assistant":
                        return RedirectToAction("Index", "Home");
                        break;
                    default:
                        return RedirectToAction("Index", "Home");
                }
             //   return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.error = "UserName or Passoword is wrong.";
                // return RedirectToAction("Index", "Login");
                return View("Index");
            }


        }

        public ActionResult Logout() {

            Session["UserDetails"] = null;
            Session.Abandon();
            return RedirectToAction("Index","Login");


        }
    }
}