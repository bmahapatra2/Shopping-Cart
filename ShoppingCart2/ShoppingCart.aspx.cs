using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
namespace ShoppingCart2
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        static string connectionString;
        Dictionary<string, float> cartItem;
        static SqlConnection connect;
        protected void Page_Load(object sender, EventArgs e)
        {
              if (!IsPostBack)
            {
                try
                {
                    Session.Clear();
                    connectionString = WebConfigurationManager.ConnectionStrings["Shopping CartConnectionString"].ConnectionString;
                    //SqlConnection con = new SqlConnection("data source=TAVDESK015; Initial Catalog= Shopping Cart; User Id=sa; Password=test123!@#");
                    SqlConnection con = new SqlConnection(connectionString);
                    SqlCommand cmd = new SqlCommand("Select * from ShoppingCart", con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                }
                catch (Exception exception)
                {
                    Response.Write("<script>if(confirm('Something Bad happened, Please contact Administrator!!!!')){window.location=InventoryManagement.aspx}</script>");
                }
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
                    HttpContext.Current.Session["cartItems"] = cartItem;
                }
                else
                {
                    cartItem = new Dictionary<string, float>();
                    cartItem = (Dictionary<String, float>)ViewState["cartItem"];
                    cartItem[chocolate] = int.Parse(cost);
                    HttpContext.Current.Session["cartItems"] = cartItem;
                }
            }
        }
        protected void Btn_OnClick(object sender, EventArgs e)
        {
            e.Equals("CheckoutPage.aspx");
            try
            {
                Response.Redirect("CheckoutPage.aspx");
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.HelpLink);
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("InventoryManagement.aspx");

        }
    }
}