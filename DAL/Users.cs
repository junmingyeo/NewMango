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
    public class Users
    {
        private String errMsg;
        //public string Email { get; set; }
        //public string Password { get; set; }
        DALDBConn dbConn = new DALDBConn();
        public DataSet staffLogin(String email, String password)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            DataSet ExchangeProgramsData = new DataSet();

            sql = new StringBuilder();
            sql.AppendLine("SELECT * FROM UserRegister");
            sql.AppendLine(" ");
            sql.AppendLine("WHERE email=@Email AND password=@Password");
            SqlConnection conn = dbConn.getConnection();
            try
            {
                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@Email", email);
                sqlCmd.Parameters.AddWithValue("@Password", password);
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
        public int staffRegistration(string Email, string FirstName, string LastName, string Password, string Role)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result = 0;

            sql = new StringBuilder();
            sql.AppendLine("INSERT INTO UserRegister (Email, FirstName, LastName, Password, Role)");
            sql.AppendLine(" ");
            sql.AppendLine("VALUES (@Email, @FirstName, @LastName, @Password, @Role)");
            SqlConnection conn = dbConn.getConnection();
            conn.Open();

            try
            {
                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@Email", Email);
                sqlCmd.Parameters.AddWithValue("@FirstName", FirstName);
                sqlCmd.Parameters.AddWithValue("@LastName", LastName);
                sqlCmd.Parameters.AddWithValue("@Password", Password);
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
        public DataSet profileDetails(int UserID)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            DataSet ExchangeProgramsData = new DataSet();

            sql = new StringBuilder();
            sql.AppendLine("SELECT * FROM UserRegister");
            sql.AppendLine(" ");
            sql.AppendLine("WHERE UserID=@UserID");
            SqlConnection conn = dbConn.getConnection();
            try
            {
                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@UserID", UserID);
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
        public DataSet adminResetPW()
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            DataSet ExchangeProgramsData = new DataSet();

            sql = new StringBuilder();
            sql.AppendLine("SELECT UserID, CONCAT(FirstName,' ', LastName) AS adminName FROM UserRegister");
            sql.AppendLine(" ");
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
        public int adminResetPWPassword(int UserID, string newPassword)
        {
            StringBuilder sql;
            SqlCommand sqlCmd;
            int result = 0;

            sql = new StringBuilder();
            sql.AppendLine("UPDATE UserRegister set password = @Password WHERE UserID = @UserID");
            sql.AppendLine(" ");
            SqlConnection conn = dbConn.getConnection();
            conn.Open();
            try
            {
                sqlCmd = new SqlCommand(sql.ToString(), conn);
                sqlCmd.Parameters.AddWithValue("@Password", newPassword);
                sqlCmd.Parameters.AddWithValue("@UserID", UserID);
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