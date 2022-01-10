using Shop.Products.Base;

namespace Shop.Products
{
    public class Clothing : Product
    {
        public Clothing(string name, string brand, decimal price, Size size, Color color)
            : base(name, brand, price)
        {
            Size = size;
            Color = color;
        }

        public Size Size { get; set; }

        public Color Color { get; set; }
    }

    public enum Size
    {
        XS,
        S,
        M,
        L,
        XL
    }

    public enum Color
    {
        Black,
        White,
        Yellow,
        Red,
        Brown,
        Violet
    }
}
