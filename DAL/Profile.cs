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
    public class Profile
    {
        private String errMsg;
        DALDBConn dbConn = new DALDBConn();

        public int createProfile(string Role, string FunctionAccess)
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
                sqlCmd.Parameters.AddWithValue("@Role", Role);
                sqlCmd.Parameters.AddWithValue("@FunctionAccess", FunctionAccess);
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

        public DataSet viewProfiles()
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            DataSet ExchangeProgramsData = new DataSet();

            sql = new StringBuilder();
            sql.AppendLine("SELECT * FROM UserRole");
            SqlConnection conn = dbConn.getConnection();
            try
            {
                sqlCmd = new SqlCommand(sql.ToString(), conn);
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

        public int updateProfile(int RoleID, string Role)
        {

            StringBuilder sql;
            SqlCommand sqlCmd;
            int result;

            result = 0;

            sql = new StringBuilder();
            sql.AppendLine("UPDATE UserRegister");
            sql.AppendLine(" ");
            sql.AppendLine("SET Role = @Role");
            sql.AppendLine(" ");
            sql.AppendLine("WHERE RoleID=@RoleID");
            SqlConnection conn = dbConn.getConnection();
            conn.Open();
            try
            {
                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@RoleID", RoleID);
                sqlCmd.Parameters.AddWithValue("@Role", Role);
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
        public DataSet searchProfile(string Role)
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet programData;

            SqlConnection conn = dbConn.getConnection();
            programData = new DataSet();
            sql = new StringBuilder();
            sql.AppendLine("SELECT * From UserRegister WHERE Role LIKE '%'+@Role+'%'");
            conn.Open();

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.SelectCommand.Parameters.AddWithValue("@Role", Role);
                da.Fill(programData);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return programData;
        }
        public int suspendProfile(int RoleID)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result;

            result = 0;

            sql = new StringBuilder();
            sql.AppendLine("DELETE FROM UserRole WHERE RoleID=@RoleID");
            sql.AppendLine(" ");
            SqlConnection conn = dbConn.getConnection();
            conn.Open();

            try
            {
                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@RoleID", RoleID);
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