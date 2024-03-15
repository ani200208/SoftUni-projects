namespace _05.BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a sequence of integer numbers separated by spaces:");
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            Console.WriteLine("Enter the special bomb number followed by its power separated by space:");
            int[] bombParams = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bombNumber = bombParams[0];
            int bombPower = bombParams[1];

            List<int> remainingNumbers = DetonateBomb(numbers, bombNumber, bombPower);

            int sum = remainingNumbers.Sum();

            Console.WriteLine("Sum of remaining numbers: " + sum);
        }

        static List<int> DetonateBomb(List<int> numbers, int bombNumber, int bombPower)
        {
            while (numbers.Contains(bombNumber))
            {
                int index = numbers.IndexOf(bombNumber);

                int leftIndex = Math.Max(0, index - bombPower);
                int rightIndex = Math.Min(numbers.Count - 1, index + bombPower);

                numbers.RemoveRange(leftIndex, rightIndex - leftIndex + 1);
            }

            return numbers;
        }
    }
}
