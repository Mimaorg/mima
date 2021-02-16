using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class loginPartial
    {
    }
    [MetadataType(typeof(Login))]
    public partial class Login
    {
        public bool isRememberme { get; set; }
       
    }
    }