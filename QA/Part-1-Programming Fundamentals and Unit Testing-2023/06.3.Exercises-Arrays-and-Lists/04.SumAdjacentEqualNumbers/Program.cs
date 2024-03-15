namespace _04.SumAdjacentEqualNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a sequence of integer numbers separated by spaces:");
            string input = Console.ReadLine();

            List<int> numbers = new List<int>();

            foreach (string number in input.Split(' '))
            {
                numbers.Add(int.Parse(number));
            }

            List<int> summedList = SumAdjacentEqualNumbers(numbers);

            Console.WriteLine("Summed list:");
            Console.WriteLine(string.Join(" ", summedList));
        }

        static List<int> SumAdjacentEqualNumbers(List<int> numbers)
        {
            List<int> summedList = new List<int>();

            int i = 0;
            while (i < numbers.Count)
            {
                int currentNumber = numbers[i];
                int sum = currentNumber;

                // Find adjacent equal numbers and sum them
                while (i < numbers.Count - 1 && numbers[i] == numbers[i + 1])
                {
                    sum += numbers[i + 1];
                    i++;
                }

                summedList.Add(sum);
                i++;
            }

            return summedList;
        }
    }
}
