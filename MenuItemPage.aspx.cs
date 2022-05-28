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
    public partial class MenuItemPage : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["MangoDB"].ConnectionString;
        int id;
        int CustId;
        string request = "no cheese";
        string specialO;

        protected void Page_Load(object sender, EventArgs e)
        {
            MenuItemController menuitemcontroller = new MenuItemController();
            menuitemcontroller.addSpecialRequest(request);
            menuitemcontroller.changeInQuantity();

            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("MainMenuPage.aspx");
            }

            else
            {
                id = Convert.ToInt32(Request.QueryString["id"].ToString());
                DataTable dt = getData("select * from Item where ItemID = " + id);

                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }
        private DataTable getData(String query)
        {
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }
        protected void btnBuy_Click(object sender, EventArgs e)
        {

            if (Session["CustID"] == null)
            {
                Response.Redirect("CustomerPage.aspx");
            }
            else
            {
                CustId = Convert.ToInt32(Session["CustID"]);
                DataTable dtOrder = getData("select * from TableOrder where CustId = " + CustId);

                if (dtOrder.Rows.Count > 0)
                {
                    DataRow drOrder = dtOrder.Rows[0];
                    DataTable dtOrderItem = getData("select * from tblOrderItem where tblOrderID = " + Convert.ToInt32(drOrder["OrderID"].ToString()) + " and " + " tblItemID = " + id);

                    if (dtOrderItem.Rows.Count > 0)
                    {
                        insertData("update tblOrderItem set quantity = quantity + 1 where tblItemID = " + id + "and tblOrderID = " + Convert.ToInt32(drOrder["OrderID"].ToString()));
                    }
                    else
                    {
                        addOrderItem(drOrder["OrderID"].ToString(), drOrder["CustId"].ToString());
                    }
                }
                else if (dtOrder.Rows.Count == 0)
                {
                    insertData("insert into TableOrder (CustId) values (" + CustId + ")");
                    DataTable newOrder = getData("select * from TableOrder where CustId = " + CustId);
                    DataRow newOrderRow = newOrder.Rows[0];

                    addOrderItem(newOrderRow["OrderID"].ToString(), newOrderRow["CustId"].ToString());
                }
            }

            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Item added to cart');window.location='MenuItemPage.aspx';</script>'");

        }
        private void addOrderItem(string OrderID, string userId)
        {
            specialO = specialOrders.Text;
            //string query = "insert into tblOrderItem (tblItemID, tblOrderID, quantity, specialOrder) values (" + id + "," + OrderID + "," + 1 + " , "+ specialO +")";
            string query = "insert into tblOrderItem (tblItemID, tblOrderID, quantity, specialOrder) values (@tblItemID, @tblOrderID, @quantity, @specialOrder)";
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@tblItemID", id);
                cmd.Parameters.AddWithValue("@tblOrderID", OrderID);
                cmd.Parameters.AddWithValue("@quantity", 1);
                cmd.Parameters.AddWithValue("@specialOrder", specialO);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void insertData(string query)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenuPage.aspx");
        }
    }
}