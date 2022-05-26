using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace RestaurantOwner
{
    public partial class ViewUserProfile : System.Web.UI.Page
    {
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

        //protected void bind()
        //{
        //    List<Tradep> tradepList = new List<Tradep>();
        //    tradepList = aTrad.getTradepAll();
        //    gvTradep.DataSource = tradepList;
        //    gvTradep.DataBind();
        //}
        protected void FillGrid()
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
        //protected void FillGrid()
        //{
        //    SqlCommand cmd = new SqlCommand("SELECT * FROM UserRegister", con);
        //    con.Open();
        //    gvUserProfile.DataSource = cmd.ExecuteReader();
        //    gvUserProfile.DataBind();
        //    con.Close();
        //}

        protected void gvUserProfile_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int RoleID = Convert.ToInt32(gvUserProfile.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand("DELETE FROM UserRole WHERE RoleID =" + RoleID, con);
            con.Open();
            int temp = cmd.ExecuteNonQuery();
            if (temp == 1)
            {
                lblMessage.Text = "Record DELETED successfully";
            }
            con.Close();
            FillGrid();
        }


        protected void gvUserProfile_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUserProfile.EditIndex = e.NewEditIndex;
            FillGrid();
        }

        protected void gvUserProfile_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = gvUserProfile.EditIndex;
            GridViewRow row = gvUserProfile.Rows[index];
            int RoleID = Convert.ToInt32(gvUserProfile.DataKeys[e.RowIndex].Value);
            string Role = ((TextBox)row.Cells[4].Controls[0]).Text.ToString().Trim();

            string sql = "UPDATE UserRegister SET Role='" + Role + "' WHERE RoleID=" + RoleID + "";


            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            int temp = cmd.ExecuteNonQuery();
            con.Close();
            if (temp == 1)
            {

                lblMessage.Text = "Record UPDATED successfully";
            }
            gvUserProfile.EditIndex = -1;
            FillGrid();

        }
        protected void gvUserProfile_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUserProfile.EditIndex = -1;
            FillGrid();
        }


        protected void searchUPbtn_Click(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MangoDB"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            sqlconn.Open();
            SqlCommand sqlCmd = new SqlCommand();
            string sqlquery = "SELECT * FROM [dbo].[UserRegister] WHERE Role like '%'+@Role+'%'";
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