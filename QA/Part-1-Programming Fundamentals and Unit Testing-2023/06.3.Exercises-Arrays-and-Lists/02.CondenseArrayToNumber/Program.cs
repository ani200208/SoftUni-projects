namespace _02.CondenseArrayToNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a sequence of integers separated by spaces:");
            string input = Console.ReadLine();

            int[] numbers = input.Split(' ').Select(int.Parse).ToArray();

            int result = CondenseArray(numbers);

            Console.WriteLine("Condensed result: " + result);
        }

        static int CondenseArray(int[] numbers)
        {
            while (numbers.Length > 1)
            {
                int[] condensedArray = new int[numbers.Length - 1];

                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    condensedArray[i] = numbers[i] + numbers[i + 1];
                }

                numbers = condensedArray;
            }

            return numbers[0];
        }
    }
}
