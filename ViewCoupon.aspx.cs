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
    public partial class ViewCoupon : System.Web.UI.Page
    {
        Coupon_Controller cc = new Coupon_Controller();
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
        String abc = ConfigurationManager.ConnectionStrings["MangoDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GVbind();
            }
        }
        protected void GVbind()
        {
            DataTable dt = cc.getAllCoupons();

            couponTableGV.DataSource = dt;
            couponTableGV.DataBind();
        }
        protected void couponSubmitbt_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into coupons values('" + couponCode.Text + "','" + discountPercentage.Text + "')";
            int t = cmd.ExecuteNonQuery();
            if (t > 0)
            {
                Response.Write("<script>alert('Coupon has been added successfully')</script>");
                conn.Close();
                GVbind();
            }
        }
        protected void couponTableGV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void couponTableGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string rdf = couponTableGV.DataKeys[e.RowIndex].Value.ToString();
            using (SqlConnection conn = new SqlConnection(abc))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM coupons WHERE couponCode='" + rdf + "'", conn);
                int t = cmd.ExecuteNonQuery();
                if (t > 0)
                {
                    Response.Write("<script>alert('Coupon has been deleted')</script>");
                    couponTableGV.EditIndex = -1;
                    GVbind();
                }
                conn.Close();
            }
        }

        protected void couponTableGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            couponTableGV.EditIndex = e.NewEditIndex;
            GVbind();
        }

        protected void couponTableGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string text = couponTableGV.DataKeys[e.RowIndex].Value.ToString();
            string coupon = ((TextBox)couponTableGV.Rows[e.RowIndex].Cells[0].Controls[0]).Text;
            string discount = ((TextBox)couponTableGV.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            using (SqlConnection conn = new SqlConnection(abc))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update coupons set couponCode='" + coupon + "',discountPercentage='" + discount + "'where couponCode='" + text + "' ", conn);
                int t = cmd.ExecuteNonQuery();
                if (t > 0)
                {
                    Response.Write("<script>alert('Coupon has been updated')</script>");
                    couponTableGV.EditIndex = -1;
                    GVbind();
                }
            }
        }

        protected void couponTableGV_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            couponTableGV.EditIndex = -1;
            GVbind();
        }
    }
}