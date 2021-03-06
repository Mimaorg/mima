using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.mima_img_processing;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebApplication1.Controllers
{
    public class BillingController : Controller
    {
        // GET: Billing
        Mima_Finance_Entities db = new Mima_Finance_Entities();
        Mima_Finance_DevEntities ddb = new Mima_Finance_DevEntities();
        BillimgUpload img = new BillimgUpload();
        //string cstring = ConfigurationManager.ConnectionStrings["Mima_Finance_Entities"].ConnectionString;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult vBilling()
        {
            if (Session["UserDetails"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            //return View(db.Billings.ToList().OrderByDescending(x => x.createAt));

            //ViewBag.banklist = db.sp_BillingsList_ORDER_BY_desc().ToList();

            return View(db.sp_BillingsList_ORDER_BY_desc().ToList()); 
        }

        public ActionResult Add(int? id)
        {

            if (id == 0)
            {
                ViewBag.isAutoId = true;
                var id_ = 0;
                string finalVoucherNum;
                var idList = db.Billings.Select(x => x.Bill_id).ToList();

                if (idList.Count != 0)
                {
                    var idd = idList.Last();
                    var iddd = Convert.ToInt16(idd);
                    id_ = iddd + 1;

                    finalVoucherNum = Convert.ToString("000" + id_);
                    ViewBag.vNum = finalVoucherNum;
                }
                else
                {
                    finalVoucherNum = Convert.ToString("000" + 1);
                    ViewBag.vNum = finalVoucherNum;
                }
            }
            else
            {
                ViewBag.isAutoId = false;
            }

            ViewBag.control = db.Control_Details.ToList();
            ViewBag.paidTo = db.Paid_to_Details.ToList();
            ViewBag.category = ddb.Sp_Mima_Finance_Dev_SelectCategory().ToList();
            //ViewBag.Category = db.Categories.ToList();
            var dataa = db.Billings.Find(id);
            if (id != 0)
            {
                dataa.amountWithComma = string.Format("{0:#,0}", (dataa.Amount == null ? 0 : dataa.Amount));
            }

            return PartialView("Add", dataa);
        }

        [HttpPost]
        public ActionResult Add(Billing data)
        {


            if (data.id == 0)
            {
                string computer_name = Path.GetFileNameWithoutExtension(data.ImageFile.FileName);// file name before save. 


                string extension = Path.GetExtension(data.ImageFile.FileName);
                var name1 = DateTime.Now.ToString("yymmssfff") + extension;

                var name2 = name1;
                var fileSize = data.ImageFile.ContentLength;
                string fileType = data.ImageFile.ContentType;

                Stream a = data.ImageFile.InputStream;
                System.Drawing.Image image = System.Drawing.Image.FromStream(a);
                int height = image.Height;
                int width = image.Width;

                string folder = "Image";

                string fileName = Path.Combine(Server.MapPath(folder), name1);

                string isFolder_exist = Path.Combine(Server.MapPath(folder));

                bool isexist = Directory.Exists(isFolder_exist);
                if (!isexist)
                {
                    Directory.CreateDirectory(isFolder_exist);
                }

          
                  var unverifiedDataByID = db.Billing_UnVerified.Where(x=>x.id == data.unVerifedbillSQLid).ToList();

                data.unVerifiedBill_id = unverifiedDataByID[0].Bill_id;
                data.ImageFile.SaveAs(fileName);
                ModelState.Clear();
                data.imgPath = name2;
                data.createAt = DateTime.Now;
                data.isCancell = false;
                data.isPending = false;
                data.Amount = Convert.ToInt32(data.amountWithComma.Replace(",", ""));
                db.Billings.Add(data);

                unverifiedDataByID[0].isMove = true;
                //db.Billing_UnVerified.Add(unverifiedDataByID[0]);
                db.Entry(unverifiedDataByID[0]).State = System.Data.Entity.EntityState.Modified;
            }
            else {
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;

            }
            db.SaveChanges();
            return RedirectToAction("vBilling", "Billing");
            //return PartialView("_vBilling", db.Billings.ToList());
        }

        //-----------------//

        public ActionResult UnVerifiedBillsV() {

            if (Session["UserDetails"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            //db.Billing_UnVerified.Where(x=>x.isMove == false).ToList();
            //return View(db.Billing_UnVerified.ToList().OrderByDescending(x=>x.createAt));
            return View(db.sp_BillingsUVList_ORDER_BY_desc().ToList());
        }
        public ActionResult AddUnV(int? id) {

            //var efConnectionString = cstring;
            //var builder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(efConnectionString);
            //var regularConnectionString = builder.ProviderConnectionString;


            //string SQL = "sp_id_generater_for_Billing_UnVerified";
            //SqlConnection con = new SqlConnection(regularConnectionString);
            //SqlCommand cmd = new SqlCommand(SQL, con);
            //cmd.CommandType = CommandType.StoredProcedure;

            //con.Open();
            //SqlDataReader d ;
            //d = cmd.ExecuteReader();

            //con.Close();

            if (id == 0)
            {
                ViewBag.isAutoId = true;
                var id_ = 0;
                string finalVoucherNum;
                var idList = db.Billing_UnVerified.Select(x => x.Bill_id).ToList();
                var idList1 = idList.Select(x => Convert.ToInt32(x)).ToList();
                var mxiBilling_uv_id = idList1.Max();

                //var maxID = db.Billing_UnVerified.Max(x => x.id).ToString();
                //var rcdAgainstmaxID = db.Billing_UnVerified.Find(Convert.ToInt32(maxID));
                //var rcdAgainstmaxID = db.sp_id_generater_for_Billing_UnVerified();
                if (idList.Count != 0)
                {
                    //var idd = idList.Last();
                    //var idd = mxiBilling_uv_id;
                    //var iddd = Convert.ToInt32(idd);
                    int iddd = mxiBilling_uv_id;
                    id_ = iddd + 1;

                    finalVoucherNum = Convert.ToString("000" + id_);
                    ViewBag.vNum = finalVoucherNum;
                }
                else
                {
                    finalVoucherNum = Convert.ToString("000" + 1);
                    ViewBag.vNum = finalVoucherNum;
                }
            }
            else
            {
                ViewBag.isAutoId = false;
            }

            ViewBag.control = db.Control_Details.ToList();
            ViewBag.paidTo = db.Paid_to_Details.ToList();
            ViewBag.category = ddb.Sp_Mima_Finance_Dev_SelectCategory().ToList();
            //ViewBag.Category = db.Categories.ToList();
            //var iddddd = db.Billings.Select(x => x.Bill_id).ToList();//for verify bills.
            //var a = iddddd.Last();
            // ViewBag.verifyBillId = a.ToString();
            // var maxIDforBill = db. Billings.Max(x => x.id).ToString();
            //var rcdAgainstmaxIDforbill = db.Billings.Find(Convert.ToInt32(maxIDforBill));

            var idList_forBilling = db.Billings.Select(x => x.Bill_id).ToList();
            var idList1_for_Billig = idList_forBilling.Select(x => Convert.ToInt32(x)).ToList();
            var mxiBilling_Verif_id = idList1_for_Billig.Max();
           

            ViewBag.verifyBillId = mxiBilling_Verif_id;
            var dataa = db.Billing_UnVerified.Find(id);

            if (id != 0)
            {
                dataa.amountWithComma = string.Format("{0:#,0}", (dataa.Amount == null ? 0 : dataa.Amount));
            }

            return PartialView("AddUnV", dataa);
        }

        [HttpPost]
        public ActionResult AddUnV(Billing_UnVerified data)
        {
            if (data.id == 0)
            {
               
                string computer_name = Path.GetFileNameWithoutExtension(data.ImageFile.FileName);// file name before save. 


                string extension = Path.GetExtension(data.ImageFile.FileName);
                var name1 = DateTime.Now.ToString("yymmssfff") + extension;

                var name2 = name1;
                var fileSize = data.ImageFile.ContentLength;
                string fileType = data.ImageFile.ContentType;

                Stream a = data.ImageFile.InputStream;
                System.Drawing.Image image = System.Drawing.Image.FromStream(a);
                int height = image.Height;
                int width = image.Width;

                string folder = "Image";
              
                string fileName = Path.Combine(Server.MapPath(folder), name1);
                
                string isFolder_exist = Path.Combine(Server.MapPath(folder));

                bool isexist = Directory.Exists(isFolder_exist);
                if (!isexist)
                {
                    Directory.CreateDirectory(isFolder_exist);
                }

                data.ImageFile.SaveAs(fileName);
                ModelState.Clear();
                data.imgPath = name2;
                data.createAt = DateTime.Now;
                data.isCancell = false;
                data.isPending = false;
                data.isMove = false;
                data.Amount = Convert.ToInt32(data.amountWithComma.Replace(",", ""));
                db.Billing_UnVerified.Add(data);
            }
            else
            {
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;

            }
            db.SaveChanges();
            return RedirectToAction("UnVerifiedBillsV", "Billing");

            //return PartialView("_vBilling", db.Billings.ToList());
        }



        public ActionResult jvafter() {

            return View("jvafter");
        }





        public ActionResult projectBills() {

            if (Session["UserDetails"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            //return View(db.Billings.Where(x=>x.isProjectbill == true).ToList());
            return View(db.sp_Billing_Project_List_ORDER_BY_desc().ToList());
        }
        
        public ActionResult AddProjectBill(int? id)
        {

            if (id == 0)
            {
                ViewBag.isAutoId = true;
                var id_ = 0;
                string finalVoucherNum;
                 var idList = db.Billings.Where(c=>c.isProjectbill == true).Select(x => x.id).ToList();
               // var idList = db.Billings.ToList();
                if (idList.Count != 0)
                {
                    var idd = idList.Last();
                    var iddd = Convert.ToInt16(idd);
                    id_ = iddd + 1;

                    finalVoucherNum = Convert.ToString("000" + id_);
                    ViewBag.vNum = finalVoucherNum;
                }
                else
                {
                    finalVoucherNum = Convert.ToString("000" + 1);
                    ViewBag.vNum = finalVoucherNum;
                }
            }
            else
            {
                ViewBag.isAutoId = false;
            }

            ViewBag.control = db.Control_Details.ToList();
            ViewBag.paidTo = db.Paid_to_Details.ToList();
            ViewBag.category = ddb.Sp_Mima_Finance_Dev_SelectCategory().ToList();
            //ViewBag.Category = db.Categories.ToList();
            var iddddd = db.Billings.Select(x => x.Bill_id).ToList();//for verify bills.
            var a = iddddd.Last();
            ViewBag.verifyBillId = a.ToString();
            var dataa = db.Billings.Find(id);

            if (id != 0)
            {
                dataa.amountWithComma = string.Format("{0:#,0}", (dataa.Amount == null ? 0 : dataa.Amount));
            }

            return PartialView("AddprojectBills", dataa);
        }

        [HttpPost]
        public ActionResult AddProjectBill(Billing data)
        {


            if (data.id == 0)
            {
                string computer_name = Path.GetFileNameWithoutExtension(data.ImageFile.FileName);// file name before save. 


                string extension = Path.GetExtension(data.ImageFile.FileName);
                var name1 = DateTime.Now.ToString("yymmssfff") + extension;

                var name2 = name1;
                var fileSize = data.ImageFile.ContentLength;
                string fileType = data.ImageFile.ContentType;

                Stream a = data.ImageFile.InputStream;
                System.Drawing.Image image = System.Drawing.Image.FromStream(a);
                int height = image.Height;
                int width = image.Width;

                string folder = "Image";

                string fileName = Path.Combine(Server.MapPath(folder), name1);

                string isFolder_exist = Path.Combine(Server.MapPath(folder));

                bool isexist = Directory.Exists(isFolder_exist);
                if (!isexist)
                {
                    Directory.CreateDirectory(isFolder_exist);
                }

                data.ImageFile.SaveAs(fileName);
                ModelState.Clear();
                data.imgPath = name2;
                data.createAt = DateTime.Now;
                data.isCancell = false;
                data.isPending = false;
                data.isProjectbill = true;
                data.Amount = Convert.ToInt32(data.amountWithComma.Replace(",", ""));
                db.Billings.Add(data);
            }
            else
            {
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;

            }
            db.SaveChanges();
            return RedirectToAction("projectBills", "Billing");

            //return PartialView("_vBilling", db.Billings.ToList());
        }


        public ActionResult unverifiedprojectBills() {

            if (Session["UserDetails"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            //return View(db.UnVerified_project_bills.ToList());
            return View(db.sp_Billing_UV_Project_List_ORDER_BY_desc().ToList());
        }
        public ActionResult AddUnverifiedProjectBill(int? id)
        {

            if (id == 0)
            {
                ViewBag.isAutoId = true;
                var id_ = 0;
                string finalVoucherNum;
                var idList = db.UnVerified_project_bills.Select(x => x.id).ToList();
                // var idList = db.Billings.ToList();
                if (idList.Count != 0)
                {
                    var idd = idList.Last();
                    var iddd = Convert.ToInt16(idd);
                    id_ = iddd + 1;

                    finalVoucherNum = Convert.ToString("000" + id_);
                    ViewBag.vNum = finalVoucherNum;
                }
                else
                {
                    finalVoucherNum = Convert.ToString("000" + 1);
                    ViewBag.vNum = finalVoucherNum;
                }
            }
            else
            {
                ViewBag.isAutoId = false;
            }

            ViewBag.control = db.Control_Details.ToList();
            ViewBag.paidTo = db.Paid_to_Details.ToList();
            ViewBag.category = ddb.Sp_Mima_Finance_Dev_SelectCategory().ToList();
            //ViewBag.Category = db.Categories.ToList();
            var iddddd = db.Billings.Select(x => x.Bill_id).ToList();//for verify bills.
            var a = iddddd.Last();
            ViewBag.verifyBillId = a.ToString();
            var dataa = db.UnVerified_project_bills.Find(id);

            if (id != 0)
            {
                dataa.amountWithComma = string.Format("{0:#,0}", (dataa.Amount == null ? 0 : dataa.Amount));
            }

            return PartialView("AddprojectBillsUnverified", dataa);
        }
        [HttpPost]
        public ActionResult AddProjectBillunverified(UnVerified_project_bills data) {

            if (data.id == 0)
            {
                string computer_name = Path.GetFileNameWithoutExtension(data.ImageFile.FileName);// file name before save. 


                string extension = Path.GetExtension(data.ImageFile.FileName);
                var name1 = DateTime.Now.ToString("yymmssfff") + extension;

                var name2 = name1;
                var fileSize = data.ImageFile.ContentLength;
                string fileType = data.ImageFile.ContentType;

                Stream a = data.ImageFile.InputStream;
                System.Drawing.Image image = System.Drawing.Image.FromStream(a);
                int height = image.Height;
                int width = image.Width;

                //  string folder = "Image";
                string folder = "projectbillunverifiedImage";

                string fileName = Path.Combine(Server.MapPath(folder), name1);

                string isFolder_exist = Path.Combine(Server.MapPath(folder));

                bool isexist = Directory.Exists(isFolder_exist);
                if (!isexist)
                {
                    Directory.CreateDirectory(isFolder_exist);
                }

                data.ImageFile.SaveAs(fileName);
                ModelState.Clear();
                data.imgPath = name2;
                data.createAt = DateTime.Now;
                data.isCancell = false;
                data.isPending = false;
                //data.isProjectbill = true;
                data.isMove = false;
                data.Amount = Convert.ToInt32(data.amountWithComma.Replace(",", ""));
                db.UnVerified_project_bills.Add(data);
            }
            else
            {
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;

            }
            db.SaveChanges();
            return RedirectToAction("unverifiedprojectBills", "Billing");

            //return PartialView("_vBilling", db.Billings.ToList());

        }

        public ActionResult moveUvprojectbilltoverifiedprojectbill(Billing data)
        {
            ///verified project bill insert inthe verified billing table with key of  isProject.


          //  if (data.id == 0)
                if (data.id != 0)
                {
                string computer_name = Path.GetFileNameWithoutExtension(data.ImageFile.FileName);// file name before save. 


                string extension = Path.GetExtension(data.ImageFile.FileName);
                var name1 = DateTime.Now.ToString("yymmssfff") + extension;

                var name2 = name1;
                var fileSize = data.ImageFile.ContentLength;
                string fileType = data.ImageFile.ContentType;

                Stream a = data.ImageFile.InputStream;
                System.Drawing.Image image = System.Drawing.Image.FromStream(a);
                int height = image.Height;
                int width = image.Width;

                string folder = "Image";

                string fileName = Path.Combine(Server.MapPath(folder), name1);

                string isFolder_exist = Path.Combine(Server.MapPath(folder));

                bool isexist = Directory.Exists(isFolder_exist);
                if (!isexist)
                {
                    Directory.CreateDirectory(isFolder_exist);
                }


                var unverifiedprojectbillDataByID = db.UnVerified_project_bills.Where(x => x.id == data.unVerifedbillSQLid).ToList();

                data.unVerifiedBill_id = unverifiedprojectbillDataByID[0].Bill_id;
                data.ImageFile.SaveAs(fileName);
                ModelState.Clear();
                data.imgPath = name2;
                data.createAt = DateTime.Now;
                data.isCancell = false;
                data.isPending = false;
                data.isProjectbill = true;
                data.Amount = Convert.ToInt32(data.amountWithComma.Replace(",", ""));
                db.Billings.Add(data);

                unverifiedprojectbillDataByID[0].isMove = true;
              // db.UnVerified_project_bills.Add(unverifiedprojectbillDataByID[0]);
            }
            else
            {
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;

            }
            db.SaveChanges();
            return RedirectToAction("projectBills", "Billing");
            //return PartialView("_vBilling", db.Billings.ToList());
        }

        public ActionResult CancelUnvBill(int? id, string table)
        {

            db.sp_CancelforUnvBill(id, table);
            if (table == "Billing_UnVerified")
            {
                return RedirectToAction("UnVerifiedBillsV", "Billing");
            }
            else
            {
                return RedirectToAction("CashpendingRecord", "Home");
            }




        }


    }



   

}