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
    public class GenAvgMS
    {
        private SqlConnection conn = new SqlConnection();
        private String errMsg;

        DALDBConn dbConnection = new DALDBConn();

        public DataTable calAvgSpent(DateTime Date)
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataTable dayMoneyReport;
            SqlConnection conn = dbConnection.getConnection();
            dayMoneyReport = new DataTable();
            sql = new StringBuilder();
            sql.AppendLine("SELECT Customer.Date, AVG(Item.ItemPrice * tblOrderItem.quantity) as AmtSpent, Count(tblOrderItem.quantity) as NoOfOrders FROM ((Customer");
            sql.AppendLine(" ");
            sql.AppendLine("INNER JOIN TableOrder ON Customer.CustID = TableOrder.CustId)");
            sql.AppendLine(" ");
            sql.AppendLine("INNER JOIN tblOrderItem ON TableOrder.orderId = tblOrderItem.tblOrderID)");
            sql.AppendLine(" ");
            sql.AppendLine("INNER JOIN Item ON tblOrderItem.tblItemID = Item.ItemID");
            sql.AppendLine(" ");
            sql.AppendLine("WHERE Customer.Date = @Date");
            sql.AppendLine(" ");
            sql.AppendLine("GROUP BY Customer.Date");
            conn.Open();

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.SelectCommand.Parameters.AddWithValue("@Date", Date);
                da.Fill(dayMoneyReport);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return dayMoneyReport;

        }

        public void getAvgSpent()
        {
        }
        public DataTable genDailyReport()
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataTable todayMoneyReport;
            DateTime tdy = DateTime.Today;
            SqlConnection conn = dbConnection.getConnection();
            todayMoneyReport = new DataTable();
            sql = new StringBuilder();
            sql.AppendLine("SELECT Customer.Date AS Date, AVG(Item.ItemPrice * tblOrderItem.quantity) AS AmtSpent, COUNT(tblOrderItem.quantity) as NoOfOrders, SUM(Item.ItemPrice * tblOrderItem.quantity) AS AmtTotal FROM Customer");
            sql.AppendLine(" ");
            sql.AppendLine("INNER JOIN TableOrder ON Customer.CustID = TableOrder.CustId");
            sql.AppendLine(" ");
            sql.AppendLine("INNER JOIN tblOrderItem ON TableOrder.orderId = tblOrderItem.tblOrderID");
            sql.AppendLine(" ");
            sql.AppendLine("INNER JOIN Item ON tblOrderItem.tblItemID = Item.ItemID");
            sql.AppendLine(" ");
            sql.AppendLine("WHERE Customer.Date = @tdy");
            sql.AppendLine(" ");
            sql.AppendLine("GROUP BY Customer.Date");
            conn.Open();

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.SelectCommand.Parameters.AddWithValue("@tdy", tdy);
                da.Fill(todayMoneyReport);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return todayMoneyReport;
        }

        public DataTable genWeeklyReport(DateTime Date)
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataTable weekMoneyReport;
            SqlConnection conn = dbConnection.getConnection();
            weekMoneyReport = new DataTable();
            sql = new StringBuilder();
            sql.AppendLine("SELECT Customer.Date, AVG(Item.ItemPrice * tblOrderItem.quantity) as AmtSpent, Count(tblOrderItem.quantity) as NoOfOrders FROM ((Customer");
            sql.AppendLine(" ");
            sql.AppendLine("INNER JOIN TableOrder ON Customer.CustID = TableOrder.CustId)");
            sql.AppendLine(" ");
            sql.AppendLine("INNER JOIN tblOrderItem ON TableOrder.orderId = tblOrderItem.tblOrderID)");
            sql.AppendLine(" ");
            sql.AppendLine("INNER JOIN Item ON tblOrderItem.tblItemID = Item.ItemID");
            sql.AppendLine(" ");
            sql.AppendLine("WHERE Customer.Date BETWEEN @Date and DATEADD(Day, 7, @Date)");
            sql.AppendLine(" ");
            sql.AppendLine("GROUP BY Customer.Date");
            conn.Open();

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.SelectCommand.Parameters.AddWithValue("@Date", Date);
                da.Fill(weekMoneyReport);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return weekMoneyReport;

        }

        public DataTable genMonthlyReport(DateTime Date)
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataTable monthMoneyReport;
            SqlConnection conn = dbConnection.getConnection();
            monthMoneyReport = new DataTable();
            sql = new StringBuilder();
            sql.AppendLine("SELECT Customer.Date, AVG(Item.ItemPrice * tblOrderItem.quantity) as AmtSpent, Count(tblOrderItem.quantity) as NoOfOrders FROM ((Customer");
            sql.AppendLine(" ");
            sql.AppendLine("INNER JOIN TableOrder ON Customer.CustID = TableOrder.CustId)");
            sql.AppendLine(" ");
            sql.AppendLine("INNER JOIN tblOrderItem ON TableOrder.orderId = tblOrderItem.tblOrderID)");
            sql.AppendLine(" ");
            sql.AppendLine("INNER JOIN Item ON tblOrderItem.tblItemID = Item.ItemID");
            sql.AppendLine(" ");
            sql.AppendLine("WHERE Customer.Date BETWEEN @Date and DATEADD(Day, 30, @Date)");
            sql.AppendLine(" ");
            sql.AppendLine("GROUP BY Customer.Date");
            conn.Open();

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.SelectCommand.Parameters.AddWithValue("@Date", Date);
                da.Fill(monthMoneyReport);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return monthMoneyReport;

        }
    }
}