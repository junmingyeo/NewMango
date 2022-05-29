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
    public class GenTopItems
    {
        private String errMsg;
        DALDBConn dbConnection = new DALDBConn();

        public void getTopItems()
        {
            SqlConnection conn = dbConnection.getConnection();
            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = conn;
            cmd4.CommandType = CommandType.Text;
            cmd4.CommandText = "SELECT * from TableOrder where  orderId= @orderId;";
            cmd4.Parameters.AddWithValue("@orderId", 2);

            try
            {
                conn.Open();
            }

            finally
            {
                conn.Close();
            }
        }
        public void genDailyReport()
        {
        }

        public void genWeeklyReport()
        {

        }
        public void genMonthlyReport()
        {

        }
    }
}