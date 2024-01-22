using System;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
           int balance = Convert.ToInt32(Console.ReadLine());
            int withdraw = Convert.ToInt32(Console.ReadLine());
            int limit = Convert.ToInt32(Console.ReadLine());    

            if (balance >= withdraw)
            {
                Console.WriteLine("The withdraw was successful.");
            }
            else if (withdraw > limit)
            {
                Console.WriteLine("The limit was exceeded.");
            }
            else
            {
                Console.WriteLine("Insufficient availability.");
            }
            

        }
    }
}