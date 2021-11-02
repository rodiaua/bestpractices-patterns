using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenClosed
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new List<(string name, double price, float weight)>();
            items.Add(("Game", 19.1, 0.10f));
            items.Add(("Mouse", 20.5, 0.4f));
            items.Add(("NoteBook", 700, 3f));

            var badOrder1 = new BadOrder(items, new BadShipping("ground", DateTime.Now));
            var badOrder2 = new BadOrder(items, new BadShipping("air", DateTime.Now));

            var itemsTotalWeight = items.Select(x => x.weight).Sum();
            var itemsTotalCost = items.Select(x => x.price).Sum();

            var goodOrder1 = new GoodOrder(items, new GroundShipping(DateTime.Now, itemsTotalWeight, itemsTotalCost));
            var goodOrder2 = new GoodOrder(items, new AirShipping(DateTime.Now, itemsTotalWeight));

            Console.WriteLine($"{nameof(BadOrder)} with ground shipping: {badOrder1.GetTotal()}");
            Console.WriteLine($"{nameof(BadOrder)} with air shipping: {badOrder2.GetTotal()}");

            Console.WriteLine($"{nameof(GoodOrder)} with {nameof(GroundShipping)}: {goodOrder1.GetTotal()}");
            Console.WriteLine($"{nameof(GoodOrder)} with {nameof(AirShipping)}: {goodOrder2.GetTotal()}");


        }
    }
}
