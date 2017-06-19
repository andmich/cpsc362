using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PasswordManagerProject.Interface;
using PasswordManagerProject.DBML;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Linq;

namespace PasswordManagerProject.DBML
{
    public class PasswordInfoRepository : IModelBase<PasswordInfo>
    {
        private PasswordManagerDBDataContext db;

        public PasswordInfoRepository()
        {
            db = new PasswordManagerDBDataContext("Server=tcp:pass123.database.windows.net,1433;Initial Catalog=pass123db;Persist Security Info=False;User ID=cpsc362;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            db.LoadOptions = db.GetDataOptions();
        }
        public PasswordInfoRepository(string connectionString)
        {
            db = new PasswordManagerDBDataContext(connectionString);
            db.LoadOptions = db.GetDataOptions();
        }


        #region IModelBase<BusinessLocation> Members

        public IQueryable<PasswordInfo> GetAllClassObjects()
        {
            throw new NotImplementedException();
        }

        public PasswordInfo GetSingleClassObjectByClassRef(int id)
        {
            return db.PasswordInfos.SingleOrDefault(b => b.PasswordId == id);
        }

        public PasswordInfo GetSingleClassObjectByClassRef(Guid guid)
        {
            throw new NotImplementedException();
        }

        public void Add(PasswordInfo __class)
        {
            if (__class.UserId == null)
            {
                __class.UserId = 1;
            }

            db.PasswordInfos.InsertOnSubmit(__class);
        }

        public void Delete(PasswordInfo __class)
        {
            db.PasswordInfos.DeleteOnSubmit(__class);
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

        public PasswordInfo GetByPasswordId(int id)
        {
            return db.PasswordInfos.SingleOrDefault(x => x.PasswordId == id);
        }

        public IQueryable<PasswordInfo> GetByUserId(int id)
        {
            return db.PasswordInfos.Where(x => x.UserId == id);
        }


    }
}
