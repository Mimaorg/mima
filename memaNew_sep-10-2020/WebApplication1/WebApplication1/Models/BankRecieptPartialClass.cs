﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class BankRecieptPartialClass
    {
    }

    [MetadataType(typeof(BankReceiptVoucher))]
    public partial class BankReceiptVoucher
    {
        public string E_Date { get; set; }
        public string S_Date { get; set; }

        public string AmountWithComma { get; set; }

    }

}