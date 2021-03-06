using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class BillPartialClass
    {
    }
    [MetadataType(typeof(Billing))]
    public partial class Billing {

        public HttpPostedFileBase ImageFile { get; set; }

        public string amountWithComma { get; set; }

       

    }
}