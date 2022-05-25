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

        //On Page Load Generate Money Report for today
        public DataTable GetTodayMoneyReport()
        {
            DateTime tdy = DateTime.Today;

            return GR.GetTodayMoneyReport();
        }

        //Generate Money Report
        public DataTable GenerateDayMoneyReport(DateTime Date)
        {
            return GR.getDayMoneyReport(Date);
        }
    }
}