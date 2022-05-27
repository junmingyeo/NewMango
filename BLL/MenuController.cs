using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantOwner.DAL;
using System.Data;

namespace RestaurantOwner.BLL
{
    public class MenuController
    {
        MenuDisplay menudisplay = new MenuDisplay();
        Cart cart = new Cart();

        public DataTable DisplayMenu()
        {
            return menudisplay.getMenu();
        }

        public void addItemtoCart(string name, double price, string desc)
        {
            cart.itemsAdded(name, price, desc);
        }
    }
}