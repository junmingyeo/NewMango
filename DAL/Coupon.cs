using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Configuration;
using System.Text;

namespace RestaurantOwner.DAL
{
    public class Coupon
    {
        private SqlConnection sqlConnection = new SqlConnection();
        private String errMsg;

        DALDBConn dbConnection = new DALDBConn();
        public DataTable getAllCoupons()
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataTable getAllCoupons;
            SqlConnection conn = dbConnection.getConnection();
            getAllCoupons = new DataTable();
            sql = new StringBuilder();
            sql.AppendLine("SELECT * from coupons");
            conn.Open();

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.Fill(getAllCoupons);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return getAllCoupons;
        }

        //Create Coupons with Auto Generated ID
        public bool createCoupon(string couponCode, string discountPercentage)
        {
            try
            {
                string sqlStatement = @"INSERT INTO coupons (couponCode, discountPercentage) "
                + "VALUES (@couponCode, @discountPercentage) ";

                SqlCommand cmd = new SqlCommand(sqlStatement);
                cmd.Parameters.AddWithValue("@couponCode", couponCode);
                cmd.Parameters.AddWithValue("@discountPercentage", discountPercentage);

                bool success = dbConnection.executeNonQuery(cmd);

                return success;
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }



    }
}