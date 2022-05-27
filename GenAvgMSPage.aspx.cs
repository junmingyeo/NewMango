using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RestaurantOwner.BLL;

namespace RestaurantOwner
{
    public partial class GenerateMoneySpent : System.Web.UI.Page
    {
        GenAvgMS_Controller GR = new GenAvgMS_Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGridView();
            }
            
           
        }

        protected void bindGridView()
        {
            
            DataTable dt = GR.GetTodayMoneyReport();

            gvMoneySpent.DataSource = dt;
            gvMoneySpent.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindGridView();
        }

    }
}