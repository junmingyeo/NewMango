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
            SqlCommand cmd5 = new SqlCommand();
            cmd5.Connection = conn;
            cmd5.CommandType = CommandType.Text;
            cmd5.CommandText = "SELECT * from TableOrder where  orderId= @orderId;";
            cmd5.Parameters.AddWithValue("@orderId", orderId);

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
    }
}