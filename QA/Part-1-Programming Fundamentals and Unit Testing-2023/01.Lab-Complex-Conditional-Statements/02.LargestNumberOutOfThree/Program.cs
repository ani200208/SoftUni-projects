using System;
using System.ComponentModel.Design;

namespace LargestNumberOutOfThree
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int largestNumber = num1;

            if (num1 > num2 )
                if (num1 > num3)
                {
                Console.WriteLine(num1);
                }
            else  
            {
                Console.WriteLine(num3);
            }
            else if(num2 > num3)
            {
                Console.WriteLine(num2);
            }
            else
            {
                Console.WriteLine(num3);
            }



        }
    }
}
