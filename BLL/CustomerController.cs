using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantOwner.DAL;
using System.Data;


namespace RestaurantOwner.BLL
{
    public class CustomerController
    {
        MainMenu mm = new MainMenu();
        public void custInfo(int TableNo)
        {
            mm.getCustInfo(TableNo);
        }
    }
}