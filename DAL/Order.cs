using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Text;

namespace RestaurantOwner.DAL
{
    public class Order
    {
        private String errMsg;
        DALDBConn dbConnection = new DALDBConn();

        public void getOrder(int orderId)
        {
            SqlConnection conn = dbConnection.getConnection();
            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = conn;
            cmd4.CommandType = CommandType.Text;
            cmd4.CommandText = "SELECT * from TableOrder where  orderId= @orderId;";
            cmd4.Parameters.AddWithValue("@orderId", orderId);

            try
            {
                conn.Open();
            }

            finally
            {
                conn.Close();
            }
        }

        public void getOrderDetails()
        {
            SqlConnection conn = dbConnection.getConnection();
            SqlCommand cmd5 = new SqlCommand();
            cmd5.Connection = conn;
            cmd5.CommandType = CommandType.Text;
            cmd5.CommandText = "SELECT * from TableOrder where  orderId= @orderId;";
            cmd5.Parameters.AddWithValue("@orderId", "23");

            try
            {
                conn.Open();
            }

            finally
            {
                conn.Close();
            }
        }

        public void applyDiscountCode(string couponCode)
        {
            SqlConnection conn = dbConnection.getConnection();
            SqlCommand cmd6 = new SqlCommand();
            cmd6.Connection = conn;
            cmd6.CommandType = CommandType.Text;
            cmd6.CommandText = "SELECT * from coupons where  couponCode= @couponCode;";
            cmd6.Parameters.AddWithValue("@couponCode", "20OFF");

            try
            {
                conn.Open();
            }

            finally
            {
                conn.Close();
            }
        }

        public void getTableNo()
        {
            SqlConnection conn = dbConnection.getConnection();
            SqlCommand cmd7 = new SqlCommand();
            cmd7.Connection = conn;
            cmd7.CommandType = CommandType.Text;
            cmd7.CommandText = "SELECT * from Customer where  TableNo= @TableNo;";
            cmd7.Parameters.AddWithValue("@TableNo", 4);

            try
            {
                conn.Open();
            }

            finally
            {
                conn.Close();
            }
        }
        public void getCheckedItem()
        {
            SqlConnection conn = dbConnection.getConnection();
            SqlCommand cmd8 = new SqlCommand();
            cmd8.Connection = conn;
            cmd8.CommandType = CommandType.Text;
            cmd8.CommandText = "SELECT * from TableOrder where  orderId= @orderId;";
            cmd8.Parameters.AddWithValue("@orderId", "23");

            try
            {
                conn.Open();
            }

            finally
            {
                conn.Close();
            }
        }

        public void getOrderSpecialRequest()
        {
            SqlConnection conn = dbConnection.getConnection();
            SqlCommand cmd9 = new SqlCommand();
            cmd9.Connection = conn;
            cmd9.CommandType = CommandType.Text;
            cmd9.CommandText = "SELECT specialOrder from tblOrderItem where  orderId= @orderId;";
            cmd9.Parameters.AddWithValue("@orderId", "23");

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

