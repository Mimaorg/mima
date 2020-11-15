using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;



namespace WebApplication1.mima_img_processing
{
    public class BillimgUpload
    {


        //public string upload(Billing imageModel)
        //{

        //    string computer_name = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);// file name before save. 


        //    string extension = Path.GetExtension(imageModel.ImageFile.FileName);
        //    var name1 = DateTime.Now.ToString("yymmssfff") + extension;
        //    //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
        //    var name2 = name1; //DateTime.Now.ToString("yymmssfff") + extension;
        //    var fileSize = imageModel.ImageFile.ContentLength;      //file size in kb.
        //    string fileType = imageModel.ImageFile.ContentType;

        //    Stream a = imageModel.ImageFile.InputStream;
        //    System.Drawing.Image image = System.Drawing.Image.FromStream(a);
        //    int height = image.Height;
        //    int width = image.Width;

        //    string folder = "Image";

        //    string fileName = Path.Combine(.MapPath(folder), name1);
        //    //var name3 = Path.Combine(Server.MapPath(folder), name2);
        //    string isFolder_exist = Path.Combine(Server.MapPath(folder)); // fileName1 contain only folder name 
        //                                                                  // ~/ uploadImage / Image / 191848515.jpg
        //    bool isexist = Directory.Exists(isFolder_exist);
        //    if (!isexist)
        //    {
        //        Directory.CreateDirectory(isFolder_exist);
        //    }

        //    string save = " ~/uploadImage/" + folder + "/" + name2;
        //    //var name2 = fileName.ToString();
        //    //string file_name_after_save = name2.Split('\\')[6];//it contain only file name after 
        //    //imageModel.path = "";
        //    //imageModel.computer_FileName = computer_name + extension;
        //    //imageModel.server_FilieName = name2;
        //    //imageModel.height = height;
        //    //imageModel.width = width;
        //    //imageModel.num_of_sharing = 0;
        //    //imageModel.num_of_uplload = 1;
        //    //imageModel.isUsed = true;
        //    //imageModel.isActive = true;
        //    //imageModel.createAT = DateTime.Now;
        //    //imageModel.size = fileSize;
        //    //imageModel.extension = extension;
        //    //db.Add(imageModel);
        //    //db.SaveChanges();
        //    imageModel.ImageFile.SaveAs(fileName);
        //    ModelState.Clear();


        //    return "";

        //}
    }
}