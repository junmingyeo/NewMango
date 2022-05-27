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
    public class Item
    {
        private SqlConnection sqlConnection = new SqlConnection();
        private String errMsg;

        DALDBConn dbConnection = new DALDBConn();
        public DataTable getAllItems()
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataTable getAllItems;
            SqlConnection conn = dbConnection.getConnection();
            getAllItems = new DataTable();
            sql = new StringBuilder();
            sql.AppendLine("SELECT * from Item");
            conn.Open();

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.Fill(getAllItems);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return getAllItems;
        }

        //Create Coupons with Auto Generated ID
        public int createItem(string ItemName, string ItemType, double ItemPrice, string image)
        {
            StringBuilder sql;
            SqlCommand cmd;
            int result = 0;
            sql = new StringBuilder();
            sql.AppendLine("INSERT INTO item (ItemName, ItemType, ItemPrice, image)");
            sql.AppendLine(" ");
            sql.AppendLine("VALUES (@ItemName, @ItemType, @ItemPrice, @image)");
            SqlConnection conn = dbConnection.getConnection();
            try
            {
                cmd = new SqlCommand(sql.ToString(), conn);
                cmd.Parameters.AddWithValue("@ItemName", ItemName);
                cmd.Parameters.AddWithValue("@ItemType", ItemType);
                cmd.Parameters.AddWithValue("@ItemPrice", ItemPrice);
                cmd.Parameters.AddWithValue("@image", image);
                conn.Open();
                //result = dbConnection.executeNonQuery();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            return result;
        }
        public int updateItem(string ItemName, string ItemType, double ItemPrice, string image)
        {
            StringBuilder sql;
            SqlCommand cmd;
            int result = 0;
            sql = new StringBuilder();
            sql.AppendLine("UPDATE item (ItemName, ItemType, ItemPrice, image)");
            sql.AppendLine(" ");
            sql.AppendLine("SET (@couponCode, @discountPercentage)");
            sql.AppendLine(" ");
            sql.AppendLine("WHERE (@couponCode, @discountPercentage)");
            SqlConnection conn = dbConnection.getConnection();
            try
            {
                cmd = new SqlCommand(sql.ToString(), conn);
                cmd.Parameters.AddWithValue("@ItemName", ItemName);
                cmd.Parameters.AddWithValue("@ItemType", ItemType);
                cmd.Parameters.AddWithValue("@ItemPrice", ItemPrice);
                cmd.Parameters.AddWithValue("@image", image);
                conn.Open();
                //result = dbConnection.executeNonQuery();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            return result;
        }
        public int deleteItem(string ItemName)
        {
            StringBuilder sql;
            SqlCommand cmd;
            int result = 0;
            sql = new StringBuilder();
            sql.AppendLine("DELETE FROM Item");
            sql.AppendLine(" ");
            sql.AppendLine("WHERE ItemName=@ItemName");
            SqlConnection conn = dbConnection.getConnection();
            try
            {
                cmd = new SqlCommand(sql.ToString(), conn);
                cmd.Parameters.AddWithValue("@ItemName", ItemName);
                conn.Open();
                //result = dbConnection.executeNonQuery();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            return result;
        }
        public int searchItem(string ItemName)
        {
            StringBuilder sql;
            SqlCommand cmd;
            int result = 0;
            sql = new StringBuilder();
            sql.AppendLine("SELECT * FROM Item");
            sql.AppendLine(" ");
            sql.AppendLine("WHERE ItemName=@ItemName");
            SqlConnection conn = dbConnection.getConnection();
            try
            {
                cmd = new SqlCommand(sql.ToString(), conn);
                cmd.Parameters.AddWithValue("@ItemName", ItemName);
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