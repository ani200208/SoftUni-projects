using System;

namespace NumberOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = Convert.ToDouble(Console.ReadLine());
            double num2 = Convert.ToDouble(Console.ReadLine());
            string mathоperator = Console.ReadLine(); 

            double result = 0;


            if (mathоperator == "+")
            {
                result = num1 + num2;
            }
            
            else if (mathоperator == "-")
            {
                result = num1 - num2;
            }
           
            else if (mathоperator == "*")
            {
                result = num1 * num2;
            }
           
            else if (mathоperator == "/")
            {
               
                
                if (num2 != 0)
                {
                    result = num1 / num2;
                }
                else

                {
                  Console.WriteLine("Cannot divide by zero.");
                    
                }
            }

                else
                {
                  Console.WriteLine("Invalid operator.");
                
                }

                Console.WriteLine($"{num1} {mathоperator} {num2} = {result:F2}");


        }
    }
}