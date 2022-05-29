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
    public class GenFreqVisit
    {

        private SqlConnection conn = new SqlConnection();
        private String errMsg;

        DALDBConn dbConnection = new DALDBConn();

        public DataTable calFreq(DateTime Date)
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataTable calFreqReport;
            SqlConnection conn = dbConnection.getConnection();
            calFreqReport = new DataTable();
            sql = new StringBuilder();
            sql.AppendFormat("Select c.CustEmail, count(tt.orderId) as NumOfVisit FROM Item as i inner join tblOrderItem as t on i.ItemID = t.tblItemID inner join TableOrder as tt on t.tblOrderID = tt.OrderID inner join Customer as c on c.CustID = tt.CustId group by c.CustEmail order by NumOfVisit desc", conn);

            conn.Open();

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.SelectCommand.Parameters.AddWithValue("@Date", Date);
                da.Fill(calFreqReport);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return calFreqReport;

        }

        public void getFreq()
        {
        }

        public DataTable genDailyReport()
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataTable todayFreqReport;
            DateTime tdy = DateTime.Today;
            SqlConnection conn = dbConnection.getConnection();
            todayFreqReport = new DataTable();
            sql = new StringBuilder();

            sql.AppendFormat("Select c.CustEmail, CAST(avg(i.ItemPrice* t.quantity) as decimal(10,2)) as averageSpending from item as i inner join tblorderitem as t on i.itemid = t.tblitemid inner join tableorder as tt on t.tblorderid = tt.orderid inner join customer as c on c.custid = tt.custid WHERE Customer.Date = @tdy group by custemail", conn);
            conn.Open();

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.SelectCommand.Parameters.AddWithValue("@tdy", tdy);
                da.Fill(todayFreqReport);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return todayFreqReport;
        }

        public DataTable genWeeklyReport(DateTime Date)
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataTable weekFreqReport;
            SqlConnection conn = dbConnection.getConnection();
            weekFreqReport = new DataTable();
            sql = new StringBuilder();
            sql.AppendFormat("Select c.CustEmail, CAST(avg(i.ItemPrice* t.quantity) as decimal(10,2)) as averageSpending from item as i inner join tblorderitem as t on i.itemid = t.tblitemid inner join tableorder as tt on t.tblorderid = tt.orderid inner join customer as c on c.custid = tt.custid WHERE Customer.Date BETWEEN @Date and DATEADD(Day, 7, @Date) group by custemail", conn);
            conn.Open();

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.SelectCommand.Parameters.AddWithValue("@Date", Date);
                da.Fill(weekFreqReport);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return weekFreqReport;

        }

        public DataTable genMonthlyReport(DateTime Date)
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataTable monthFreqReport;
            SqlConnection conn = dbConnection.getConnection();
            monthFreqReport = new DataTable();
            sql = new StringBuilder();
            sql.AppendFormat("Select c.CustEmail, CAST(avg(i.ItemPrice* t.quantity) as decimal(10,2)) as averageSpending from item as i inner join tblorderitem as t on i.itemid = t.tblitemid inner join tableorder as tt on t.tblorderid = tt.orderid inner join customer as c on c.custid = tt.custid WHERE Customer.Date BETWEEN @Date and DATEADD(Day, 30, @Date) group by custemail", conn);
            conn.Open();

            try
            {
                da = new SqlDataAdapter(sql.ToString(), conn);
                da.SelectCommand.Parameters.AddWithValue("@Date", Date);
                da.Fill(monthFreqReport);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return monthFreqReport;

        }
    }
}