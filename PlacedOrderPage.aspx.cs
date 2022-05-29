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
    public partial class PlacedOrderPage : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["MangoDB"].ConnectionString;
        ViewOrderController voc = new ViewOrderController();
        DiscountCodeController doc = new DiscountCodeController();
        SearchOrderController soc = new SearchOrderController();
        CheckBoxController cbc = new CheckBoxController();

        protected void Page_Load(object sender, EventArgs e)
        {
            voc.viewOrder(2);
            doc.validateDiscountCode("20OFF");
            soc.validateTableNo();
            cbc.getCheckedItem();

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

                SqlCommand cmd = new SqlCommand(@"Select i.ItemName, t.specialOrder, t.served, t.quantity, t.tblOrderID, t.served, c.TableNo
                                            FROM Item as i 
                                            inner join tblOrderItem as t on i.ItemID=t.tblItemID 
                                            inner join TableOrder as tt on t.tblOrderID=tt.OrderID 
                                            inner join Customer as c on c.CustID=tt.CustId", con);

                IDataReader dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);


                gvCart.DataSource = dt;
                gvCart.DataBind();
            }
        }

        protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string name = gvCart.DataKeys[e.RowIndex].Values[0].ToString();
            int orderNum = Convert.ToInt32(gvCart.DataKeys[e.RowIndex].Values[1].ToString());
            string served = gvCart.DataKeys[e.RowIndex].Values[2].ToString();

            if (served == "")
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    using (SqlCommand cmd2 = new SqlCommand())
                    {
                        cmd2.Connection = con;
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "update tblOrderItem set served = 'Served' from tblOrderItem as t inner join Item as i on tblItemID=ItemID inner join TableOrder as tt on tblOrderID=OrderID inner join Customer c on c.CustID=tt.Custid WHERE ItemName= @ItemName AND tblOrderID= @tblOrderID;";
                        cmd2.Parameters.AddWithValue("@ItemName", name);
                        cmd2.Parameters.AddWithValue("@tblOrderID", orderNum);

                        con.Open();

                        int t = cmd2.ExecuteNonQuery();
                        if (t > 0)
                        {
                            Response.Write("<script>alert('Order has been served') </script>");
                            GVbind();
                        }
                    }
                }

            }
            else
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    using (SqlCommand cmd2 = new SqlCommand())
                    {
                        cmd2.Connection = con;
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "update tblOrderItem set served = '' from tblOrderItem as t inner join Item as i on tblItemID=ItemID inner join TableOrder as tt on tblOrderID=OrderID inner join Customer c on c.CustID=tt.Custid WHERE ItemName= @ItemName AND tblOrderID= @tblOrderID;";
                        cmd2.Parameters.AddWithValue("@ItemName", name);
                        cmd2.Parameters.AddWithValue("@tblOrderID", orderNum);

                        con.Open();

                        int t = cmd2.ExecuteNonQuery();
                        if (t > 0)
                        {
                            Response.Write("<script>alert('Order has been served') </script>");
                            GVbind();
                        }


                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RestaurantStaffPage.aspx");
        }
    }
}