namespace SumAnArray
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
                    numbers[i] = int.Parse(numbersAsString[i]);
                }

                int sum = 0;
                foreach (int number in numbers)
                {
                    sum += number;
                }

                Console.WriteLine("Sum: " + sum);
            }
        }
    }
}
