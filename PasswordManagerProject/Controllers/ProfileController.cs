using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PasswordManagerProject.DBML;
using PasswordManagerProject.Models;

namespace PasswordManagerProject.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult Index(int userId)
        {
            // load UserInfo with UserId passed in
            var rUserInfo = new UserInfoRepository();
            var userInfo = rUserInfo.GetByUserId(userId);

            // Session variable for userId. Need it 
            // to persist throughout the user's session
            Session["userId"] = userId;

            // get all user's passwords
            var rProfile = new PasswordInfoRepository();
            var userPasswords = rProfile.GetByUserId(userId);

            var viewModel = new ProfileViewModel()
            {
                UserInfo = userInfo,
                UserPasswords = userPasswords
            };

            return View(viewModel);
        }

    }
}
