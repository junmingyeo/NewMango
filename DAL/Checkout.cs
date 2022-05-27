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
    public class Checkout
    {
        private String errMsg;
        DALDBConn dbConnection = new DALDBConn();

        public void makePayment()
        {
            SqlConnection conn = dbConnection.getConnection();
            SqlCommand cmd5 = new SqlCommand();
            cmd5.Connection = conn;
            cmd5.CommandType = CommandType.Text;
            cmd5.CommandText = "SELECT * from Item;";

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