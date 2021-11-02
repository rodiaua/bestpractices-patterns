using System;

namespace OpenClosed
{
    public class GroundShipping : GoodShipping
    {
        public DateTime DateTime { get; private set; }
        public double WeightTotal { get; private set; }
        public double TotalCost { get; private set; }

        public GroundShipping(DateTime dateTime, double weightTotal, double totalCost)
        {
            DateTime = dateTime;
            WeightTotal = weightTotal;
            TotalCost = totalCost;
        }

        public double GetCost()
        {
            return TotalCost > 100 ? 0: WeightTotal * 1.5;
        }

        public DateTime GetDate()
        {
            return DateTime.Date;
        }

    }


}
