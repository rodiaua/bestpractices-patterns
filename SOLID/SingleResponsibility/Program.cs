using System;

namespace SingleResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            var badEmployee = new BadEmployee("Bad");
            var goodEmployee = new GoodEmployee("Good");

            badEmployee.PrintTimeSheetReport();

            goodEmployee.TimeSheetReport.Print();

        }
    }

    //Bad employee
    public class BadEmployee
    {
        private string _name;
        public string GetName => _name;
        public void PrintTimeSheetReport()
        {
            Console.WriteLine("Report");
        }
        public BadEmployee(string name)
        {
            _name = name;
        }

    }

    //Good employee
    public class GoodEmployee
    {
        private string _name;
        public string GetName => _name;
        //not related functionality separated from the main functionality
        public TimeSheetReport TimeSheetReport { get; set; }

        public GoodEmployee(string name)
        {
            _name = name;
        }

    }

    public class TimeSheetReport
    {
        public void Print()
        {
            Console.WriteLine("Report");
        }

    }


}
