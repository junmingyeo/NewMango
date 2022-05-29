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
    public partial class CreateOrderPage : System.Web.UI.Page
    {
        CreateOrderController coc = new CreateOrderController();
        protected void Page_Load(object sender, EventArgs e)
        {
            coc.getMenuItem();
        }
    }
}