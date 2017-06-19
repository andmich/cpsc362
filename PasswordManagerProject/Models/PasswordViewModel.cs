using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PasswordManagerProject.DBML;
using PasswordManagerProject.Models;

namespace PasswordManagerProject.Models
{
    public class PasswordViewModel 
    {
        public PasswordInfo PasswordInfo { get; set; }
    }
}
