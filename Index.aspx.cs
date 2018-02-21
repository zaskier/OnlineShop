﻿using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ProductsModel model = new ProductsModel();
        List<Products> products = model.GetAllProducts();
        if (products != null)
        {
            foreach (Products product in products)
            {
                Panel productPanel = new Panel();
                ImageButton imageButton = new ImageButton
                {
                    ImageUrl = "~/Images/Products/" + product.Image,
                    CssClass = "productImage",
                    PostBackUrl = string.Format("~/Pages/Product.aspx?id={0}", product.ID)
                };
                Label lblName = new Label
                {
                    Text = product.Name,
                    CssClass = "productName"
                };
                Label lblPrice = new Label
                {
                    Text = "€" + product.Price,
                    CssClass = "productPrice"
                };

                productPanel.Controls.Add(imageButton);
                productPanel.Controls.Add(new Literal { Text = "<br/>" });
                productPanel.Controls.Add(lblName);
                productPanel.Controls.Add(new Literal { Text = "<br/>" });
                productPanel.Controls.Add(lblPrice);

                //Add dynamic controls to static control
                pnlProducts.Controls.Add(productPanel);
            }
        }
        else
            pnlProducts.Controls.Add(new Literal { Text = "No products found!" });
    }

    }




