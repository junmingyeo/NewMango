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
    public partial class AdminViewAccount : System.Web.UI.Page
    {

        UserController logindal = new UserController();

        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =|DataDirectory|\Database.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            string Email;

            if (!IsPostBack)
            {

                if (Session["UserID"] == null)

                {

                    Response.Redirect("LoginPage.aspx");
                }
                if (Session["role"].ToString() == "Admin")
                {
                    Email = Session["Email"].ToString();
                    bindGv();
                }
                else
                {
                    Response.Redirect("LoginPage.aspx");
                }
            }

            con.Open();
            string strCommandText = "SELECT * from UserRegister ORDER BY [Role]";
            SqlCommand cmd1 = new SqlCommand(strCommandText, con);
            SqlDataReader rdr = cmd1.ExecuteReader();
            gvAccount.DataSource = rdr;
            gvAccount.DataBind();
            lbl_gvCount.Text = gvAccount.Rows.Count.ToString();
            con.Close();
        }

        protected void btn_Backbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPage.aspx");
        }

        //3-tier
        private void bindGv()
        {
            DataSet ds;
            ds = logindal.getUsers();
            gvAccount.DataSource = ds;
            gvAccount.DataBind();
        }

        protected void displayUsers()
        {
            SqlCommand cmd = new SqlCommand("select * from UserRegister", con);
            con.Open();
            gvAccount.DataSource = cmd.ExecuteReader();
            gvAccount.DataBind();
            con.Close();
        }

        protected void suspendUserBtn(object sender, GridViewDeleteEventArgs e)
        {
            //3-tier
            int result = 0;
            int requestID = Convert.ToInt32(gvAccount.DataKeys[e.RowIndex].Value);
            result = logindal.SuspendUserAcc((requestID));
            if (result > 0)
            {
                Response.Write("<script>alert('Success');</script>");
            }
            else
            {
                Response.Write("<script>alert('NOT Success');</script>");
            }
            Response.Redirect("AdminViewAccount.aspx");

            //not 3-tier
            int UserID = Convert.ToInt32(gvAccount.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand("DELETE FROM UserRegister WHERE UserID =" + UserID, con);
            con.Open();
            int temp = cmd.ExecuteNonQuery();
            if (temp == 1)
            {
                lblMessage.Text = "Record DELETED successfully";
            }
            con.Close();
            displayUsers();
        }


        protected void gvAccount_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAccount.EditIndex = e.NewEditIndex;
            displayUsers();
        }

        protected void updateUserBtn(object sender, GridViewUpdateEventArgs e)
        {
            int index = gvAccount.EditIndex;
            GridViewRow row = gvAccount.Rows[index];
            int UserID = Convert.ToInt32(gvAccount.DataKeys[e.RowIndex].Value);
            string Email = ((TextBox)row.Cells[1].Controls[0]).Text.ToString().Trim();
            string FirstName = ((TextBox)row.Cells[2].Controls[0]).Text.ToString().Trim();
            string LastName = ((TextBox)row.Cells[3].Controls[0]).Text.ToString().Trim();
            string Password = ((TextBox)row.Cells[4].Controls[0]).Text.ToString().Trim();
            string Role = ((TextBox)row.Cells[5].Controls[0]).Text.ToString().Trim();

            string sql = "UPDATE UserRegister SET Email='" + Email + "',FirstName='" + FirstName + "',LastName='" + LastName + "',Password='" + Password + "',Role='" + Role + "' WHERE UserID=" + UserID + "";

            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            int temp = cmd.ExecuteNonQuery();
            con.Close();
            if (temp == 1)
            {

                lblMessage.Text = "Record UPDATED successfully";
            }
            gvAccount.EditIndex = -1;
            displayUsers();

        }
        protected void gvAccount_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAccount.EditIndex = -1;
            displayUsers();
        }


        protected void searchbtn_Click(object sender, EventArgs e)
        {
            ////3-tier
            //DataSet ds;
            //ds = logindal.SearchUserAcc(txtsearch.Text);
            //gvAccount.DataSource = ds;
            //gvAccount.DataBind();

            //not 3-tier
            string mainconn = ConfigurationManager.ConnectionStrings["MangoDB"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            sqlconn.Open();
            SqlCommand sqlCmd = new SqlCommand();
            string sqlquery = "SELECT * FROM [dbo].[UserRegister] WHERE FirstName like '%'+@FirstName+'%'";
            sqlCmd.CommandText = sqlquery;
            sqlCmd.Connection = sqlconn;
            sqlCmd.Parameters.AddWithValue("FirstName", txtsearch.Text);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
            sda.Fill(dt);
            gvAccount.DataSource = dt;
            gvAccount.DataBind();
        }

        protected void btn_AddAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAccount.aspx");
        }
    }
}