using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantOwner.DAL;
using System.Data;

namespace RestaurantOwner.BLL
{
    public class MenuItemController
    {
        MenuItem mi = new MenuItem();
        Cart cart = new Cart();

        public void addSpecialRequest(string request)
        {
            mi.getSpecialRequestDetails(request);
        }

        public void changeInQuantity()
        {
            cart.updatedQuantity();
        }
    }
}