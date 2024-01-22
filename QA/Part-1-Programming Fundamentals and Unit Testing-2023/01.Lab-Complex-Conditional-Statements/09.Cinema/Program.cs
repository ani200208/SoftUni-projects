using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string typemovie = Console.ReadLine();
            int rows = Convert.ToInt32(Console.ReadLine());
            int seats = Convert.ToInt32(Console.ReadLine());

            double ticketPrice = 0.0;

            if (typemovie == "Premiere")
            {
                ticketPrice = 12.00;
            }
            else if (typemovie == "Normal")
            {
                ticketPrice = 7.50;
            }
            else if (typemovie == "Discount")
            {
                ticketPrice = 5.00;
            }

            double totalPrice = rows * seats * ticketPrice;
            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}