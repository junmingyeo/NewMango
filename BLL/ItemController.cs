using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantOwner.DAL;
using System.Data;

namespace RestaurantOwner.BLL
{
    public class ItemController
    {
        Menu m = new Menu();
        MenuItem mi = new MenuItem();
        Cart cart = new Cart();

        //On Page Load Generate Money Report for today
        public DataTable getAllItems()
        {
            return m.getAllItems();
        }

        public int createItem(string name, decimal price, string desc)
        {
            return m.itemCreated(name, price, desc);
        }

        public void viewItemDetails(string name, double price, string desc)
        {
            mi.getItemDetails(name, price, desc);
        }

        public void addItemtoCart(string name, double price, string desc)
        {
            cart.itemsAdded(name, price, desc);
        }
    }
}