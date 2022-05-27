using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestaurantOwner.BLL;

namespace RestaurantOwner
{
    public partial class PaymentPage : System.Web.UI.Page
    {
        string email = "lolcats@gmail.com";
        protected void Page_Load(object sender, EventArgs e)
        {
            PaymentController paymentcontroller = new PaymentController();

            paymentcontroller.custEmail(email);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Completed.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CartPage.aspx");
        }
    }
}