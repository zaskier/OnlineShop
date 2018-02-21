using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Managment_ManageProcuct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetImages();
            if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                FillPage(id);
            }
        }
    }
    private void FillPage(int id)
    {
        ProductsModel productsModel = new ProductsModel();
        Products product = productsModel.GetProduct(id);

        txtDescription.Text = product.Description;
        txtName.Text = product.Name;
        txtPrice.Text = product.Price.ToString();

        ddlImage.SelectedValue = product.Image;
        ddlType.SelectedValue = product.TypeId.ToString();
    }

    private void GetImages()
    {
        try
        {
            string[] images = Directory.GetFiles(Server.MapPath("~/Images/Products/"));

            ArrayList imageList = new ArrayList();

            foreach (string image in images)
            {
                string imageName = image.Substring(image.LastIndexOf(@"\", StringComparison.Ordinal) + 1);
                imageList.Add(imageName);
            }

            ddlImage.DataSource = imageList;
            ddlImage.AppendDataBoundItems = true;
            ddlImage.DataBind();


        }
        catch (Exception e)
        {
            lblResult.Text = e.ToString();
        }

    }
    protected void ddType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private Products GreateProduct()
    {
        Products products = new Products();

        products.Name = txtName.Text;
        products.Price = Convert.ToInt32(txtPrice.Text); //to Double
        products.TypeId = Convert.ToInt32(ddlType.SelectedValue);
        products.Description = txtDescription.Text;
        products.Image = ddlImage.SelectedValue;
        return products;
    }




    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ProductsModel productsModel = new ProductsModel();
        Products products = GreateProduct();

        if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            lblResult.Text = productsModel.UpdateProduct(id, products);
        }
        else
        {
            lblResult.Text = productsModel.InsertProduct(products);
        }

        lblResult.Text = productsModel.InsertProduct(products);

    }
}