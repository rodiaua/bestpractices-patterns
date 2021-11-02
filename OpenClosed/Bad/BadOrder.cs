using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenClosed
{
    //closed for extension
    public class BadOrder
    {
        public List<(string name, double price, float weight)> Items { get; set; }
        public BadShipping Shipping { get; set; }

        public BadOrder(List<(string name, double price, float feight)> items, BadShipping shipping)
        {
            Items = items;
            Shipping = shipping;
        }

        public double GetTotal()
        {
            var total = Items.Select(x => x.price).Sum();
            total += GetShippingCost();
            return total;
        }

        public float GetWeightTotal()
        {
            var total = Items.Select(x => x.weight).Sum();
            return total;
        }

        public double GetShippingCost()
        {
            switch (Shipping.Type)
            {
                case "ground" when Items.Select(x => x.price).Sum() > 100:
                    return 0;
                case "ground":
                    return GetWeightTotal() * 1.5;
                case "air":
                    return GetWeightTotal() * 3;
                default: return 0;
            }
        }

        public DateTime GetShippingDate()
        {
            return this.Shipping.DateTime.Date;
        }
    }


}
