using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace RestaurantOwner.DAL
{
    public class Role
    {
        private String errMsg;
        DALDBConn dbConn = new DALDBConn();

        public int CreateRole(string nRole, string gFunction)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result = 0;

            sql = new StringBuilder();
            sql.AppendLine("INSERT INTO UserRole (Role, FunctionAccess)");
            sql.AppendLine(" ");
            sql.AppendLine("VALUES (@Role, @FunctionAccess)");
            SqlConnection conn = dbConn.getConnection();
            conn.Open();

            try
            {
                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@Role", nRole);
                sqlCmd.Parameters.AddWithValue("@FunctionAccess", gFunction);
                result = sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        //for select later
        public DataSet RoleDetails(int RoleID)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            DataSet ExchangeProgramsData = new DataSet();

            sql = new StringBuilder();
            sql.AppendLine("SELECT * FROM UserRole");
            sql.AppendLine(" ");
            sql.AppendLine("WHERE RoleID=@RoleID");
            SqlConnection conn = dbConn.getConnection();
            try
            {
                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@RoleID", RoleID);
                //SqlDataReader dr = sqlCmd.ExecuteReader();
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);

                da.Fill(ExchangeProgramsData);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return ExchangeProgramsData;
        }
        public DataSet BindDDLRole()
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            DataSet RoleData = new DataSet();

            sql = new StringBuilder();
            sql.AppendLine("SELECT Role FROM UserRole");
            sql.AppendLine(" ");
            //sql.AppendLine("WHERE RoleID=@RoleID");
            SqlConnection conn = dbConn.getConnection();
            try
            {
                sqlCmd = new SqlCommand(sql.ToString(), conn);
                //sqlCmd.Parameters.AddWithValue("@Role", Role);
                //SqlDataReader dr = sqlCmd.ExecuteReader();
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);

                da.Fill(RoleData);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return RoleData;
        }

        public int Newrole(string newrole, string functionaccess)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result = 0;

            sql = new StringBuilder();
            sql.AppendLine("INSERT INTO UserRole (Role, Function)");
            sql.AppendLine(" ");
            sql.AppendLine("VALUES (@Role, @Function)"); ;
            SqlConnection conn = dbConn.getConnection();
            conn.Open();
            try
            {
                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@Role", newrole);
                sqlCmd.Parameters.AddWithValue("@Function", functionaccess);
                result = sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }
    }
}