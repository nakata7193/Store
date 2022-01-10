using System;
using System.Collections.Generic;
using Shop.Products;
using Shop.Products.Base;

namespace Shop
{
    public class Purchase
    {
        public Purchase(Cart shoppingCart, DateTime purchaseDate)
        {
            ShoppingCart = shoppingCart;
            PurchaseDate = purchaseDate;
            setupDiscounts();
        }

        public Cart ShoppingCart { get; set; }

        public DateTime PurchaseDate { get; set; }

        public decimal SubTotal
        {
            get
            {
                decimal total = 0M;
                foreach (KeyValuePair<Product, decimal> product in ShoppingCart.Products)
                {
                    total += product.Key.Price * product.Value;
                }
                return total;
            }
        }

        public decimal Discount
        {
            get
            {
                decimal discount = 0M;
                foreach (KeyValuePair<Product, decimal> product in ShoppingCart.Products)
                {
                    discount += product.Key.Discount * product.Value;
                }
                return discount;
            }
        }

        public decimal Total
        {
            get
            {
                return SubTotal - Discount;
            }
        }

        private void setupDiscounts()
        {
            foreach (KeyValuePair<Product, decimal> product in ShoppingCart.Products)
            {
                if (product.Key is Food)
                {
                    Food foodProduct = (Food)product.Key;
                    double remainingDays = (foodProduct.ExpirationDate - PurchaseDate).TotalDays;
                    if (remainingDays >= 5 && remainingDays >= 1)
                    {
                        foodProduct.DiscountPercent = 0.1M;
                        foodProduct.Discount = foodProduct.Price * 0.1M;
                    }
                    else if (remainingDays < 1)
                    {
                        foodProduct.DiscountPercent = 0.5M;
                        foodProduct.Discount = foodProduct.Price * 0.5M;
                    }
                }

                if (product.Key is Bevarage)
                {
                    Bevarage bevarageProduct = (Bevarage)product.Key;
                    double remainingDays = (bevarageProduct.ExpirationDate - PurchaseDate).TotalDays;
                    if (remainingDays <= 5 && remainingDays >= 1)
                    {
                        bevarageProduct.DiscountPercent = 0.1M;
                        bevarageProduct.Discount = bevarageProduct.Price * 0.1M;
                    }
                    else if (remainingDays < 1)
                    {
                        bevarageProduct.DiscountPercent = 0.1M;
                        bevarageProduct.Discount = bevarageProduct.Price * 0.1M;
                    }
                }

                bool purchaseDateIsSaturday = PurchaseDate.DayOfWeek == DayOfWeek.Saturday;
                bool purchaseDateIsSunday = PurchaseDate.DayOfWeek == DayOfWeek.Saturday;
                bool purchaseDateIsWeekend = purchaseDateIsSaturday || purchaseDateIsSunday;
                if (product.Key is Clothing)
                {
                    Clothing clothingProduct = (Clothing)product.Key;
                    if (!purchaseDateIsWeekend)
                    {
                        clothingProduct.DiscountPercent = 0.1M;
                        clothingProduct.Discount = clothingProduct.Price * 0.1M;
                    }
                }

                if (product.Key is Appliance)
                {
                    Appliance applianceProduct = (Appliance)product.Key;
                    if ((applianceProduct.Price > 999) && purchaseDateIsWeekend)
                    {
                        applianceProduct.DiscountPercent = 0.05M;
                        applianceProduct.Discount = applianceProduct.Price * 0.05M;
                    }
                }
            }
        }
    }
}
