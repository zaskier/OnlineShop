using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Managment_ManageProductTypes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ProductTypesTypeModel model = new ProductTypesTypeModel();
        ProductTypes pt = CreateProductTypes();

        lblResult.Text = model.InsertProductTypes(pt);
    }

    private ProductTypes CreateProductTypes()
    {
        ProductTypes p = new ProductTypes();
        p.Name = txtName.Text;
        return p;
    }
}