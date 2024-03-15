namespace _01.Gauss_Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a sequence of integers separated by spaces:");
            string input = Console.ReadLine();

            List<int> numbers = input.Split(' ').Select(int.Parse).ToList();

            List<int> summedList = SumList(numbers);

            Console.WriteLine("Summed list:");
            Console.WriteLine(string.Join(" ", summedList));
        }

        static List<int> SumList(List<int> numbers)
        {
            List<int> summedList = new List<int>();

            int length = numbers.Count;
            int halfLength = length / 2;

            for (int i = 0; i < halfLength; i++)
            {
                summedList.Add(numbers[i] + numbers[length - 1 - i]);
            }

            if (length % 2 != 0)
            {
                summedList.Add(numbers[halfLength]);
            }

            return summedList;
        }
    }
}
