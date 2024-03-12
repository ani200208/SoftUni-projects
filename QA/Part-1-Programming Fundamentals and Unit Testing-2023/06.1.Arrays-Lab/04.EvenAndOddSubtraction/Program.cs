namespace _04.EvenAndOddSubtraction
{
    internal class Program
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Enter integers separated by space:");
                string input = Console.ReadLine();

                string[] numbersAsString = input.Split(' ');
                int[] numbers = new int[numbersAsString.Length];

                for (int i = 0; i < numbersAsString.Length; i++)
                {
                    if (int.TryParse(numbersAsString[i], out int num))
                    {
                        numbers[i] = num;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input: " + numbersAsString[i]);
                        return; 
                    }
                }

                int sumEven = 0;
                int sumOdd = 0;

                foreach (int number in numbers)
                {
                    if (number % 2 == 0)
                    {
                        sumEven += number;
                    }
                    else
                    {
                        sumOdd += number;
                    }
                }

                int difference = sumEven - sumOdd;

                Console.WriteLine("Difference: " + difference);
            }
        }
    }
}
