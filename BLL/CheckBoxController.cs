using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using RestaurantOwner.DAL;

namespace RestaurantOwner.BLL
{
    public class CheckBoxController
    {
        Order o = new Order();
        public void getCheckedItem()
        {
            o.getCheckedItem();
        }
    }
}

