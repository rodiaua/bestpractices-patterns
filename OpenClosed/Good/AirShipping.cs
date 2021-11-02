using System;

namespace OpenClosed
{
    public class AirShipping : GoodShipping
    {
        public DateTime DateTime { get; private set; }
        public double WeightTotal { get; private set; }


        public AirShipping(DateTime dateTime, double weightTotal)
        {
            DateTime = dateTime;
            WeightTotal = weightTotal;
        }

        public double GetCost()
        {
            return WeightTotal * 3;
        }

        public DateTime GetDate()
        {
            return DateTime.Date;
        }

    }


}
