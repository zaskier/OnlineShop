using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class CartModel
{
    public string InsertCart(Cart cart)
    {
        try
        {
            ShopDBEntities db = new ShopDBEntities();
            db.Cart.Add(cart);  //carts
            db.SaveChanges();

            return cart.DatePurchased + " was succesfully inserted";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        } 
    }
    public string UpdateCart(int id, Cart cart)
    {
        try
        {
            ShopDBEntities db = new ShopDBEntities();
            //
            Cart p = db.Cart.Find(id);
            p.DatePurchased = cart.DatePurchased;
            p.ClientID = cart.ClientID;
            p.Amount = cart.Amount;
            p.IsInCart = cart.IsInCart;
            p.ProductID = cart.ProductID;

            db.SaveChanges();
            return cart.DatePurchased + " was sucessfully updated";

        }
        catch (Exception e)
        { return "Error:" + e; }
    }
    public string DeleteCart(int id)
    {
        try
        {
            ShopDBEntities db = new ShopDBEntities();
            Cart  cart = db.Cart.Find(id);

            db.Cart.Attach(cart);
            db.Cart.Remove(cart);
            db.SaveChanges();
            return cart.DatePurchased + " was sucessfully deleted";

        }
        catch (Exception e)
        { return "Error:" + e; }
    }
}
