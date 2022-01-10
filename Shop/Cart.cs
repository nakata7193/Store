using System.Collections.Generic;
using Shop.Products.Base;

namespace Shop
{
    public class Cart
    {
        public Cart()
        {
            Products = new Dictionary<Product, decimal>();
        }

        public Dictionary<Product, decimal> Products { get; set; } 
    }
}
