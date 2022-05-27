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
        Item i = new Item();

        //On Page Load Generate Money Report for today
        public DataTable getAllItems()
        {
            return i.getAllItems();
        }
        public int createItem(string ItemName, string ItemType, double ItemPrice, string image)
        {
            return i.createItem(ItemName, ItemType, ItemPrice, image);
        }
        public int updateItem(string ItemName, string ItemType, double ItemPrice, string image)
        {
            return i.updateItem(ItemName, ItemType, ItemPrice, image);
        }
        public int deleteItem(string ItemName)
        {
            return i.deleteItem(ItemName);
        }
        public int searchItem(string ItemName)
        {
            return i.searchItem(ItemName);
        }
    }
}