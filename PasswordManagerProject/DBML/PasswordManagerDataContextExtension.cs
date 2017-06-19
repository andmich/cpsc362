using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace PasswordManagerProject.DBML
{
    public partial class PasswordManagerDBDataContext : System.Data.Linq.DataContext
    {                
        public DataLoadOptions GetDataOptions()
        {
            DataLoadOptions options = new DataLoadOptions();
            /*
            options.LoadWith<Account>(i => i.State);
            options.LoadWith<Account>(i => i.Package);
            options.LoadWith<Account>(i => i.AccountStatusType);
            options.LoadWith<Account>(i => i.PackageAgreement);
            options.LoadWith<AccountService>(i => i.AccountServiceType);
            options.LoadWith<CreditCard>(i => i.CreditCardType);
            options.LoadWith<Transaction>(i => i.TransactionType);
            */
            return options;
        }


        public int AccountNotes_GetByFiltersCount(List<Guid> statusTypeGuids, List<Guid> categoryGuids, List<Guid> subCategoryGuids, List<Guid> accountNoteGuids, List<Guid> sourceGuids,Guid? accountGuid, Guid? adminUserGuid, Guid? managerGuid,
                                                                 Guid? supportMgrGuid, Guid? salesRepGuid, Guid? assignToUserGuid, Guid? accountStatusGuid,
                                                                 Guid? packageTypeGuid, Guid? packageTierGuid, Guid? siteBrandGuid, Guid? resellerGuid, string keyword)
        {

            #region Create GuidList Tables

            var statusTypesTable = new DataTable();
            statusTypesTable.Columns.Add("GuidList", typeof(Guid));

            foreach (Guid e in statusTypeGuids)
            {
                statusTypesTable.Rows.Add(e);
            }

            var categoriesTable = new DataTable();
            categoriesTable.Columns.Add("GuidList", typeof(Guid));

            foreach (Guid e in categoryGuids)
            {
                categoriesTable.Rows.Add(e);
            }

            var subCategoriesTable = new DataTable();
            subCategoriesTable.Columns.Add("GuidList", typeof(Guid));

            foreach (Guid e in subCategoryGuids)
            {
                subCategoriesTable.Rows.Add(e);
            }

            var accountNotesTable = new DataTable();
            accountNotesTable.Columns.Add("GuidList", typeof(Guid));

            foreach (Guid e in accountNoteGuids)
            {
                accountNotesTable.Rows.Add(e);
            }

            var sourcesTable = new DataTable();
            sourcesTable.Columns.Add("GuidList", typeof(Guid));

            foreach (Guid e in sourceGuids)
            {
                sourcesTable.Rows.Add(e);
            }
            #endregion

            using (var conn = new SqlConnection(Connection.ConnectionString))
            {
                var cmd = new SqlCommand("AccountNotes_GetByFiltersCount", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                #region Add Parameters

                // StatusTypeGuids
                var p = cmd.Parameters.AddWithValue("@statusTypeGuids", statusTypesTable);
                p.SqlDbType = SqlDbType.Structured;
                p.TypeName = "GuidList";

                // CategoryGuids
                var p2 = cmd.Parameters.AddWithValue("@categoryGuids", categoriesTable);
                p2.SqlDbType = SqlDbType.Structured;
                p2.TypeName = "GuidList";

                // SubCategoryGuids
                var p3 = cmd.Parameters.AddWithValue("@subCategoryGuids", subCategoriesTable);
                p3.SqlDbType = SqlDbType.Structured;
                p3.TypeName = "GuidList";

                // AccountNoteGuids
                var p4 = cmd.Parameters.AddWithValue("@accountNoteGuids", accountNotesTable);
                p4.SqlDbType = SqlDbType.Structured;
                p4.TypeName = "GuidList";

                // AccountNoteSourceGuids
                var p5 = cmd.Parameters.AddWithValue("@sourceGuids", sourcesTable);
                p5.SqlDbType = SqlDbType.Structured;
                p5.TypeName = "GuidList";

                // AccountGUID
                cmd.Parameters.Add(AddGuidSqlParameter(accountGuid, "@accountGuid"));

                // AdminUserGUID
                cmd.Parameters.Add(AddGuidSqlParameter(adminUserGuid, "@adminUserGuid"));

                // ManagerGUID
                cmd.Parameters.Add(AddGuidSqlParameter(managerGuid, "@managerGuid"));

                // SupportMgrGUID
                cmd.Parameters.Add(AddGuidSqlParameter(supportMgrGuid, "@supportMgrGuid"));

                // SalesRepGUID
                cmd.Parameters.Add(AddGuidSqlParameter(salesRepGuid, "@salesRepGuid"));

                // AssignToUserGUID
                cmd.Parameters.Add(AddGuidSqlParameter(assignToUserGuid, "@assignToUserGuid"));

                // AccountStatusGUID
                cmd.Parameters.Add(AddGuidSqlParameter(accountStatusGuid, "@accountStatusGuid"));

                // PackageTypeGUID
                cmd.Parameters.Add(AddGuidSqlParameter(packageTypeGuid, "@packageTypeGuid"));

                // PackageTierGUID
                cmd.Parameters.Add(AddGuidSqlParameter(packageTierGuid, "@packageTierGuid"));

                // SiteBrandGUID
                cmd.Parameters.Add(AddGuidSqlParameter(siteBrandGuid, "@siteBrandGuid"));

                // ResellerGUID
                cmd.Parameters.Add(AddGuidSqlParameter(resellerGuid, "@resellerGuid"));

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    // Keyword
                    cmd.Parameters.Add(new SqlParameter("@keyword", keyword));
                }
                #endregion

                conn.Open();
                int result = Convert.ToInt32(cmd.ExecuteScalar());

                return result;
            }

           
        }


        [System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.SalesResidualExport_GetByFilters")]
        [System.Data.Linq.Mapping.ResultType(typeof(string))]
        [System.Data.Linq.Mapping.ResultType(typeof(string))]
        [System.Data.Linq.Mapping.ResultType(typeof(string))]
        public IMultipleResults GetSalesResidualTransaction(Guid salesRepGuid, DateTime startDate, DateTime endDate)
        {
            System.Data.Linq.IExecuteResult result = this.ExecuteMethodCall(this, ((System.Reflection.MethodInfo)(System.Reflection.MethodInfo.GetCurrentMethod())), salesRepGuid, startDate, endDate);
            return (IMultipleResults)(result.ReturnValue);
        }

        [System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.ResidualBilling_GetByDate")]
        [System.Data.Linq.Mapping.ResultType(typeof(string))]
        [System.Data.Linq.Mapping.ResultType(typeof(string))]
        [System.Data.Linq.Mapping.ResultType(typeof(string))]
        public IMultipleResults GetResidualBilling(DateTime startDate, DateTime endDate)
        {
            System.Data.Linq.IExecuteResult result = this.ExecuteMethodCall(this, ((System.Reflection.MethodInfo)(System.Reflection.MethodInfo.GetCurrentMethod())), startDate, endDate);
            return (IMultipleResults)(result.ReturnValue);
        }

        #region Add Guid SQL Parameter
        private SqlParameter AddGuidSqlParameter(Guid? param, string paramName)
        {
            var parameterGuid = new SqlParameter(paramName, DbType.Guid);
            parameterGuid.Value = param;

            if (param == null || param == Guid.Empty)
            {
                parameterGuid.Value = DBNull.Value;
            }
            else
            {
                parameterGuid.Value = param;
            }

            return parameterGuid;
        }
        #endregion

    }

}

