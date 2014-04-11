using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Res.Untility;
using StudentClassLibrary.Interfaces;
using StudentClassLibrary.Model;

namespace StudentClassLibrary.Repository
{
    public class RegistrationRepository : iCURD<Registration>
    {
        DataSet dsDataSet;

        SqlTransaction SelectConnection()
        {
            SqlTransaction transaction = null;
            transaction = GetSqlConnectionStringrestaurant();
            return transaction;
        }


        public SqlTransaction GetSqlConnectionStringrestaurant()
        {

            SqlTransaction transaction1 = DALDBConnection.SqlConnectionRes.BeginTransaction();
            return transaction1;
        }

        public Registration Read()
        {
            throw new NotImplementedException();
        }

        public List<Registration> ReadAll()
        {
            throw new NotImplementedException();
        }

        public DataSet ReadDataSet()
        {
            dsDataSet = new DataSet();

            SqlTransaction transaction = SelectConnection();

            try
            {
                string[] taleNames = new string[1];
                taleNames[0] = "tblData";

                SqlHelper.FillDataset(transaction, CommandType.StoredProcedure, "spGetRegistration", dsDataSet, taleNames);
                transaction.Commit();


            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;

            }

            return dsDataSet;
        }

        public void Create(List<Registration> model)
        {
            SqlTransaction transaction = SelectConnection();
            string result = string.Empty;
            try
            {
                foreach (Registration item in model)
                {

                    SqlParameter[] param = new SqlParameter[4];

                    param[0] = new SqlParameter("@Active", item.Active);
                    param[1] = new SqlParameter("@DOB", item.DOB);
                    param[2] = new SqlParameter("@GPA", item.GPA);
                    param[3] = new SqlParameter("@Name", item.Name);

                    int res = SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, "spAddRegistration", param);

                }
                transaction.Commit();

            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;

            }
        }

        public void Update(Registration model)
        {
            throw new NotImplementedException();
        }
    }
}
