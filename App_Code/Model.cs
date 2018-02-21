﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class Cart
{
    public int ID { get; set; }
    public int ClientID { get; set; }
    public int ProductID { get; set; }
    public int Amount { get; set; }
    public Nullable<System.DateTime> DatePurchased { get; set; }
    public bool IsInCart { get; set; }

    public virtual Products Products { get; set; }
}

public partial class Products
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Products()
    {
        this.Cart = new HashSet<Cart>();
    }

    public int ID { get; set; }
    public int TypeId { get; set; }
    public string Name { get; set; }
    public Nullable<int> Price { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Cart> Cart { get; set; }
    public virtual ProductTypes ProductTypes { get; set; }
}

public partial class ProductTypes
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public ProductTypes()
    {
        this.Products = new HashSet<Products>();
    }

    public int Id { get; set; }
    public string Name { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Products> Products { get; set; }
}