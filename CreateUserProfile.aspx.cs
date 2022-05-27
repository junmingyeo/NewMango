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

            //   String REmail = tb_Email.Text;
            //  String RPassword = tb_Password.Text;
            //String RConfirmPassword = tb_ConfirmPassword.Text;

            //check if password is is between 7 to 13 char
            //if (!Validation.checkpassword(RPassword))
            //{
            //    bValid = false;
            //    lblPassword.Text = "*Length must be 7 to 13.";

            //}
            //else lblPassword.Text = "";

            ////check password and confirm password tally
            //if (!Validation.checkconfirmPW(RPassword, RConfirmPassword))
            //{
            //    bValid = false;
            //    lblConfirmPassword.Text = "*Different password is entered.";

            //}

            //else lblConfirmPassword.Text = "";


            //check for compulsory input
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
                //  lblRole.Text = "";
                //  SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MangoDB"].ConnectionString);
                // string strCommandText = "SELECT Email from UserRegister WHERE Email=@Email";
                // SqlCommand cmd1 = new SqlCommand(strCommandText, con);
                //  cmd1.Parameters.AddWithValue("@Email", tb_Email.Text);
                // con.Open();

                // SqlDataReader reader = cmd1.ExecuteReader();



                //  while (reader.Read())
                // {
                //     String Email = reader["Email"].ToString();

                //    if (tb_Email.Text == Email)
                //    {
                //        bValid = false;
                //        lblEmail.Text = "*Email already exist.";
                //  }
                // else
                //{
                //  lblEmail.Text = "";
                //}

            }
        }

        protected void AddUPBtn_Click(object sender, EventArgs e)
        {
            ProfileController roleDetails = new ProfileController();
            int RoleResult;
            RoleResult = roleDetails.RegisterRole(UP_tb.Text.ToString().Trim(), Access_DDL.SelectedValue.ToString().Trim());
            if (RoleResult > 0)
            {
                Response.Write("<script>alert('Registered successfully');window.location='ViewUserProfile.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('Registration not successful');</script>");
            }

        }
    }
}