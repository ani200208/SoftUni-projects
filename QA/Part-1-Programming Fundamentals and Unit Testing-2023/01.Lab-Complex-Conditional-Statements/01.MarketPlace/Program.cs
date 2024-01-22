using System;

namespace MarketPlace
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            if (product == "Banana")
            {
                if (dayOfWeek == "Weekday")
                {
                    Console.WriteLine("2.50");
                }
                else if (dayOfWeek == "Weekend")
                {
                    Console.WriteLine("2.70");
                }
                else
                {
                    Console.WriteLine("Invalid day");
                }
            }
            else if (product == "Apple")
            {
                if (dayOfWeek == "Weekday")
                {
                    Console.WriteLine("1.30");
                }
                else if (dayOfWeek == "Weekend")
                {
                    Console.WriteLine("1.60");
                }
                else
                {
                    Console.WriteLine("Invalid day");
                }
            }
            else if (product == "Kiwi")
            {
                if (dayOfWeek == "Weekday")
                {
                    Console.WriteLine("2.20");
                }
                else if (dayOfWeek == "Weekend")
                {
                    Console.WriteLine("3.00");
                }
                else
                {
                    Console.WriteLine("Invalid day");
                }
            }
           
            
        }
    }
}