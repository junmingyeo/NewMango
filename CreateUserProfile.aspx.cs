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
    public partial class CreateUserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool bValid;

            if (this.UP_tb.Text == "")
            {
                lblUserProfile.Text = "*Role Name is required.";
                this.UP_tb.Focus();
                bValid = false;
            }
            else lblUserProfile.Text = "";

            if (this.Access_DDL.SelectedValue == "Select")
            {
                lblAccessDDL.Text = "*Please Grant the Access to the Role.";
                this.lblAccessDDL.Focus();
            }

            else
            {
            }
        }
        protected void AdminViewAccount()
        {
            Response.Write("<script>alert('Account created successfully');window.location='ViewUserProfile.aspx';</script>");
        }

        protected void AddUPBtn_Click(object sender, EventArgs e)
        {
            ProfileController roleDetails = new ProfileController();
            int RoleResult;
            RoleResult = roleDetails.AddProfile(UP_tb.Text.ToString().Trim(), Access_DDL.SelectedValue.ToString().Trim());
            if (RoleResult > 0)
            {
                AdminViewAccount();
            }
            else
            {
                Response.Write("<script>alert('Account creation fail');</script>");
            }

        }
    }
}