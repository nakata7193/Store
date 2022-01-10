namespace Shop.Products.Base
{
    public class Product
    {
        public Product(string name, string brand, decimal price)
        {
            Name = name;
            Brand = brand;
            Price = price;
            DiscountPercent = 0M;
            Discount = 0M;
        }

        public string Name { get; set; }

        public string Brand { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountPercent { get; set; }

        public decimal Discount { get; set; }
    }
}
