using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class ProductsModel
{
    public string InsertProduct(Products product)
    {
        try
        {
            ShopDBEntities db = new ShopDBEntities();
            db.Products.Add(product);
            db.SaveChanges();

            return product.Name + "was succesfully inserted";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }
    public string UpdateProduct(int id, Products products)
    {
        try {
            ShopDBEntities db = new ShopDBEntities();
            //
            Products p = db.Products.Find(id);
            p.Name = products.Name;
            p.Price = products.Price;
            p.TypeId = products.TypeId;
            p.Description = products.Description;
            p.Image = products.Image;

            db.SaveChanges();
            return products.Name + " was sucessfully updated";

        }
        catch (Exception e)
        { return "Error:" + e; }
    }
    public string DeleteProduct(int id)
    {
        try {
            ShopDBEntities db = new ShopDBEntities();
            Products product = db.Products.Find(id);

            db.Products.Attach(product);
            db.Products.Remove(product);
            db.SaveChanges();
            return product.Name + " was sucessfully deleted";

        }
        catch (Exception e)
        { return "Error:" + e; }
    }

    public Products GetProduct(int id)
    {
        try
        {
            using (ShopDBEntities db = new ShopDBEntities())
            {
                Products products = db.Products.Find(id);
                return products;

            }
        }
        catch(Exception)
        {
            return null;
        }


    }

    public List<Products> GetAllProducts()
    {
        try
        {
            using (ShopDBEntities db = new ShopDBEntities())
            {
                List<Products> allproducts = (from x in db.Products select x).ToList();
                return allproducts;
            }
        }
        catch (Exception)
        {
            return null;
        }


    }
    private List<Products> GetProductsByType(int typeId)
    {
        try
        {
            using (ShopDBEntities db = new ShopDBEntities())
            {
                List<Products> allproducts = (from x in db.Products
                                              where x.TypeId ==typeId select x).ToList();
                return allproducts;
            }
        }
        catch (Exception)
        {
            return null;
        }


    }


}