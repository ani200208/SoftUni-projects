using System;

namespace VacationExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string accommodationType = Console.ReadLine();
            int daysCount = Convert.ToInt32(Console.ReadLine());

            double totalPrice = 0;

            if (season == "Spring")
            {
                if (accommodationType == "Hotel")
                    totalPrice = 30 * 0.8;
                else if (accommodationType == "Camping")
                    totalPrice = 10 * 0.8;
            }
            else if (season == "Summer")
            {
                if (accommodationType == "Hotel")
                    totalPrice = 50;
                else if (accommodationType == "Camping")
                    totalPrice = 30;
            }
            else if (season == "Autumn")
            {
                if (accommodationType == "Hotel")
                    totalPrice = 20 * 0.7;
                else if (accommodationType == "Camping")
                    totalPrice = 15 * 0.7;
            }
            else if (season == "Winter")
            {
                if (accommodationType == "Hotel")
                    totalPrice = 40 * 0.9;
                else if (accommodationType == "Camping")
                    totalPrice = 10 * 0.9;
            }
            else
            {
                Console.WriteLine("Invalid season");
                
            }

            double totalExpenses = totalPrice * daysCount;
            Console.WriteLine($"{totalExpenses:F2}");
        }
    }
}