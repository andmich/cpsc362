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
        public ActionResult Index(int userId, string notification)
        {
            // load UserInfo with UserId passed in
            var rUserInfo = new UserInfoRepository();
            var userInfo = rUserInfo.GetByUserId(userId);

            // Session variable for userId. Need it 
            // to persist throughout the user's session
            Session["userId"] = userId;
            Session["userName"] = userInfo.Username; 

            // get all user's passwords
            var rProfile = new PasswordInfoRepository();
            var userPasswords = rProfile.GetByUserId(userId);

            var viewModel = new ProfileViewModel()
            {
                UserInfo = userInfo,
                UserPasswords = userPasswords,
                Notification = notification
            };

            return View(viewModel);
        }

        #region Ajax Functions
        public ActionResult GetPasswordAdditionalInfo(int passId)
        {
            var rPasswordInfo = new PasswordInfoRepository();
            var passwordInfo = rPasswordInfo.GetByPasswordId(passId);

            var viewModel = new ProfileViewModel()
            {
                PasswordInfo = passwordInfo
            };

            return PartialView("~/Views/Profile/PasswordAdditionalInfo.cshtml", viewModel);
        }

        
        #endregion

    }
}
