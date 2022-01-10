using System;
using Shop.Products.Base;

namespace Shop.Products
{
    public class Bevarage : Product
    {
        public Bevarage(string name, string brand, decimal price, DateTime expirationDate)
            : base(name, brand, price)
        {
            ExpirationDate = expirationDate;
        }

        public DateTime ExpirationDate { get; set; }
    }
}
