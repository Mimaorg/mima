using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace WebApplication1.Models
{
    public class UnVBillsPartial
    {
    }
    [MetadataType(typeof(Billing_UnVerified))]
    public partial class Billing_UnVerified
    {

        public HttpPostedFileBase ImageFile { get; set; }

        public string amountWithComma { get; set; }

    }
}