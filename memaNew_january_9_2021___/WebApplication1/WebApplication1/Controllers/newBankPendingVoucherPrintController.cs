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
    public class newBankPendingVoucherPrintController : Controller
    {
        // GET: newBankPendingVoucherPrint
        int _tablecolumn = 3;
        Document _document;
        Font _fontStyle;
        PdfPTable _PdfTable = new PdfPTable(3);
        PdfPTable _table1 = new PdfPTable(2);
        PdfPTable _table2 = new PdfPTable(3);
        PdfPTable _table3 = new PdfPTable(9);
        PdfPTable _table4 = new PdfPTable(4);
        PdfPTable _table5 = new PdfPTable(6);
        PdfPTable _table6 = new PdfPTable(8);
        PdfPTable _table7 = new PdfPTable(6);
        iTextSharp.text.Image jpg;


        PdfPCell _PdfCell;
        MemoryStream _memoryStream = new MemoryStream();

        Mima_Finance_DevEntities dd = new Mima_Finance_DevEntities();
        Mima_Finance_Entities db = new Mima_Finance_Entities();
        // GET: shart
        public ActionResult Index(bankPaymentVoucher data)

        {
            //byte[] abytes = prepareReport(data);
            //return File(abytes, "application/pdf");
            byte[] abytes = prepareReport(data);
            string base64String = Convert.ToBase64String(abytes, 0, abytes.Length);
            return Json(base64String, JsonRequestBehavior.AllowGet);
            #region

            #endregion

           
        }

        public byte[] prepareReport(bankPaymentVoucher data)
        {

            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);

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

            _table6.WidthPercentage = 100;
            _table6.HorizontalAlignment = Element.ALIGN_LEFT;

            _table7.WidthPercentage = 100;
            _table7.HorizontalAlignment = Element.ALIGN_LEFT;

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            _PdfTable.SetWidths(new float[] { 40f, 20f, 20f });

            _table1.SetWidths(new float[] { 10f, 30f });
            _table2.SetWidths(new float[] { 40f, 10f, 20f });
            //_table3.SetWidths(new float[] { 40f, 30f, 40f, 30f, 30f, 30f, 30f, 30f, 30f, 30f });
            _table3.SetWidths(new float[] { 50f, 80f, 80f, 80f, 40f, 40f, 40f, 40f, 50f });
            _table4.SetWidths(new float[] {40f ,40f, 40f, 40f });
            _table5.SetWidths(new float[] { 40f, 40f, 40f, 40f, 40f, 40f });
            _table6.SetWidths(new float[] { 40f, 40f, 25f, 40f, 40f, 25f , 40f, 40f });
            _table7.SetWidths(new float[] { 40f, 40f, 40f, 40f, 40f, 40f });
            _PdfTable.SpacingBefore = 0;
            _table2.SpacingBefore = 0;
            _table4.SpacingBefore = 20;
            _table5.SpacingBefore = 10;
            _table6.SpacingBefore = 10;
            _table7.SpacingBefore = 10;
            _table3.SpacingBefore = 10;
            this.ReportHeader(data);
            this.ReportBody(data);
            _PdfTable.HeaderRows = 2;

            _document.Add(_table2);
            //_document.Add(jpg);
            _document.Add(_PdfTable);
            _document.Add(_table6);
            _document.Add(_table7);
           // _document.Add(_table4);
           // _document.Add(_PdfTable);
            _document.Add(_table1);
           
            _document.Add(_table3);
            _document.Add(_table5);
            _document.Add(_table4);

            _document.Close();
            return _memoryStream.ToArray();

        }

        public void ReportHeader(bankPaymentVoucher data)
        {

            var logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Content/img/LOGO.jpg"));
            //logo.SetAbsolutePosition(400,2000);
            //_document.Add(logo);

            string imageURL = Server.MapPath("~/Content/img/LOGO.jpg");

            jpg = iTextSharp.text.Image.GetInstance(imageURL);

            //Resize image depend upon your need

            jpg.ScaleToFit(140f, 120f);

            //Give space before image

            //jpg.SpacingBefore = 1f;

            //Give some space after the image

            //jpg.SpacingAfter = 1f;

            //jpg.Alignment = Element.ALIGN_LEFT;


            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(jpg);
            //_PdfCell.Colspan = 3;
            // _PdfCell.Width = 2;
            _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            //_PdfCell.VerticalAlignment = Element.ALIGN_BOTTOM;
            _PdfCell.Border = 0;
            _table2.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Created by " + Session["UserName"].ToString() + ".", _fontStyle));
            _PdfCell.Colspan = 2;
            // _PdfCell.Width = 2;
            _PdfCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            //_PdfCell.VerticalAlignment = Element.ALIGN_BOTTOM;
            _PdfCell.Border = 0;
            _table2.AddCell(_PdfCell);
            _PdfTable.CompleteRow();


            //_document.Add(jpg);

            //_fontStyle = _fontStyle = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 14f, BaseColor.BLACK);
            //_PdfCell = new PdfPCell(new Phrase(" ", _fontStyle));
            //_PdfCell.Colspan = _tablecolumn;
            //_PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //_PdfCell.Border = 0;
            //_PdfCell.BackgroundColor = BaseColor.WHITE;
            //_PdfCell.ExtraParagraphSpace = 0;
            //_PdfTable.AddCell(_PdfCell);
            //_PdfTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 14f, 1);
            _PdfCell = new PdfPCell(new Phrase("Bank Payment Voucher", _fontStyle));
            _PdfCell.Colspan = 3;
            // _PdfCell.Width = 2;
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //_PdfCell.VerticalAlignment = Element.ALIGN_BOTTOM;
            _PdfCell.Border = 0;
            _table2.AddCell(_PdfCell);
            _PdfTable.CompleteRow();



            _fontStyle = _fontStyle = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 14f, 1);
            _PdfCell = new PdfPCell(new Phrase("Bank Payment Voucher", _fontStyle));
            _PdfCell.Colspan = _tablecolumn;
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.Border = 0;
            _PdfCell.BackgroundColor = BaseColor.WHITE;
            _PdfCell.ExtraParagraphSpace = 0;
            _PdfTable.AddCell(_PdfCell);
            _PdfTable.CompleteRow();



        }

        public void ReportBody(bankPaymentVoucher data)
        {
            #region table 1
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("V.no", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table6.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Date", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table6.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Cat.", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table6.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Bank", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table6.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Branch", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table6.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Org", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table6.AddCell(_PdfCell);
            

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Cheq.No", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table6.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("P.D.C", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table6.AddCell(_PdfCell);

            /// ----------------body above table
         

            // _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _PdfCell = new PdfPCell(new Phrase(data.Vnumber.ToString(), _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.WHITE;
            _table6.AddCell(_PdfCell);

            // _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _PdfCell = new PdfPCell(new Phrase(data.Date.ToString(), _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.WHITE;
            _table6.AddCell(_PdfCell);

            // _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _PdfCell = new PdfPCell(new Phrase(data.Category.ToString(), _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.WHITE;
            _table6.AddCell(_PdfCell);


            // _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _PdfCell = new PdfPCell(new Phrase(data.Bank.ToString(), _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.WHITE;
            _table6.AddCell(_PdfCell);

            //  _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _PdfCell = new PdfPCell(new Phrase(data.Branch.ToString(), _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.WHITE;
            _table6.AddCell(_PdfCell);

            //   _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _PdfCell = new PdfPCell(new Phrase(data.Org.ToString(), _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.WHITE;
            _table6.AddCell(_PdfCell);

            
            _PdfCell = new PdfPCell(new Phrase(data.ChequeNo.ToString(), _fontStyle));
            //_PdfCell = new PdfPCell(new Phrase(d.ToString(), _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.WHITE;
            _table6.AddCell(_PdfCell);

            
            //_PdfCell = new PdfPCell(new Phrase(Convert.ToString((int)item.Balance), _fontStyle));
            _PdfCell = new PdfPCell(new Phrase(data.pdcDate != null ? string.Format("{0:dd/MM/yyyy}", data.pdcDate) : "no P.D.C", _fontStyle));

            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.WHITE;
            _table6.AddCell(_PdfCell);

            #endregion of table 1

            #region table 2

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Paid To", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table7.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Project", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table7.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Amount", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table7.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Tax", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table7.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Total", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table7.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("Description", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table7.AddCell(_PdfCell);
            
            /// ----------------body above table


            // _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _PdfCell = new PdfPCell(new Phrase(data.PaidTo.ToString(), _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.WHITE;
            _table7.AddCell(_PdfCell);

            // _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _PdfCell = new PdfPCell(new Phrase(data.Control.ToString(), _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.WHITE;
            _table7.AddCell(_PdfCell);

            // string taxamount = string.Format("{0:#,0}", (data.TaxAmount == null ? 0 : data.TaxAmount));
            // 123,000,000
            string taxamount = data.TaxAmountWithComma;
            var totalamount = Convert.ToInt32(data.AmountWithComma.Replace(",", "")) - Convert.ToInt32(taxamount.Replace(",", ""));
            var totalamount_  = Convert.ToInt32(data.AmountWithComma.Replace(",", "")) + Convert.ToInt32(taxamount.Replace(",", ""));
            
            if (data.AmountWithComma.Contains(","))
            {
                var amoutn1 = string.Format("{0:#,0}", data.AmountWithComma == null ? "0" : data.AmountWithComma);
                _PdfCell = new PdfPCell(new Phrase(amoutn1, _fontStyle));
            }
            else
            {
                var amoutn1 = string.Format("{0:#,0}", Convert.ToInt32(data.AmountWithComma) == null ? 0 : Convert.ToInt32(data.AmountWithComma));
                _PdfCell = new PdfPCell(new Phrase(amoutn1, _fontStyle));
            }
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.WHITE;
            _table7.AddCell(_PdfCell);




            // _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
         
            _PdfCell = new PdfPCell(new Phrase(taxamount, _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.WHITE;
            _table7.AddCell(_PdfCell);





            //  _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            //_PdfCell = new PdfPCell(new Phrase(data.AmountWithComma, _fontStyle));
            var amoutntotalFinal = string.Format("{0:#,0}", (totalamount_ == null ? 0 : totalamount_));

            _PdfCell = new PdfPCell(new Phrase(amoutntotalFinal, _fontStyle));
            
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.WHITE;
            _table7.AddCell(_PdfCell);

            //   _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _PdfCell = new PdfPCell(new Phrase(data.Description.ToString(), _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.WHITE;
            _table7.AddCell(_PdfCell);

            #endregion table 2

            #region signature table 
            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _PdfCell = new PdfPCell(new Phrase("Prepained: __________", _fontStyle));
            _PdfCell.Border = 0;
            _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _table4.AddCell(_PdfCell);


            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _PdfCell = new PdfPCell(new Phrase("Approval: __________", _fontStyle));
            _PdfCell.Border = 0;
            _PdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _table4.AddCell(_PdfCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _PdfCell = new PdfPCell(new Phrase("Posted: ___________", _fontStyle));
            //_PdfCell.Colspan = 2;
            // _PdfCell.Width = 2;
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.Border = 0;
            _table4.AddCell(_PdfCell);

            _PdfCell = new PdfPCell(new Phrase("Received: ___________", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _PdfCell.Border = 0;
            //_PdfCell.Width = 2;
            _table4.AddCell(_PdfCell);
            _table4.CompleteRow();

     #endregion signature table end

            //-------------//

            PrintTable(data);
            printTable2(data);
        }

        public void PrintTable(bankPaymentVoucher data)
        {
            var list = dd.Usp_Print_Grid("Ghulam hussain", "Civil");

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
            _PdfCell = new PdfPCell(new Phrase("V.Type", _fontStyle));
            _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table3.AddCell(_PdfCell);

            //_fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            //_PdfCell = new PdfPCell(new Phrase("Category", _fontStyle));
            //_PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //_PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //_PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            //_table3.AddCell(_PdfCell);

            //_fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            //_PdfCell = new PdfPCell(new Phrase("B.Org", _fontStyle));
            //_PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //_PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //_PdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            //_table3.AddCell(_PdfCell);


            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfCell = new PdfPCell(new Phrase("V.No", _fontStyle));
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
            // _table3.CompleteRow();


            #endregion

            #region custome table body
            //foreach (var item in )
            //{

            //}
            foreach (var item in dd.Usp_Print_Grid(data.PaidTo, data.Category))
            {
                _fontStyle = FontFactory.GetFont("Tahoma", 8f, 0);
                _PdfCell = new PdfPCell(new Phrase(string.Format("{0:dd/MM/yyyy}", item.Date), _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table3.AddCell(_PdfCell);

                // _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                _PdfCell = new PdfPCell(new Phrase(item.Vendor, _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table3.AddCell(_PdfCell);

                // _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                _PdfCell = new PdfPCell(new Phrase(item.Description, _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table3.AddCell(_PdfCell);

                // _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                _PdfCell = new PdfPCell(new Phrase(item.Project, _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table3.AddCell(_PdfCell);

                // _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                _PdfCell = new PdfPCell(new Phrase(item.V_Type, _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table3.AddCell(_PdfCell);


                //// _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                //_PdfCell = new PdfPCell(new Phrase(item.Category, _fontStyle));
                //_PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                //_PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                //_PdfCell.BackgroundColor = BaseColor.WHITE;
                //_table3.AddCell(_PdfCell);

                ////  _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                //_PdfCell = new PdfPCell(new Phrase((string.IsNullOrEmpty(item.Branch_Org) ? "null" : item.Branch_Org.ToString()), _fontStyle));
                //_PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                //_PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                //_PdfCell.BackgroundColor = BaseColor.WHITE;
                //_table3.AddCell(_PdfCell);

                //   _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                _PdfCell = new PdfPCell(new Phrase(item.V_No.ToString(), _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table3.AddCell(_PdfCell);

                //  _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                //_PdfCell = new PdfPCell(new Phrase(Convert.ToString((int)item.Detib), _fontStyle));

                _PdfCell = new PdfPCell(new Phrase(String.Format("{0:#,0}", (item.Debit == null ? 0 : item.Debit)), _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table3.AddCell(_PdfCell);

                // _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
                //int d = (int)item.Credit;

                _PdfCell = new PdfPCell(new Phrase(String.Format("{0:#,0}", (item.Credit == null ? 0 : item.Credit)), _fontStyle));
                //_PdfCell = new PdfPCell(new Phrase(d.ToString(), _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table3.AddCell(_PdfCell);




                //_PdfCell = new PdfPCell(new Phrase(Convert.ToString((int)item.Balance), _fontStyle));


                string finalblnc = "";
                if (item.Balance < 0)
                {
                    var frmt = String.Format("{0:#,0}", (item.Balance * (-1)));
                    finalblnc = "(" + frmt + ")";
                }
                else {

                    var frmt = String.Format("{0:#,0}", (item.Balance));
                    finalblnc = "(" + frmt + ")";

                }

                _PdfCell = new PdfPCell(new Phrase(finalblnc, _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table3.AddCell(_PdfCell);
                //_table3.CompleteRow();
            }
            #endregion
        }

        public void printTable2(bankPaymentVoucher data1)
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
            foreach (var item in dd.Usp_APGL_Summary(data1.PaidTo, data1.Control, data1.Category).ToList())

            {
                _fontStyle = FontFactory.GetFont("Tahoma", 8f, 0);
                _PdfCell = new PdfPCell(new Phrase(item.Vendor.ToString(), _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table5.AddCell(_PdfCell);

                _fontStyle = FontFactory.GetFont("Tahoma", 8f, 0);
                _PdfCell = new PdfPCell(new Phrase(item.Project.ToString(), _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table5.AddCell(_PdfCell);

                _fontStyle = FontFactory.GetFont("Tahoma", 8f, 0);
                _PdfCell = new PdfPCell(new Phrase(String.Format("{0:#,0}", (item.Balance == null ? 0 : item.Debit)), _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table5.AddCell(_PdfCell);

                _fontStyle = FontFactory.GetFont("Tahoma", 8f, 0);
                _PdfCell = new PdfPCell(new Phrase(String.Format("{0:#,0}", (item.Balance == null ? 0 : item.Credit)), _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table5.AddCell(_PdfCell);

                _fontStyle = FontFactory.GetFont("Tahoma", 8f, 0);
                _PdfCell = new PdfPCell(new Phrase(item.Category.ToString(), _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table5.AddCell(_PdfCell);



                string finalblnc = "";
                if (item.Balance < 0)
                {
                    var frmt = String.Format("{0:#,0}", (item.Balance * (-1)));
                    finalblnc = "(" + frmt + ")";
                }
                else
                {

                    var frmt = String.Format("{0:#,0}", (item.Balance));
                    finalblnc = "(" + frmt + ")";

                }



                _fontStyle = FontFactory.GetFont("Tahoma", 8f, 0);
                _PdfCell = new PdfPCell(new Phrase(finalblnc, _fontStyle));
                _PdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _PdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfCell.BackgroundColor = BaseColor.WHITE;
                _table5.AddCell(_PdfCell);


            }

        }

    }
}