using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class ProductTypesTypeModel
{
    public string InsertProductTypes(ProductTypes productType)
    {
        try
        {
            ShopDBEntities db = new ShopDBEntities();
            db.ProductTypes.Add(productType);
            db.SaveChanges();

            return productType.Name + " was succesfully inserted";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }
    public string UpdateProductTypes(int id, ProductTypes productTypes)
    {
        try
        {
            ShopDBEntities db = new ShopDBEntities();
            //
            ProductTypes p = db.ProductTypes.Find(id);
            p.Name = productTypes.Name;
           

            db.SaveChanges();
            return productTypes.Name + " was sucessfully updated";

        }
        catch (Exception e)
        { return "Error:" + e; }
    }
    public string DeleteProductTypes(int id)
    {
        try
        {
            ShopDBEntities db = new ShopDBEntities();
            ProductTypes productType = db.ProductTypes.Find(id);

            db.ProductTypes.Attach(productType);
            db.ProductTypes.Remove(productType);
            db.SaveChanges();
            return productType.Name + " was sucessfully deleted";

        }
        catch (Exception e)
        { return "Error:" + e; }
    }
}