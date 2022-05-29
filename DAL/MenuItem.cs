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
    public class MenuItem
    {
        private String errMsg;
        DALDBConn dbConnection = new DALDBConn();

        public void getItemDetails(string name, double price, string desc)
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

        public void specialRequestAdded(string request)
        {
            SqlConnection conn = dbConnection.getConnection();
            SqlCommand cmd6 = new SqlCommand();
            cmd6.Connection = conn;
            cmd6.CommandType = CommandType.Text;
            cmd6.CommandText = "SELECT * from Item where ItemName = @ItemName;";
            cmd6.Parameters.AddWithValue("@ItemName", request);

            try
            {
                conn.Open();
            }

            finally
            {
                conn.Close();
            }
        }

        public void getSpecialRequestDetails(string request)
        {
            SqlConnection conn = dbConnection.getConnection();
            SqlCommand cmd7 = new SqlCommand();
            cmd7.Connection = conn;
            cmd7.CommandType = CommandType.Text;
            cmd7.CommandText = "SELECT * from Item where ItemName = @ItemName;";
            cmd7.Parameters.AddWithValue("@ItemName", request);

            try
            {
                conn.Open();
            }

            finally
            {
                conn.Close();
            }
        }

        public void getMenuItem()
        {
            SqlConnection conn = dbConnection.getConnection();
            SqlCommand cmd8 = new SqlCommand();
            cmd8.Connection = conn;
            cmd8.CommandType = CommandType.Text;
            cmd8.CommandText = "SELECT * from Item where ItemName = @ItemName;";
            cmd8.Parameters.AddWithValue("@ItemName", "item");

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
