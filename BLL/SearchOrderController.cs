using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using RestaurantOwner.DAL;

namespace RestaurantOwner.BLL
{
    public class SearchOrderController
    {
        Order o = new Order();
        int orderID;
        
        public void validateTableNo()
        {
            o.getTableNo();
            o.getOrder(orderID);
            o.getOrderDetails();
        }
    }
}