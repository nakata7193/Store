using System.Collections.Generic;
using System.Text;
using Shop.Products;
using Shop.Products.Base;

namespace Shop
{
    public class Cashier
    {
        public string getReceipt(Purchase purchase)
        {
            StringBuilder receipt = new StringBuilder();
            receipt.AppendLine($"Date: {purchase.PurchaseDate}\n");
            receipt.AppendLine("---Products---");
            foreach (KeyValuePair<Product, decimal> product in purchase.ShoppingCart.Products)
            {
                receipt.AppendLine();

                if (product.Key is Appliance)
                {
                    Appliance applianceProduct = (Appliance)product.Key;
                    receipt.AppendLine($"{applianceProduct.Name} {applianceProduct.Brand} {applianceProduct.Model}");
                }
                else if (product.Key is Clothing)
                {
                    Clothing clothingProduct = (Clothing)product.Key;
                    receipt.AppendLine($"{clothingProduct.Name} {clothingProduct.Brand} {clothingProduct.Size} {clothingProduct.Color}");
                }
                else
                {
                    receipt.AppendLine($"{product.Key.Name} {product.Key.Brand}");
                }

                receipt.AppendLine($"{product.Value:F2} x ${product.Key.Price:F2} = ${(product.Key.Price * product.Value):F2}");

                if (product.Key.Discount != 0M)
                {
                    receipt.AppendLine($"#discount {(product.Key.DiscountPercent * 100):F0}% -${(product.Key.Discount * product.Value):F2}");
                }
            }
            receipt.AppendLine("-----------------------------------------------------------------------------------");
            receipt.AppendLine($"SUBTOTAL: ${purchase.SubTotal:F2}");
            receipt.AppendLine($"DISCOUNT: -${purchase.Discount:F2}");
            receipt.AppendLine($"TOTAL: ${purchase.Total:F2}");
            return receipt.ToString();
        }
    }
}
