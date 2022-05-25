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
    public partial class GenerateReport1 : System.Web.UI.Page
    {
        GenerateSpending_Controller GR = new GenerateSpending_Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGridView();
            }


        }

        protected void bindGridView()
        {
            //DataSet ds = GR.TodayMoneyReport();
            //gvMoneySpent.DataSource = ds;
            //gvMoneySpent.DataBind();
            //DataTable dt = ds.Tables[0];
            //if (dt.Rows.Count == 0)
            //{
            //    
            //}
            DataTable dt = GR.GetTodayMoneyReport();
            //if (dt == null)
            //{
            //    //redirectToErrorPg("Error retrieving case logs.");
            //    return;
            //}

            gvMoneySpent.DataSource = dt;
            gvMoneySpent.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindGridView();
        }
    }
}