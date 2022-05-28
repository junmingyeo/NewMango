using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using RestaurantOwner.BLL;

namespace RestaurantOwner
{
    public partial class AddAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Email;
            if (!IsPostBack)
            {
                // DDLRoleBind();
                if (Session["UserID"] == null)

                {

                    Response.Redirect("LoginPage.aspx");
                }
                if (Session["role"].ToString() == "Admin")
                {
                    //DDLRoleBind();
                    Email = Session["Email"].ToString();
                    // DDLRoleBind();
                }
                else
                {
                    Response.Redirect("LoginPage.aspx");
                }
            }
        }

        protected void CreateAccount1()
        {
            UserController LC = new UserController();
            int DataSetResult;
            DataSetResult = LC.AddAccount(tb_Email.Text.ToString().Trim(), tb_FirstName.Text.ToString().Trim(), tb_LastName.Text.ToString().Trim(), tb_Password.Text.ToString().Trim(), ddl_Role.SelectedValue.ToString().Trim());
            if (DataSetResult > 0)
            {
                Response.Write("<script>alert('Registered successfully');window.location='AdminViewAccount.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('Registration not successful');</script>");
            }
        }

        protected void AdminViewAccount()
        {
            Response.Redirect("AdminViewAccount.aspx");
        }


        protected void btn_Create_Click(object sender, EventArgs e)
        {
            bool bValid = true;

            String REmail = tb_Email.Text;
            String RPassword = tb_Password.Text;
            String RConfirmPassword = tb_ConfirmPassword.Text;

            //check if password is is between 7 to 13 char
            if (!Validation.checkpassword(RPassword))
            {
                bValid = false;
                lblPassword.Text = "*Length must be 7 to 13.";

            }
            else lblPassword.Text = "";

            //check password and confirm password tally
            if (!Validation.checkconfirmPW(RPassword, RConfirmPassword))
            {
                bValid = false;
                lblConfirmPassword.Text = "*Different password is entered.";

            }

            else lblConfirmPassword.Text = "";


            //check for compulsory input
            if (this.tb_FirstName.Text == "")
            {
                lblFirstName.Text = "*First Name is required.";
                this.tb_FirstName.Focus();
                bValid = false;
            }
            else lblFirstName.Text = "";

            if (this.tb_LastName.Text == "")
            {
                lblLastName.Text = "*Last Name is required.";
                this.tb_LastName.Focus();
                bValid = false;
            }
            else lblLastName.Text = "";

            if (this.tb_Email.Text == "")
            {
                lblEmail.Text = "*Email is required.";
                this.tb_Email.Focus();
                bValid = false;
            }
            else lblEmail.Text = "";

            if (this.tb_Password.Text == "")
            {
                lblPassword.Text = "*Password is required.";
                this.tb_Password.Focus();
                bValid = false;
            }

            if (this.tb_ConfirmPassword.Text == "")
            {
                lblConfirmPassword.Text = "*Confirm Password is required.";
                bValid = false;
                this.tb_ConfirmPassword.Focus();
            }

            if (this.ddl_Role.SelectedValue == "Select")
            {
                lblRole.Text = "*Please select a Role.";
                this.lblRole.Focus();
            }

            else
            {
               
}
            if (bValid)
            {
                CreateAccount1();
                //LoginController LC = new LoginController();
                //int DataSetResult;
                //DataSetResult = LC.AddAccount(tb_Email.Text.ToString().Trim(), tb_FirstName.Text.ToString().Trim(), tb_LastName.Text.ToString().Trim(), tb_Password.Text.ToString().Trim(), ddl_Role.SelectedValue.ToString().Trim());
                //if (DataSetResult > 0)
                //{
                //    Response.Write("<script>alert('Registered successfully');window.location='AdminViewAccount.aspx';</script>");
                //}
                //else
                //{
                //    Response.Write("<script>alert('Registration not successful');</script>");
                //}
            }

        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            AdminViewAccount();
        }
    }
}