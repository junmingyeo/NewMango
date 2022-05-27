using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using System.Text;
using RestaurantOwner.BLL;

namespace RestaurantOwner
{
    public partial class CreateItem : System.Web.UI.Page
    {
        ItemController ic = new ItemController();
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
        String abc = ConfigurationManager.ConnectionStrings["MangoDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                displayItemCreated();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            FileUpload1.SaveAs(Server.MapPath("~/images/") + FileUpload1.FileName);
            //SqlCommand cmd = new SqlCommand("Insert into Item values (@ItemName, @ItemType, @ItemPrice)");

            //int price = Convert.ToInt32(TextBox3.Text);
            cmd.CommandType = System.Data.CommandType.Text;
            string jkl = FileUpload1.FileName.ToString();
            string imgPath = "~/images/" + jkl;
            cmd.CommandText = "Insert into Item values('" + itemName.Text + "','" + ddl_ItemType.Text + "','" + itemPrice.Text + "','" + imgPath.ToString() + "')";
            int t = cmd.ExecuteNonQuery();
            if (t > 0)
            {
                Response.Write("<script>alert('Item has been added successfully')</script>");
                con.Close();
                displayItemCreated();
            }
            clear();
        }
        protected void displayItemCreated()
        {
            DataTable dt = ic.getAllItems();

            itemGV.DataSource = dt;
            itemGV.DataBind();
        }
        void clear()
        {
            itemName.Text = "";
            itemPrice.Text = "";
        }

        protected void itemGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            itemGV.EditIndex = e.NewEditIndex;
            displayItemCreated();
        }

        protected void itemGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(itemGV.DataKeys[e.RowIndex].Value.ToString());
            string ItemName = ((TextBox)itemGV.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string ItemType = ((DropDownList)itemGV.Rows[e.RowIndex].Cells[2].FindControl("DropDownList1")).Text;
            string ItemPrice = ((TextBox)itemGV.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            Image image = (Image)itemGV.Rows[e.RowIndex].FindControl("imgupload");
            Label label = new Label();
            label.Text = image.ToString();
            FileUpload FileUpload1 = (FileUpload)itemGV.Rows[e.RowIndex].FindControl("FileUpload1");
            string path = "~/images/";
            if (FileUpload1.HasFile)
            {
                //if (string.IsNullOrEmpty(image.Text))
                //{
                //    image.Text = FileUpload1.FileName;
                //}
                path += FileUpload1.FileName;
                //save image in folder    
                FileUpload1.SaveAs(MapPath(path));

                using (SqlConnection conn = new SqlConnection(abc))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Update Item set ItemName='" + ItemName + "',ItemType='" + ItemType + "',ItemPrice='" + ItemPrice + "',image='" + path + "'where ItemID='" + id + "' ", conn);
                    int t = cmd.ExecuteNonQuery();
                    if (t > 0)
                    {
                        Response.Write("<script>alert('Item has been successfully updated')</script>");
                        itemGV.EditIndex = -1;
                        displayItemCreated();
                    }
                }
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(abc))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Update Item set ItemName='" + ItemName + "',ItemType='" + ItemType + "',ItemPrice='" + ItemPrice + "'where ItemID='" + id + "' ", conn);
                    int t = cmd.ExecuteNonQuery();
                    if (t > 0)
                    {
                        Response.Write("<script>alert('Item has been successfully updated')</script>");
                        itemGV.EditIndex = -1;
                        displayItemCreated();
                    }
                }
            }

        }

        protected void itemGV_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            itemGV.EditIndex = -1;
            displayItemCreated();
        }

        protected void itemGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(itemGV.DataKeys[e.RowIndex].Value.ToString());
            //TextBox DeleteImageName = ((TextBox)itemGV.Rows[e.RowIndex].FindControl("Imagepath"));
            using (SqlConnection conn = new SqlConnection(abc))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from Item where ItemID='" + id + "'", conn);
                int t = cmd.ExecuteNonQuery();
                //ImageDeleteFromFolder(DeleteImageName.Text);

                if (t > 0)
                {
                    Response.Write("<script>alert('Item has been successfully deleted')</script>");
                    itemGV.EditIndex = -1;
                    displayItemCreated();
                }
            }
        }

        protected void searchbtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(abc))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                string sqlquery = "select * from Item where ItemName like '%'+@ItemName+'%'";
                cmd.CommandText = sqlquery;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("ItemName", searchbox.Text);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                itemGV.DataSource = dt;
                itemGV.DataBind();
            }

        }

        protected void resetbtn_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}