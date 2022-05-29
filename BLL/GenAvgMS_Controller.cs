using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantOwner.DAL;
using System.Data;

namespace RestaurantOwner.BLL
{
    public class GenAvgMS_Controller
    {
        GenAvgMS GR = new GenAvgMS();

        public DataTable calAvgReport(DateTime Date)
        {
            return GR.calAvgSpent(Date);
        }
        public DataTable genDailyReport()
        {
            DateTime tdy = DateTime.Today;
            return GR.genDailyReport();
        }

        public DataTable genWeeklyReport(DateTime Date)
        {
            DateTime tdy = DateTime.Today;
            return GR.genWeeklyReport(Date);
        }

        public DataTable genMonthlyReport(DateTime Date)
        {
            return GR.genMonthlyReport(Date);
        }
    }
}