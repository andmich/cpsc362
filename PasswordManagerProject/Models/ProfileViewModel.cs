using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PasswordManagerProject.DBML;

namespace PasswordManagerProject.Models
{
    public class ProfileViewModel
    {
        public UserInfo UserInfo { get; set; }
        public IQueryable<PasswordInfo> UserPasswords { get; set; }

    }
}
