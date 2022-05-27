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
    public partial class CustomerPage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security = True");
        CustomerController customer_controller = new CustomerController();

        string date = DateTime.Now.ToString("dd-MM-yyyy");
  

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void displayMenu(object sender, EventArgs e)
        {
            string email = TextBox1.Text;
            int TableNo = Convert.ToInt32(TextBox2.Text);

            customer_controller.custInfo(TableNo);

            SqlCommand cmd = new SqlCommand("insert into Customer values (@CustEmail, @TableNo, @DateOfVisit)");

            try
            {
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("CustEmail", TextBox1.Text);
                cmd.Parameters.AddWithValue("TableNo", TextBox2.Text);
                cmd.Parameters.AddWithValue("DateOfVisit", date);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            finally
            {
                con.Close();
            }

            using (SqlConnection CS = new SqlConnection(ConfigurationManager.ConnectionStrings["MangoDB"].ConnectionString))
            {
                using (SqlCommand cmd2 = new SqlCommand())
                {
                    cmd2.Connection = CS;
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "SELECT CustID, CustEmail, TableNo, DateOfVisit from Customer where CustEmail = @CustEmail;";
                    cmd2.Parameters.AddWithValue("@CustEmail", email);


                    CS.Open();
                    SqlDataReader dr = cmd2.ExecuteReader();

                    if (dr.Read())
                    {
                        Session["CustID"] = dr["CustID"].ToString();
                        Session["CustEmail"] = dr["CustEmail"].ToString();
                        Session["TableNo"] = dr["TableNo"].ToString();
                        Session["DateOfVisit"] = dr["DateOfVisit"].ToString();
                    }
                    else
                    {
                        Session["CustID"] = "";
                        Session["CustEmail"] = "";
                        Session["TableNo"] = "";
                        Session["DateOfVisit"] = "";
                    }
                }
            }
            Response.Redirect("MainMenuPage.aspx");

        }
    }
}