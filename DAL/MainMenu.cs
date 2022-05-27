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
    public class MainMenu
    {
        private String errMsg;
        DALDBConn dbConnection = new DALDBConn();

        public void getCustInfo(int TableNo)
        {
            SqlConnection conn = dbConnection.getConnection();
            SqlCommand cmd5 = new SqlCommand();
            cmd5.Connection = conn;
            cmd5.CommandType = CommandType.Text;
            cmd5.CommandText = "SELECT CustID, CustEmail, TableNo, DateOfVisit from Customer where TableNo = @TableNo;";
            cmd5.Parameters.AddWithValue("@TableNo", TableNo);

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