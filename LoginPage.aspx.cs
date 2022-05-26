using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using RestaurantOwner.BLL;

namespace RestaurantOwner
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                Session.Clear();
            }
        }

        protected void btn_SignIn_Click(object sender, EventArgs e)
        {

            bool bValid = true;

            if (this.tb_Email.Text == "")
            {
                lblEmail.Text = "*Email is required.";
                this.tb_Email.Focus();
                bValid = false;
            }
            else
            {
                lblEmail.Text = "";
            }

            if (this.tb_Password.Text == "")
            {
                lblPassword.Text = "*Password is required.";
                this.tb_Password.Focus();
                bValid = false;
            }
            else
            {
                lblPassword.Text = "";
            }

            if (bValid)
            {
                LoginController LC = new LoginController();
                DataSet DataSetResult;
                string email = tb_Email.Text;
                string password = tb_Password.Text;
                DataSetResult = LC.loginUser(email.Trim(), password.Trim());
                if (DataSetResult.Tables[0].Rows.Count > 0)
                {
                    Session["UserID"] = DataSetResult.Tables[0].Rows[0]["UserID"].ToString();
                    Session["Email"] = DataSetResult.Tables[0].Rows[0]["Email"].ToString();
                    Session["Name"] = DataSetResult.Tables[0].Rows[0]["FirstName"].ToString() + DataSetResult.Tables[0].Rows[0]["LastName"].ToString();
                    Session["Role"] = DataSetResult.Tables[0].Rows[0]["Role"].ToString();
                    Session["role"] = DataSetResult.Tables[0].Rows[0]["Role"].ToString();
                    if (Session["role"].ToString() == "Admin")
                    {
                        Response.Redirect("AdminPage.aspx");

                    }
                    else if (Session["role"].ToString() == "Restaurant Staff")
                    {
                        Response.Redirect("RestaurantStaffPage.aspx");

                    }
                    else if (Session["role"].ToString() == "Restaurant Owner")
                    {
                        Response.Redirect("RestaurantOwnerPage.aspx");

                    }
                    else if (Session["role"].ToString() == "Restaurant Manager")
                    {
                        Response.Redirect("RestaurantManagerPage.aspx");

                    }

                }

                else
                {

                    lblError.Text = "Invalid Email or Password! Please try again!";

                }
            }
        }
    }
}