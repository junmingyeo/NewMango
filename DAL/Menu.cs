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
    public class Menu
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

        public int itemCreated(string name, decimal price, string desc)
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
                cmd.Parameters.AddWithValue("@ItemName", name);
                cmd.Parameters.AddWithValue("@ItemType", price);
                cmd.Parameters.AddWithValue("@ItemPrice", desc);
                //cmd.Parameters.AddWithValue("@image", image);
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