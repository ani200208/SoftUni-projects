namespace _08.MultiplyEvensbyOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an integer number:");
            int number = Convert.ToInt32(Console.ReadLine());

            int result = GetMultipleOfEvenAndOdds(number);
            Console.WriteLine("Result: " + result);
        }

        static int GetMultipleOfEvenAndOdds(int number)
        {
            int sumOfEvens = GetSumOfEvenDigits(number);
            int sumOfOdds = GetSumOfOddDigits(number);

            return sumOfEvens * sumOfOdds;
        }

        static int GetSumOfEvenDigits(int number)
        {
            int sum = 0;
            number = Math.Abs(number);

            while (number > 0)
            {
                int digit = number % 10;
                if (digit % 2 == 0)
                {
                    sum += digit;
                }
                number /= 10;
            }

            return sum;
        }

        static int GetSumOfOddDigits(int number)
        {
            int sum = 0;
            number = Math.Abs(number);

            while (number > 0)
            {
                int digit = number % 10;
                if (digit % 2 != 0)
                {
                    sum += digit;
                }
                number /= 10;
            }

            return sum;
        }
    }
}

