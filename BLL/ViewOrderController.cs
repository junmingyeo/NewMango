﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantOwner.DAL;
using System.Data;

namespace RestaurantOwner.BLL
{
    public class ViewOrderController
    {
        Order o = new Order();
        public void viewOrder(int orderID)
        {
            o.getOrder(orderID);
            o.getOrderDetails();
            o.getOrderSpecialRequest();
        }
    }
}