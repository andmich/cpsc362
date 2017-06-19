using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PasswordManagerProject.DBML;
using PasswordManagerProject.Models;

namespace PasswordManagerProject.Controllers
{
    public class PasswordController : Controller
    {
        // loads password to be edited
        public ActionResult Edit(int passwordId)
        {
            var rPassword = new PasswordInfoRepository();
            var currentPassword = rPassword.GetByPasswordId(passwordId);

            var viewModel = new PasswordViewModel()
            {
                PasswordInfo = currentPassword
            };

            return View(viewModel);
        }

    }
}
