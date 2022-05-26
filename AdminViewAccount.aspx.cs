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
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =|DataDirectory|\Database.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            string Email;

            if (!IsPostBack)
            {

                if (Session["UserID"] == null)

                {

                    Response.Redirect("UserLogin.aspx");
                }
                if (Session["role"].ToString() == "Admin")
                {
                    Email = Session["Email"].ToString();
                }
                else
                {
                    Response.Redirect("UserLogin.aspx");
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

        //protected void bindGridView()
        //{
        //    gvbll DDLAccount = new gvbll();
        //    DataSet ds;
        //    ds = DDLAccount.BindGridVw();
        //    ////ds = custorder.GetAllCO(ViewState["sorting"].ToString());
        //    DataTable dt = new DataTable();
        //    dt = ds.Tables[0];
        //    gvAccount.DataSource = dt;
        //    gvAccount.DataBind();
        //}

        protected void btn_AddAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAccount.aspx");
        }

        protected void FillGrid()
        {
            SqlCommand cmd = new SqlCommand("select * from UserRegister", con);
            con.Open();
            gvAccount.DataSource = cmd.ExecuteReader();
            gvAccount.DataBind();
            con.Close();
        }

        protected void gvAccount_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int UserID = Convert.ToInt32(gvAccount.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand("DELETE FROM UserRegister WHERE UserID =" + UserID, con);
            con.Open();
            int temp = cmd.ExecuteNonQuery();
            if (temp == 1)
            {
                lblMessage.Text = "Record DELETED successfully";
            }
            con.Close();
            FillGrid();
        }


        protected void gvAccount_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAccount.EditIndex = e.NewEditIndex;
            FillGrid();
        }

        protected void gvAccount_RowUpdating(object sender, GridViewUpdateEventArgs e)
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
            FillGrid();

        }
        protected void gvAccount_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAccount.EditIndex = -1;
            FillGrid();
        }


        protected void searchbtn_Click(object sender, EventArgs e)
        {
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
    }
}