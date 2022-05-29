using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using RestaurantOwner.DAL;

namespace RestaurantOwner.BLL
{
    public class GenTopItems_Controller
    {
        GenTopItems gti = new GenTopItems();
        public void genDailyReport()
        {
            gti.getTopItems();
            gti.genDailyReport();
        }

        public void genWeeklyReport()
        {
            gti.getTopItems();
            gti.genWeeklyReport();
        }

        public void genMonthlyReport()
        {
            gti.getTopItems();
            gti.genMonthlyReport();
        }
    }
}