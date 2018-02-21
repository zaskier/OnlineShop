using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FillPage();
    }
    private void FillPage()
    { 
        //Get selected product's type
        if(!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            ProductsModel productsModel = new ProductsModel();
            Products products = productsModel.GetProduct(id);
           //Fill page with data
            lblPrice.Text = "€" + products.Price;
            lblTitle.Text = products.Name;
            lblDescription.Text = products.Description;
            lblItemNr.Text = id.ToString();
            imgProduct.ImageUrl = "~/Images/Products/" + products.Image;
            //Fill Amount dropdownlist 
            int[] amount = Enumerable.Range(1, 25).ToArray();
            ddlAmount.DataSource = amount;
            ddlAmount.AppendDataBoundItems = true;
            ddlAmount.DataBind();

        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            int clientId = -1;
            int id = Convert.ToInt32(Request.QueryString["id"]);
            int amount = Convert.ToInt32(ddlAmount.SelectedValue);

            Cart cart = new Cart
            {
                Amount = amount,
                ClientID = clientId,
                DatePurchased = DateTime.Now,
                IsInCart = true,
                ProductID = id
            };
            CartModel model = new CartModel();
            lblResult.Text = model.InsertCart(cart);

        }
    }
}