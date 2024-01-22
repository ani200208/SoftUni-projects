using System;

namespace ProductOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
           double num1 = Convert.ToDouble(Console.ReadLine());
            double num2 = Convert.ToDouble(Console.ReadLine());
            double num3 = Convert.ToDouble(Console.ReadLine());

            double product = num1 * num2 * num3;


            if (product > 0)
            {
                Console.WriteLine("positive");
            }
            else if (product < 0)
            {
                Console.WriteLine("negative");
            }
            else 
            {
                Console.WriteLine("zero");
            }

        }
    }
}
