using System;

namespace BiggestOfFiveNumbers
{
    class Program
    {
        static void Main(string[] args)
        {


            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());
            int num3 = Convert.ToInt32(Console.ReadLine());
            int num4 = Convert.ToInt32(Console.ReadLine());
            int num5 = Convert.ToInt32(Console.ReadLine());

            int maxNumber = num1;

            if (num2 > maxNumber)
            {
                maxNumber = num2;
            }

            else if (num3 > maxNumber)
            {
                maxNumber = num3;
            }

            else if (num4 > maxNumber)
            {
                maxNumber = num4;
            }

            else if (num5 > maxNumber)
            {
                maxNumber = num5;
            }

            Console.WriteLine($"{maxNumber}");
        }
    }
}