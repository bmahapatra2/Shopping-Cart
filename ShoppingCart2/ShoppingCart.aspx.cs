using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace ShoppingCart2
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        Dictionary<string, float> cartItem;
        static SqlConnection connect;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
                SqlConnection con = new SqlConnection("data source=TAVDESKRENT004; database= Shopping Cart; User Id=sa; Password=test123!@#");
                SqlCommand cmd = new SqlCommand("Select * from ShoppingCart", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
        }

        protected void Gridview_row_command(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                int rowIndex = Int32.Parse((String)e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                var chocolate = row.Cells[1].Text;
                var cost = row.Cells[2].Text;
                if (ViewState["cartItem"] == null)
                {
                    cartItem = new Dictionary<string, float>();
                    cartItem[chocolate] = int.Parse(cost);
                    ViewState["cartItem"] = cartItem;
                    HttpContext.Current.Session["cartitem"] = cartItem;
                }
                else
                {
                    cartItem = new Dictionary<string, float>();
                    cartItem = (Dictionary<String, float>)ViewState["cartItem"];
                    cartItem[chocolate] = int.Parse(cost);
                    HttpContext.Current.Session["cartItem"] = cartItem;

                }
            }
        }
        protected void OnClick(object sender, EventArgs e)
        {
             Response.Redirect("CheckoutPage.aspx");
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("InventoryManagement.aspx");

        }
    }
}