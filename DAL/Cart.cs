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
    public class Cart
    {
        private String errMsg;
        DALDBConn dbConnection = new DALDBConn();

        public void itemsAdded(string name, double price, string desc)
        {
            SqlConnection conn = dbConnection.getConnection();
            SqlCommand cmd5 = new SqlCommand();
            cmd5.Connection = conn;
            cmd5.CommandType = CommandType.Text;
            cmd5.CommandText = "SELECT * from Item where ItemName = @ItemName and ItemPrice=@ItemPrice;";
            cmd5.Parameters.AddWithValue("@ItemName", name);
            cmd5.Parameters.AddWithValue("@ItemName", price);
            try
            {
                conn.Open();
            }

            finally
            {
                conn.Close();
            }
        }

        public void updatedQuantity()
        {
            SqlConnection conn = dbConnection.getConnection();
            SqlCommand cmd6 = new SqlCommand();
            cmd6.Connection = conn;
            cmd6.CommandType = CommandType.Text;
            cmd6.CommandText = "SELECT * from Item;";
            try
            {
                conn.Open();
            }

            finally
            {
                conn.Close();
            }
        }

        public void updateCart(int itemNo)
        {
            SqlConnection conn = dbConnection.getConnection();
            SqlCommand cmd7 = new SqlCommand();
            cmd7.Connection = conn;
            cmd7.CommandType = CommandType.Text;
            cmd7.CommandText = "SELECT * from Item where ItemNo = @ItemNo;";
            cmd7.Parameters.AddWithValue("@ItemNo", itemNo);
            try
            {
                conn.Open();
            }

            finally
            {
                conn.Close();
            }

        }

        public void getOrderDetails(int orderNo)
        {
            SqlConnection conn = dbConnection.getConnection();
            SqlCommand cmd8 = new SqlCommand();
            cmd8.Connection = conn;
            cmd8.CommandType = CommandType.Text;
            cmd8.CommandText = "SELECT * from tblOrders where tblOrderID = @OrderID;";
            cmd8.Parameters.AddWithValue("@OrderID", orderNo);
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
