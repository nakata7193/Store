using System;
using Shop.Products.Base;

namespace Shop.Products
{
    public class Appliance : Product
    {

        public Appliance(string name, string brand, decimal price, string model, DateTime productionDate, double weight)
            : base(name, brand, price)
        {
            Model = model;
            Weight = weight;
            ProductionDate = productionDate;
        }

        public string Model { get; set; }

        public double Weight { get; set; }

        public DateTime ProductionDate { get; set; }
    }
}
