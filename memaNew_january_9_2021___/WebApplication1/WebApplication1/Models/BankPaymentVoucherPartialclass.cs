using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class BankPaymentVoucherPartialclass
    {
    }
    [MetadataType(typeof(bankPaymentVoucher))]
    public partial class bankPaymentVoucher
    {
        public string E_Date { get; set; }
        public string S_Date { get; set; }
        public string AmountWithComma { get; set; }
        public string TaxAmountWithComma { get; set; }

        public string amountArray { get; set; }

        public string chequesArray { get; set; }
        // public string pdcDate { get; set; }

    }
}