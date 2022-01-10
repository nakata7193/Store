using Shop.Products;
using System;

namespace Shop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Cart cart = new Cart();
            cart.Products.Add(new Food("apple", "BrandA", 1.5M, new DateTime(2021, 06, 14)), 2.45M);
            cart.Products.Add(new Bevarage("milk", "BrandM", 0.99M, new DateTime(2022, 02, 02)), 3M);
            cart.Products.Add(new Clothing("T-shirt", "BrandT", 15.99M, Size.M, Color.Violet), 2M);
            cart.Products.Add(new Appliance("laptop", "BrandL", 2345M, "ModelL", new DateTime(2021, 03, 03), 1.125), 1M);

            Purchase todayPurchase = new Purchase(cart, new DateTime(2021, 06, 14));
            Cashier cashier = new Cashier();

            string receipt = cashier.getReceipt(todayPurchase);
            Console.WriteLine(receipt);
            Console.ReadKey();
        }
    }
}
