using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PasswordManagerProject.Interface;
using PasswordManagerProject.DBML;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Linq;


namespace PasswordManagerProject.DBML
{
    public class UserInfoRepository : IModelBase<UserInfo>
    {
        private PasswordManagerDBDataContext db;

        public UserInfoRepository()
        {
            db = new PasswordManagerDBDataContext("Server=tcp:pass123.database.windows.net,1433;Initial Catalog=pass123db;Persist Security Info=False;User ID=cpsc362;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            db.LoadOptions = db.GetDataOptions();
        }
        public UserInfoRepository(string connectionString)
        {
            db = new PasswordManagerDBDataContext(connectionString);
            db.LoadOptions = db.GetDataOptions();
        }


        #region IModelBase<BusinessLocation> Members

        public IQueryable<UserInfo> GetAllClassObjects()
        {
            throw new NotImplementedException();
        }

        public UserInfo GetSingleClassObjectByClassRef(int id)
        {
            return db.UserInfos.SingleOrDefault(b => b.UserId == id);
        }

        public UserInfo GetSingleClassObjectByClassRef(Guid guid)
        {
            throw new NotImplementedException();
        }

        public void Add(UserInfo __class)
        {
            if (__class.UserId == null)
            {
                __class.UserId = 1;
            }

            db.UserInfos.InsertOnSubmit(__class);
        }

        public void Delete(UserInfo __class)
        {
            db.UserInfos.DeleteOnSubmit(__class);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            db.SubmitChanges();
        }

        #endregion

        // search for a user that has matching UserId
        public UserInfo GetByUserId(int id)
        {
            return db.UserInfos.SingleOrDefault(b => b.UserId == id);
        }

        // given a username and password, the data base will try to find a row that matches
        // if no match is found it'll return null
        public UserInfo GetByUserNameAndPassword(string username, string password)
        {
            return db.UserInfos.SingleOrDefault(x => x.Username == username && x.MasterPassword == password);
        }

    }
}