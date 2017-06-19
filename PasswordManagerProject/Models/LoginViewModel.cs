using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PasswordManagerProject.DBML;

namespace PasswordManagerProject.Models
{
    public class LoginViewModel 
    {
        public UserInfo UserInfo { get; set; }
        public PasswordInfo PasswordInfo { get; set; }

    }
}
