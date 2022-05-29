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
    public partial class ViewUserProfile : System.Web.UI.Page
    {
        ProfileController profilelist = new ProfileController();
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
                    getProfiles();
                }
                else
                {
                    Response.Redirect("LoginPage.aspx");
                }
            }

            con.Open();
            string strCommandText = "SELECT * FROM UserRole";
            SqlCommand cmd1 = new SqlCommand(strCommandText, con);
            SqlDataReader rdr = cmd1.ExecuteReader();
            gvUserProfile.DataSource = rdr;
            gvUserProfile.DataBind();
            lbl_up_gvCount.Text = gvUserProfile.Rows.Count.ToString();
            con.Close();

        }

        //3-tier
        private void getProfiles()
        {
            DataSet ds;
            ds = profilelist.ViewRoles();
            gvUserProfile.DataSource = ds;
            gvUserProfile.DataBind();
        }

        protected void displayProfiles()
        {
            SqlCommand cmd = new SqlCommand("select * from UserRole", con);
            con.Open();
            gvUserProfile.DataSource = cmd.ExecuteReader();
            gvUserProfile.DataBind();
            con.Close();
        }

        protected void btn_AddUserProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateUserProfile.aspx");
        }

        protected void suspendProfileBtn(object sender, GridViewDeleteEventArgs e)
        {
            //3-tier
            int result = 0;
            string requestID = gvUserProfile.DataKeys[e.RowIndex].Value.ToString();
            result = profilelist.SuspendRole(int.Parse(requestID));
            if (result > 0)
            {
                Response.Write("<script>alert('Success');</script>");
            }
            else
            {
                Response.Write("<script>alert('NOT Success');</script>");
            }
            Response.Redirect("ViewUserProfile.aspx");

            //not 3-tier
            int RoleID = Convert.ToInt32(gvUserProfile.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand("DELETE FROM UserRole WHERE RoleID =" + RoleID, con);
            con.Open();
            int temp = cmd.ExecuteNonQuery();
            if (temp == 1)
            {
                lblMessage.Text = "Record DELETED successfully";
            }
            con.Close();
            displayProfiles();
        }


        protected void gvUserProfile_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUserProfile.EditIndex = e.NewEditIndex;
            displayProfiles();
        }

        
        protected void updateProfileBtn(object sender, GridViewUpdateEventArgs e)
        {
            //3-tier

            
            //not 3-tier
            int index = gvUserProfile.EditIndex;
            GridViewRow row = gvUserProfile.Rows[index];
            int RoleID = Convert.ToInt32(gvUserProfile.DataKeys[e.RowIndex].Value);
            string Role = ((TextBox)row.Cells[1].Controls[0]).Text.ToString().Trim();

            string sql = "UPDATE UserRole SET Role='" + Role + "' WHERE RoleID=" + RoleID + "";

            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            int temp = cmd.ExecuteNonQuery();
            con.Close();
            if (temp == 1)
            {

                lblMessage.Text = "Record UPDATED successfully";
            }
            gvUserProfile.EditIndex = -1;
            displayProfiles();

        }
        protected void gvUserProfile_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUserProfile.EditIndex = -1;
            displayProfiles();
        }


        protected void searchUPbtn_Click(object sender, EventArgs e)
        {
            //3-tier
            DataSet ds;
            ds = profilelist.SearchRole(txtUPsearch.Text);
            gvUserProfile.DataSource = ds;
            gvUserProfile.DataBind();

            //not 3-tier
            string mainconn = ConfigurationManager.ConnectionStrings["MangoDB"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            sqlconn.Open();
            SqlCommand sqlCmd = new SqlCommand();
            string sqlquery = "SELECT * FROM [dbo].[UserRole] WHERE Role like '%'+@Role+'%'";
            sqlCmd.CommandText = sqlquery;
            sqlCmd.Connection = sqlconn;
            sqlCmd.Parameters.AddWithValue("Role", txtUPsearch.Text);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
            sda.Fill(dt);
            gvUserProfile.DataSource = dt;
            gvUserProfile.DataBind();
        }
    }
}