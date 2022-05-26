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
        public int createCoupon(string couponCode, int discountPercentage)
        {
            StringBuilder sql;
            SqlCommand cmd;
            int result = 0;
            sql = new StringBuilder();
            sql.AppendLine("INSERT INTO coupons (couponCode, discountPercentage)");
            sql.AppendLine(" ");
            sql.AppendLine("VALUES (@couponCode, @discountPercentage)");
            SqlConnection conn = dbConnection.getConnection();
            try
            {
                cmd = new SqlCommand(sql.ToString(), conn);
                cmd.Parameters.AddWithValue("@couponCode", couponCode);
                cmd.Parameters.AddWithValue("@discountPercentage", discountPercentage);
                conn.Open();
                //result = dbConnection.executeNonQuery();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            return result;
        }



    }
}