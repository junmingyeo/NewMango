using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;

namespace RestaurantOwner.DAL
{
    public class DiscountCode
    {
        private String errMsg;
        DALDBConn dbConnection = new DALDBConn();

        public void getDiscountCode(string discountID)
        {
            SqlConnection conn = dbConnection.getConnection();
            SqlCommand cmd5 = new SqlCommand();
            cmd5.Connection = conn;
            cmd5.CommandType = CommandType.Text;
            cmd5.CommandText = "SELECT * from coupons where  couponCode= @couponCode;";
            cmd5.Parameters.AddWithValue("@couponCode", discountID);

            try
            {
                conn.Open();
            }

            finally
            {
                conn.Close();
            }
        }
    }
}