using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Generic.Dictionary<string, float>;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
namespace ShoppingCart2
{
    public partial class CheckoutPage : System.Web.UI.Page
    {
        static string connectionString;
        Dictionary<string, float> cartItems;
        Label[] ChocolateName;
        Label[] price;
        Label amount, totalPrice;
        float total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = WebConfigurationManager.ConnectionStrings["Shopping CartConnectionString"].ConnectionString;
            // connectionString = "Data Source=TAVDESK015;Initial Catalog=Shopping Cart;User Id=sa;Password=test123!@#";
            cartItems = (Dictionary<string, float>)(HttpContext.Current.Session["cartItems"]);
            KeyCollection coll = cartItems.Keys;
            List<string> items = coll.ToList();
            ChocolateName = new Label[cartItems.Count];
            price = new Label[cartItems.Count];
            for (int i = 0; i < cartItems.Count; i++)
            {
                ChocolateName[i] = new Label();
                price[i] = new Label();
                ChocolateName[i].Text = items[i];
                total += cartItems[items[i]];
                price[i].Text = cartItems[items[i]].ToString();
                this.Controls.Add(ChocolateName[i]);
                this.Controls.Add(new LiteralControl("<br>"));
                this.Controls.Add(price[i]);
                this.Controls.Add(new LiteralControl("<br>"));
                this.Controls.Add(new LiteralControl("<br>"));
            }
            amount = new Label();
            totalPrice = new Label();
            amount.Text = total.ToString();
            totalPrice.Text = "Total Price: ";
            this.Controls.Add(totalPrice);
            this.Controls.Add(amount);
        }

        protected void Onclick(object sender, EventArgs e)
        {
            var orderId = SaveOrder();
            var cart = (Dictionary<string, float>)(HttpContext.Current.Session["cartItems"]);


            foreach (var key in cart.Keys)
            {
                SaveOrderItem(orderId, key, cart[key]);
            }
            Session["cart"] = new Dictionary<string, int>();
            Response.Redirect("BillingPage.aspx");
        }
        private void SaveOrderItem(Guid orderId, string chocolateId, float price)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string command = $"insert into OrderDetails values('{orderId}','{chocolateId}','{price}')";
                    SqlCommand cmd = new SqlCommand(command, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    Response.Write("<script>if(confirm('Something Bad happened, Please contact Administrator!!!!')){window.location=InventoryManagement.aspx}</script>");
                }
            }
        }
        private Guid SaveOrder()
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                var orderId = Guid.NewGuid();
                try
                {
                    conn.Open();
                    string command = $"insert into [Order] values('{orderId}','{total}',CURRENT_TIMESTAMP)";
                    SqlCommand cmd = new SqlCommand(command, conn);
                    cmd.ExecuteNonQuery();
                   // return orderId;
                }
                catch (Exception exception)
                {
                    Response.Write("<script>if(confirm('Something Bad happened, Please contact Administrator!!!!')){window.location=InventoryManagement.aspx}</script>");
                }
                return orderId;
            }
        }
    }
}