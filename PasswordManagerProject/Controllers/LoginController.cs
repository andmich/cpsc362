using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PasswordManagerProject.DBML;

namespace PasswordManagerProject.Controllers
{
    public class LoginController : Controller
    {
        // this login index is set up to be the start up page. nothing needs to be loaded on the back end
        // so we just return the view
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        // this is called after the user clicks submit on the username and password fields
        [HttpPost]
        public ActionResult Index(string username, string password)
        {            
            var rUserInfo = new UserInfoRepository("Server=tcp:pass123.database.windows.net,1433;Initial Catalog=pass123db;Persist Security Info=False;User ID=cpsc362;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            // this calls a repository that will call the database
            var userInfo = rUserInfo.GetByUserNameAndPassword(username, password);

            // if userinfo is not null, go to the Profile controller, else reload the login page
            if (userInfo != null)
            {
                // go to Profile page and send UserId
                return RedirectToAction("Index", "Profile", new { userId = userInfo.UserId });
            }

            return Index();
        }


        [HttpPost]
        public ActionResult AddNewUser(FormCollection values)
        {
            var rUserInfo = new UserInfoRepository("Server=tcp:pass123.database.windows.net,1433;Initial Catalog=pass123db;Persist Security Info=False;User ID=cpsc362;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            var dateYear = Convert.ToInt32(values["NewYear"]);
            var dateMonth = Convert.ToInt32(values["NewMonth"]);
            var dateDay = Convert.ToInt32(values["NewDay"]);

            var userInfo = new UserInfo();
            userInfo.Username = values["NewUsername"];
            userInfo.FullName = values["NewFullName"];
            userInfo.MasterPassword = values["NewMasterPassword"];
            userInfo.DateOfBirth = new DateTime(dateYear, dateMonth, dateDay);
            userInfo.EmailAddress = values["NewEmail"];
            userInfo.DateCreated = DateTime.Now;

            rUserInfo.Add(userInfo);
            rUserInfo.Update();

            var alert = "New User has been created. Welcome to your Password Manager!";

            return RedirectToAction("Index", "Profile", new { userId = userInfo.UserId, notification = alert });
        }

    }
}
