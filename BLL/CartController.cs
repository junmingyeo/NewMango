using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantOwner.DAL;
using System.Data;

namespace RestaurantOwner.BLL
{
    public class CartController
    {
        Cart cart = new Cart();

        public void deleteItem(int itemNo)
        {
            cart.updateCart(itemNo);
        }

        public void submitOrder(int orderNo)
        {
            cart.getOrderDetails(orderNo);
        }
    }
}