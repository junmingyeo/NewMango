using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using RestaurantOwner.BLL;

namespace RestaurantOwner
{
    public partial class CartPage : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["MangoDB"].ConnectionString;
        int CustId;
        decimal totalPrice;
        int discount = 0;
        decimal discountPrice = 0;
        int itemNo = 1;
        int orderNo = 2;

        protected void Page_Load(object sender, EventArgs e)
        {
            CartController cartcontroller = new CartController();

            cartcontroller.deleteItem(itemNo);
            cartcontroller.submitOrder(orderNo);

            CustId = Convert.ToInt32(Session["CustID"]);
            if (!IsPostBack)
            {
                GVbind();
            }
        }

        protected void GVbind()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"Select i.ItemName, i.ItemPrice*t.quantity as price, t.quantity 
                                            FROM Item as i 
                                            inner join tblOrderItem as t on i.ItemID=t.tblItemID 
                                            inner join TableOrder as tt on t.tblOrderID=tt.OrderID 
                                            inner join Customer as c on c.CustID=tt.CustId
                                            where c.CustID= " + CustId, con);

                IDataReader dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);
                totalPrice = dt.Select().Sum(p => Convert.ToDecimal(p["price"]));
                Label8.Text = totalPrice.ToString();


                gvCart.DataSource = dt;
                gvCart.DataBind();
            }
        }

        protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string name = gvCart.DataKeys[e.RowIndex].Value.ToString();

            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd2 = new SqlCommand())
                {
                    cmd2.Connection = con;
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "delete t from tblOrderItem as t inner join Item as i on tblItemID=ItemID inner join TableOrder as tt on tblOrderID=OrderID inner join Customer c on c.CustID=tt.Custid WHERE ItemName= @ItemName and c.CustID= @CustID;";
                    cmd2.Parameters.AddWithValue("@ItemName", name);
                    cmd2.Parameters.AddWithValue("@CustID", CustId);


                    con.Open();

                    int t = cmd2.ExecuteNonQuery();
                    if (t > 0)
                    {
                        Response.Write("<script>alert('Item has been removed') </script>");
                        gvCart.EditIndex = -1;
                        GVbind();
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd3 = new SqlCommand())
                {
                    string myquery = "Select * from coupons where couponCode = '" + TextBox1.Text + "'";

                    cmd3.Connection = con;
                    cmd3.CommandText = myquery;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd3;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Label3.Text = "Coupon Code " + TextBox1.Text + " Applied Successfully!";
                        Label3.ForeColor = System.Drawing.Color.Green;

                        discount = Convert.ToInt32(ds.Tables[0].Rows[0]["discountPercentage"].ToString());

                        Label5.Text = discount.ToString() + "%";

                        totalPrice = Convert.ToDecimal(Label8.Text);

                        discountPrice = (totalPrice - totalPrice / 100 * discount);

                        Label8.Text = discountPrice.ToString("0.00");


                    }
                    else
                    {
                        Label3.Text = "Invalid Coupon Entered!";
                        Label3.ForeColor = System.Drawing.Color.Red;
                    }


                }
            }
        }

        protected void CheckOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaymentPage.aspx");
        }

        protected void ReturnToMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenuPage.aspx");
        }
    }
}