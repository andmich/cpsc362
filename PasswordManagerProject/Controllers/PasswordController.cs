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

        // This should be [POST].
        public ActionResult AddPassword(int UID, string password, string label)
        {
            var rPassword = new PasswordInfoRepository();
            var passwordToAdd = new PasswordInfo();

            // Create new PasswordInfo object and pass user parameters into it.
            passwordToAdd.Password = password;
            passwordToAdd.UserId = UID;
            passwordToAdd.LabelType = label;

            // Update the database.
            rPassword.Add(passwordToAdd);
            rPassword.Update();
            

            return RedirectToAction("Index", "Profile", new { userId = UID});
        }

        public ActionResult RemovePassword(int passID)
        {
            var rPassword = new PasswordInfoRepository();
            //rPassword.Delete()
            return RedirectToAction("Index", "Profile");
        }

    }
}
