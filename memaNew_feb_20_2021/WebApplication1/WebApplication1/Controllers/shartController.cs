using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft;
using WebApplication1.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace WebApplication1.Controllers
{
    public class shartController : Controller
    {
        int _tablecolumn = 3;
        Document _document;
        Font _fontStyle;
        PdfPTable _PdfTable = new PdfPTable(3);
        PdfPTable _table1 = new PdfPTable(2);
        PdfPTable _table2 = new PdfPTable(3);
        PdfPTable _table3 = new PdfPTable(11);
        PdfPTable _table4 = new PdfPTable(3);
        PdfPTable _table5 = new PdfPTable(6);

        PdfPCell _PdfCell;
        MemoryStream _memoryStream = new MemoryStream();
        iTextSharp.text.Image jpg;
        Mima_Finance_DevEntities dd = new Mima_Finance_DevEntities();
       
        Mima_Finance_Entities db = new Mima_Finance_Entities();
        // GET: shart
        public JsonResult Index(cashPaymentVoucher data)
            
        {
            

            byte[] abytes = prepareReport(data);
            string base64String = Convert.ToBase64String(abytes, 0, abytes.Length);
            return Json(base64String, JsonRequestBehavior.AllowGet);
            //return File(base64String, "application/pdf");
            //Response.AppendHeader("content-disposition", "inline; filename=file.pdf");
            //return new FileStreamResult(prepareReport(data), "application/pdf");
            #region

            #endregion


        }

        public byte[] prepareReport(cashPaymentVoucher data) {
          //public MemoryStream prepareReport(cashPaymentVoucher data) { 

            _document = new Document(PageSize.A4,0f,0f,0f,0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f ,20f ,20f );

            _PdfTable.WidthPercentage = 100;
            _table1.WidthPercentage = 100;
            _table1.HorizontalAlignment = Element.ALIGN_LEFT;
            _PdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

            _table2.WidthPercentage = 100;
            _table2.HorizontalAlignment = Element.ALIGN_LEFT;
            _table3.HorizontalAlignment = Element.ALIGN_CENTER;
            _table3.WidthPercentage = 100;

            _table4.WidthPercentage = 100;
            _table4.HorizontalAlignment = Element.ALIGN_LEFT;


            _table5.WidthPercentage = 100;
            _table5.HorizontalAlignment = Element.ALIGN_LEFT;


            _fontStyle = FontFactory.GetFont("Tahoma",8f,1);
            PdfWriter.GetInstance(_document,_memoryStream);
            _document.Open();
            _PdfTable.SetWidths(new float[] {30f,10f,20f});

            _table1.SetWidths(new float[] { 10f, 30f });
            _table2.SetWidths(new float[] { 40f, 10f, 20f });
            //_table3.SetWidths(new float[] { 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f, 80f });
            _table3.SetWidths(new float[] { 80f, 80f, 80f, 80f, 40f, 50f, 40f, 40f, 40f, 40f, 40f });
            // _table3.SetWidths(new float[] {40f,30f,40f, 30f, 30f, 30f, 30f, 30f, 30f,30f });
            _table4.SetWidths(new float[] { 40f, 40f, 40f });
            _table5.SetWidths(new float[] { 40f, 40f, 40f,40f, 40f, 40f });
            _PdfTable.SpacingBefore = 10;
            _table2.SpacingBefore = 50;
            _table3.SpacingBefore = 50;
            _table4.SpacingBefore = 50;
            _table5.SpacingBefore = 50;
            this.ReportHeader(data);         
            this.ReportBody(data);

            _PdfTable.HeaderRows= 2;
            _document.Add(_table2);
            _document.Add(jpg);
            _document.Add(_PdfTable);
            _document.Add(_table1);            
            _document.Add(_table4);
            _document.Add(_table3);
            _document.Add(_table5);

            _document.Close();
            //return _memoryStream.ToArray();

            return _memoryStream.ToArray();
            
        }

        public  void ReportHeader(cashPaymentVoucher data) {


            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("created by " + Session["UserName"].ToString() + ".", _fontStyle));
            _PdfCell.Colspan = 3;
            // _PdfCell.Width = 2;
            _PdfCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            //_PdfCell.VerticalAlignment = Element.ALIGN_BOTTOM;
            _PdfCell.Border = 0;
            _table2.AddCell(_PdfCell);


            var logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Content/img/LOGO.jpg"));
            //logo.SetAbsolutePosition(400,2000);
            //_document.Add(logo);

            string imageURL = Server.MapPath("~/Content/img/LOGO.jpg");

            //            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
                  jpg = iTextSharp.text.Image.GetInstance(imageURL);

            //Resize image depend upon your need

            jpg.ScaleToFit(140f, 120f);

            //Give space before image

            jpg.SpacingBefore = 10f;

            //Give some space after the image

            jpg.SpacingAfter = 1f;

            jpg.Alignment = Element.ALIGN_LEFT;

            //_document.Add(jpg);

            _fontStyle = _fontStyle = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 14f,BaseColor.BLACK);
            _PdfCell = new PdfPCell(new Phrase("",_fontStyle));
            _PdfCell.Colspan = _tablecolumn;
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.Border = 0;
            _PdfCell.BackgroundColor = BaseColor.WHITE;
            _PdfCell.ExtraParagraphSpace = 0;
            _PdfTable.AddCell(_PdfCell);
            _PdfTable.CompleteRow();


            _fontStyle = _fontStyle = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 14f, 1);
            _PdfCell = new PdfPCell(new Phrase("Cash Payment Voucher", _fontStyle));
            _PdfCell.Colspan = _tablecolumn;
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.Border = 0;
            _PdfCell.BackgroundColor = BaseColor.WHITE;
            _PdfCell.ExtraParagraphSpace = 0;
            _PdfTable.AddCell(_PdfCell);
            _PdfTable.CompleteRow();

            _fontStyle = _fontStyle = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 14f, BaseColor.BLACK);
            _PdfCell = new PdfPCell(new Phrase("\n", _fontStyle));
            _PdfCell.Colspan = _tablecolumn;
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.Border = 0;
            _PdfCell.BackgroundColor = BaseColor.WHITE;
            _PdfCell.ExtraParagraphSpace = 0;
            _PdfTable.AddCell(_PdfCell);
            _PdfTable.CompleteRow();





        }

        public void ReportBody(cashPaymentVoucher data)
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _PdfCell = new PdfPCell(new Phrase("", _fontStyle));
            _PdfCell.Border = 0;
            _PdfCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _PdfTable.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _PdfCell = new PdfPCell(new Phrase("Voucer No: ", _fontStyle));
            //_PdfCell.Colspan = 2;
          //  _PdfCell.Width = 2; 
            _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _PdfCell.Border = 0;
            _PdfTable.AddCell(_PdfCell);

            _PdfCell = new PdfPCell(new Phrase(data.Vnumber.ToString(), _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _PdfCell.Border = 0;
            _PdfTable.AddCell(_PdfCell);
            _PdfTable.CompleteRow();
            //-------------//

            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _PdfCell = new PdfPCell(new Phrase("", _fontStyle));
            _PdfCell.Border = 0;
            _PdfCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _PdfTable.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _PdfCell = new PdfPCell(new Phrase("Date : ", _fontStyle));
            //_PdfCell.Colspan = 2;
           // _PdfCell.Width = 2;
            _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _PdfCell.Border = 0;
            _PdfTable.AddCell(_PdfCell);

            _PdfCell = new PdfPCell(new Phrase(data.Date.ToString(), _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _PdfCell.Border = 0;
            //_PdfCell.Width = 2;
            _PdfTable.AddCell(_PdfCell);
            _PdfTable.CompleteRow();

            //-------------//

            //-------------//

            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _PdfCell = new PdfPCell(new Phrase("", _fontStyle));
            _PdfCell.Border = 0;
            _PdfCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _PdfTable.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _PdfCell = new PdfPCell(new Phrase("Category : ", _fontStyle));
            //_PdfCell.Colspan = 2;
            // _PdfCell.Width = 2;
            _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _PdfCell.Border = 0;
            _PdfTable.AddCell(_PdfCell);

            _PdfCell = new PdfPCell(new Phrase(data.Category, _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _PdfCell.Border = 0;
            //_PdfCell.Width = 2;
            _PdfTable.AddCell(_PdfCell);
            _PdfTable.CompleteRow();

            //-------------//

            //----------//


            _PdfCell = new PdfPCell(new Phrase("\n", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _PdfCell.Border = 0;
            _PdfCell.Colspan = 2;
            _table1.AddCell(_PdfCell);
            _table1.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _PdfCell = new PdfPCell(new Phrase("Paid To: ", _fontStyle));
            _PdfCell.Border = 0;
            _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _table1.AddCell(_PdfCell);
            _PdfCell = new PdfPCell(new Phrase(data.PaidTo.ToString(), _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _PdfCell.Border = 0;
            _table1.AddCell(_PdfCell);
            _table1.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _PdfCell = new PdfPCell(new Phrase("Control: ", _fontStyle));
            _PdfCell.Border = 0;
            _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _table1.AddCell(_PdfCell);
            _PdfCell = new PdfPCell(new Phrase(data.Control.ToString(), _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _PdfCell.Border = 0;
            _table1.AddCell(_PdfCell);
            _table1.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _PdfCell = new PdfPCell(new Phrase("Amount: ", _fontStyle));
            _PdfCell.Border = 0;
            _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _table1.AddCell(_PdfCell);
            _PdfCell = new PdfPCell(new Phrase(data.AmountWithComma.ToString(), FontFactory.GetFont("Tahoma", 14f, Font.UNDERLINE)));
            _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _PdfCell.Border = 0;
            _table1.AddCell(_PdfCell);
            _table1.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _PdfCell = new PdfPCell(new Phrase("Rupee: ", _fontStyle));
            _PdfCell.Border = 0;
            _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _table1.AddCell(_PdfCell);
            _PdfCell = new PdfPCell(new Phrase(data.Rupees.ToString(), _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _PdfCell.Border = 0;
            _table1.AddCell(_PdfCell);
            _table1.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _PdfCell = new PdfPCell(new Phrase("Description: ", _fontStyle));
            _PdfCell.Border = 0;
            _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _table1.AddCell(_PdfCell);
            _PdfCell = new PdfPCell(new Phrase(data.Description.ToString(), _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _PdfCell.Border = 0;
            _table1.AddCell(_PdfCell);
            _table1.CompleteRow();


            //-------------//

            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _PdfCell = new PdfPCell(new Phrase("Approval: ____________", _fontStyle));
            _PdfCell.Border = 0;
            _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _table4.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _PdfCell = new PdfPCell(new Phrase("Posted: _____________", _fontStyle));
            //_PdfCell.Colspan = 2;
            // _PdfCell.Width = 2;
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.Border = 0;
            _table4.AddCell(_PdfCell);

            _PdfCell = new PdfPCell(new Phrase("Received: _____________", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _PdfCell.Border = 0;
            //_PdfCell.Width = 2;
            _table4.AddCell(_PdfCell);
            _table4.CompleteRow();


            _PdfCell = new PdfPCell(new Phrase("\n", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _PdfCell.Border = 0;
            _PdfCell.Colspan = 3;
            //_PdfCell.Width = 2;
            _table4.AddCell(_PdfCell);
            _table4.CompleteRow();


            _PdfCell = new PdfPCell(new Phrase("\n", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _PdfCell.Border = 0;
            _PdfCell.Colspan = 3;
            //_PdfCell.Width = 2;
            _table4.AddCell(_PdfCell);
            _table4.CompleteRow();


            //-------------//





            //-------------//

            //_fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            //_PdfCell = new PdfPCell(new Phrase("", _fontStyle));
            //_PdfCell.Border = 0;
            //_PdfCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            //_table2.AddCell(_PdfCell);

            //_fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            //_PdfCell = new PdfPCell(new Phrase("Signature : ", _fontStyle));
            ////_PdfCell.Colspan = 2;
            //// _PdfCell.Width = 2;
            //_PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            //_PdfCell.Border = 0;
            //_table2.AddCell(_PdfCell);

            //_PdfCell = new PdfPCell(new Phrase("________________", _fontStyle));
            //_PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            //_PdfCell.Border = 0;
            ////_PdfCell.Width = 2;
            //_table2.AddCell(_PdfCell);
            //_table2.CompleteRow();

            //-------------//
            PrintTable(data);
            printTable2(data);
            //S

        }

        public void PrintTable(cashPaymentVoucher data)
        {
            var list = dd.Usp_Print_Grid(data.PaidTo.ToString(),data.Category.ToString());

            #region custome table header
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Date", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table3.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Vendor", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table3.AddCell(_PdfCell);
            

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Description", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table3.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Project", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table3.AddCell(_PdfCell);

            

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("V Type", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table3.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Category", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table3.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Branch Org", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table3.AddCell(_PdfCell);


            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Voucher No", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table3.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Debit", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table3.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Credit", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table3.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Balance", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table3.AddCell(_PdfCell);
            _table3.CompleteRow();


            #endregion

            #region custome table body
            //foreach (var item in )
            //{

            //}
            foreach (var item in dd.Usp_Print_Grid(data.PaidTo.ToString(),data.Category.ToString()))

            {
                _fontStyle = FontFactory.GetFont("Tahoma", 8f, 0);
                _PdfCell = new PdfPCell(new Phrase(string.Format("{0:dd/MM/yyyy}", item.Date), _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table3.AddCell(_PdfCell);

                // _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                _PdfCell = new PdfPCell(new Phrase(item.Vendor, _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table3.AddCell(_PdfCell);


                // _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                _PdfCell = new PdfPCell(new Phrase(item.Description, _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table3.AddCell(_PdfCell);

                // _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                _PdfCell = new PdfPCell(new Phrase(item.Project, _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table3.AddCell(_PdfCell);

               

                // _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                _PdfCell = new PdfPCell(new Phrase(item.V_Type, _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table3.AddCell(_PdfCell);


                // _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                _PdfCell = new PdfPCell(new Phrase(item.Category, _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table3.AddCell(_PdfCell);


                //  _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                _PdfCell = new PdfPCell(new Phrase((string.IsNullOrEmpty(item.B_O) ? "null" : item.B_O.ToString()), _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table3.AddCell(_PdfCell);

                //   _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                _PdfCell = new PdfPCell(new Phrase(item.V_No.ToString(), _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table3.AddCell(_PdfCell);

                //  _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                //_PdfCell = new PdfPCell(new Phrase(Convert.ToString((int)item.Detib), _fontStyle));

                _PdfCell = new PdfPCell(new Phrase(String.Format("{0:#,0}", (item.Debit == null ? 0 : item.Debit)), _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table3.AddCell(_PdfCell);

                // _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                int d = (int)item.Credit;
                // _PdfCell = new PdfPCell(new Phrase(d.ToString(), _fontStyle));
                _PdfCell = new PdfPCell(new Phrase(String.Format("{0:#,0}", (item.Credit == null ? 0 : item.Credit)), _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table3.AddCell(_PdfCell);




                //_PdfCell = new PdfPCell(new Phrase(Convert.ToString((int)item.Balance), _fontStyle));

                _PdfCell = new PdfPCell(new Phrase(String.Format("{0:#,0}", (item.Balance == null ? 0 : item.Balance)), _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table3.AddCell(_PdfCell);
                _table3.CompleteRow();
            }
            #endregion
        }

        public void printTable2(cashPaymentVoucher data1)
        {
            //_PdfCell = new PdfPCell(new Phrase("\n", _fontStyle));
            //_PdfCell.Colspan = 5;
            //_PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            //_table5.AddCell(_PdfCell);



            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Vendor", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table5.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Project", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table5.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Debit", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table5.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Credit", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table5.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Category", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table5.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Balance", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table5.AddCell(_PdfCell);
            foreach (var item in dd.Usp_APGL_Summary(data1.PaidTo, data1.Control,data1.Category.ToString()).ToList())

            {
                _fontStyle = FontFactory.GetFont("Tahoma", 8f, 0);
                _PdfCell = new PdfPCell(new Phrase(item.Vendor.ToString(), _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table5.AddCell(_PdfCell);

                _fontStyle = FontFactory.GetFont("Tahoma", 8f, 0);
                _PdfCell = new PdfPCell(new Phrase(item.Project.ToString(), _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table5.AddCell(_PdfCell);

                _fontStyle = FontFactory.GetFont("Tahoma", 8f, 0);
                _PdfCell = new PdfPCell(new Phrase(String.Format("{0:#,0}", (item.Balance == null ? 0 : item.Debit)), _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table5.AddCell(_PdfCell);

                _fontStyle = FontFactory.GetFont("Tahoma", 8f, 0);
                _PdfCell = new PdfPCell(new Phrase(String.Format("{0:#,0}", (item.Balance == null ? 0 : item.Credit)), _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table5.AddCell(_PdfCell);

                _fontStyle = FontFactory.GetFont("Tahoma", 8f, 0);
                _PdfCell = new PdfPCell(new Phrase(item.Category.ToString(), _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table5.AddCell(_PdfCell);

                _fontStyle = FontFactory.GetFont("Tahoma", 8f, 0);
                _PdfCell = new PdfPCell(new Phrase(String.Format("{0:#,0}", (item.Balance == null ? 0 : item.Balance)), _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table5.AddCell(_PdfCell);


            }

        }
    }

    


}