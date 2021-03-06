using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

using RestaurantOwner.BLL;

namespace RestaurantOwner
{
    public partial class GenerateMoneySpent : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["MangoDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GVbind();
            }

        }

        protected void GVbind()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"Select c.CustEmail, CAST(avg(i.ItemPrice* t.quantity) as decimal(10,2)) as averageSpending
                                                FROM Item as i 
                                                inner join tblOrderItem as t on i.ItemID=t.tblItemID 
                                                inner join TableOrder as tt on t.tblOrderID=tt.OrderID 
                                                inner join Customer as c on c.CustID=tt.CustId
                                                group by CustEmail", con);

                IDataReader dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);


                gvCart.DataSource = dt;
                gvCart.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RestaurantOwnerPage.aspx");
        }
    }
}