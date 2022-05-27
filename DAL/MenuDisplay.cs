using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Text;

namespace RestaurantOwner.DAL
{
    public class MenuDisplay
    {
        private String errMsg;
        DALDBConn dbConnection = new DALDBConn();

        public DataTable getMenu()
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataTable ViewMenu;
            SqlConnection conn = dbConnection.getConnection();
            ViewMenu = new DataTable();
            sql = new StringBuilder();
            sql.AppendLine("SELECT * from Item");
            conn.Open();

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.Fill(ViewMenu);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return ViewMenu;
        }
    }
}