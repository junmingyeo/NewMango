using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using RestaurantOwner.BLL;

namespace RestaurantOwner
{
    public partial class MainMenuPage : System.Web.UI.Page
    {
        MenuController menucontroller = new MenuController();

        ItemController itemcontroller = new ItemController();

        protected void Page_Load(object sender, EventArgs e)
        {
            string itemName = "Pizza";
            double price = 2.99;
            string desc = "Cheesy";
            bindGridView();

            itemcontroller.viewItemDetails(itemName, price, desc);
            menucontroller.addItemtoCart(itemName, price, desc);
        }

        protected void bindGridView()
        {
            DataTable dt = menucontroller.DisplayMenu();
            rpt.DataSource = dt;
            rpt.DataBind();
        }

        protected void Cart_Click(object sender, EventArgs e)
        {
            Response.Redirect("CartPage.aspx");
        }
    }
}