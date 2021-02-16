using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class unverifiedprojectpartial
    {
    }
    [MetadataType(typeof(UnVerified_project_bills))]
    public partial class UnVerified_project_bills
    {

            public HttpPostedFileBase ImageFile { get; set; }

            public string amountWithComma { get; set; }



       }
}


