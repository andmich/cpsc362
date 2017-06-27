using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PasswordManagerProject.DBML;
using PasswordManagerProject.Models;
using PasswordManagerProject.Interface;

namespace PasswordManagerProject.Controllers
{
    public class PasswordController : Controller
    {
        #region Edit Function
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
        #endregion

        // This should be [POST]. NOTE: Master Password should be passed to this function.
        [HttpPost, ValidateInput(false)]
        public ActionResult AddPassword(FormCollection values)
        {
            var rUserInfo = new UserInfoRepository();
            var userInfo = rUserInfo.GetByUserId(Convert.ToInt32(values["UID"]));

            // Create the crypto function based on the users Master Password.
            PasswordCrypt userCrypt = new PasswordCrypt(userInfo.MasterPassword);

            var rPassword = new PasswordInfoRepository();
            var passwordToAdd = new PasswordInfo();

            // Create new PasswordInfo object and pass user parameters into it.
            passwordToAdd.Password = userCrypt.encryptPassword(values["password"]);
            passwordToAdd.Username = values["username"];
            passwordToAdd.SecurityAnswer = values["securityAnswer"];
            passwordToAdd.UserId = Convert.ToInt32(values["UID"]);
            passwordToAdd.LabelType = values["label"];
            
            passwordToAdd.DateCreated = DateTime.Now;

            //Update the database.
            rPassword.Add(passwordToAdd);
            rPassword.Update();

            var alert = "New Password has been saved!";

            // Return back to the profile page Index.
            return RedirectToAction("Index", "Profile", new { userId = passwordToAdd.UserId, notification = alert });
        }

        // This function should be [POST]
        public ActionResult RemovePassword(FormCollection values)
        {
            // Search for the password to delete.
            var rPassword = new PasswordInfoRepository();
            var passWordToRemove = rPassword.GetByPasswordId(Convert.ToInt32(values["passwordIdToRemove"]));

            // Delete the password and update DB.
            rPassword.Delete(passWordToRemove);
            rPassword.Update();

            var alert = "Password has been removed";

            // Return back to the profile page Index.
            return RedirectToAction("Index", "Profile", new { userId = passWordToRemove.UserId, notification = alert });
        }

        // This function should be [POST]. NOTE: Master Password should be passed to this function.
        [HttpPost]
        public ActionResult EditPassword(int UID, int passID, string passwordChange)
        {
            var rUserInfo = new UserInfoRepository();
            var userInfo = rUserInfo.GetByUserId(UID);

            // User cryptographic function.
            PasswordCrypt userCrypt = new PasswordCrypt(userInfo.MasterPassword);

            // Search for the password to edit.
            var rPassword = new PasswordInfoRepository();
            var passwordToEdit = rPassword.GetByPasswordId(passID);

            // Assign the new password change.
            passwordToEdit.Password = userCrypt.encryptPassword(passwordChange);

            // Edit the password and update DB.
            rPassword.Update();

            // Return back to the Profile Index page.
            return RedirectToAction("Index", "Profile", new { userId = UID });
        }

        [HttpPost]
        public ActionResult EditAdditionalInfo(FormCollection values)
        {
            // Search for the password to edit the label.
            var rPassword = new PasswordInfoRepository();
            var passwordToEdit = rPassword.GetByPasswordId(Convert.ToInt32(values["passId"]));

            // Assign new values
            passwordToEdit.Username = values["username"];
            passwordToEdit.SecurityAnswer = values["securityAnswer"];
            passwordToEdit.LabelType = values["label"];

            // Update DB.
            rPassword.Update();

            var alert = "Additional Info has been updated!";

            // Return back to the Profile Index page.
            return RedirectToAction("Index", "Profile", new { userId = passwordToEdit.UserId, notification = alert });
        }

        // Get the plaintext version of the password. NOTE: Master Password should be passed to this function.
        public string GetPassword(int UID, int passID)
        {

            var rUserInfo = new UserInfoRepository();
            var userInfo = rUserInfo.GetByUserId(UID);

            // Used to store the plain text of the password.
            string plainTextPass = "";

            // User cryptographic function.
            var userCrypt = new PasswordCrypt(userInfo.MasterPassword);

            // Get the password to return.
            var rPassword = new PasswordInfoRepository();
            var passwordToReturn = rPassword.GetByPasswordId(passID);

            // Decrypt the password.
            plainTextPass = userCrypt.decryptPassword(passwordToReturn.Password);

            return plainTextPass;
        }

        #region Password Generator Implementation
        //Lowercase letters to be used in generation
        private static char[] lower = { 'a','b','c','d','e','f','g','h',
                                        'i','j','k','l','m','n','o','p',
                                        'q','r','s','t','u','v','w','x',
                                        'y','z'};

        //Uppercase letters to be used in generation
        private static char[] upper = { 'A','B','C','D','E','F','G','H',
                                        'I','J','K','L','M','N','O','P',
                                        'Q','R','S','T','U','V','W','X',
                                        'Y','Z'};

        //Numbers to be used in generation  
        private static char[] num = { '1','2','3','4','5','6','7','8',
                                      '9','0'};

        //Symbols to be used in generation                        
        private static char[] sym = { '!','@','#','$','%','^','&','*',
                                      '(',')'};

        /*Uses a random number generator to decide which char[] 
        array to use in generating a random password until there 
        are 8 charact++8ers in the password*/
        public static string PasswordGenerator()
        {
            Random rand = new Random();
            int arrays = rand.Next(0, 4);
            int letters;
            int numSym;
            int length = 0;
            string pass = "";

            //Loop generates password automatically until password length is met
            do
            {
                if (arrays == 0)
                {
                    letters = rand.Next(0, 25);//Generate Random number
                    pass += lower[(int)letters];//Concatenate the string
                    length++;
                }
                else if (arrays == 1)
                {
                    letters = rand.Next(0, 25);
                    pass += upper[(int)letters];
                    length++;
                }
                else if (arrays == 2)
                {
                    numSym = rand.Next(0, 9);
                    pass += num[(int)numSym];
                    length++;
                }
                else if (arrays == 3)
                {
                    numSym = rand.Next(0, 9);
                    pass += sym[(int)numSym];
                    length++;
                }
                arrays = rand.Next(0, 4);
            } while (length < 8);
            return pass;
        }
        #endregion

        #region Ajax Calls
        #region Generate Password
        public ActionResult GeneratePassword()
        {
            var password = PasswordGenerator();

            return Json(password);
        }
        #endregion

        public ActionResult ViewPassword(int userId, string masterPassword, int passId)
        {
            var rUserInfo = new UserInfoRepository();
            var userInfo = rUserInfo.GetByUserId(userId);

            if (userInfo.MasterPassword == masterPassword)
            {
                var rPasswordInfo = new PasswordInfoRepository();
                var passwordInfo = rPasswordInfo.GetByPasswordId(passId);

                return Json("Your Password is: " + GetPassword(userInfo.UserId, passwordInfo.PasswordId));
            }

            return Json("Wrong Password. Please Try Again.");
        }

        #endregion
    }
}
