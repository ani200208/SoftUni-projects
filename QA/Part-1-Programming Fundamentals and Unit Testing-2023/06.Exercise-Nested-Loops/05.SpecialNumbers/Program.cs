
namespace _05.SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int num = 1111; num <= 9999; num++)
            {
                int currentNumber = num;
                bool isSpecial = true;

                while (currentNumber > 0)
                {
                    int digit = currentNumber % 10;
                    currentNumber /= 10;

                    if (digit == 0 || n % digit != 0)
                    {
                        isSpecial = false;
                        break;
                    }
                }

                if (isSpecial)
                {
                    Console.Write(num + " ");
                }
            }
        }
    }
}
