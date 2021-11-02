using System.Collections.Generic;
using System.Linq;

namespace OpenClosed
{
    public class GoodOrder
    {
        public List<(string name, double price, float weight)> Items { get; set; }
        public GoodShipping Shipping { get; set; }

        public GoodOrder(List<(string name, double price, float weight)> items, GoodShipping shipping)
        {
            Items = items;
            Shipping = shipping;
        }

        public double GetTotal()
        {
            var total = Items.Select(x => x.price).Sum();
            total += Shipping.GetCost();
            return total;
        }

        public float GetWeightTotal()
        {
            var total = Items.Select(x => x.weight).Sum();
            return total;
        }

    }


}
