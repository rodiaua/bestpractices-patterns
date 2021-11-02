using System;

namespace OpenClosed
{
    public class BadShipping
    {
        public string Type { get; protected set; }
        public DateTime DateTime { get; protected set; }

        public BadShipping(string type, DateTime dateTime)
        {
            Type = type;
            DateTime = dateTime;
        }
    }


}
