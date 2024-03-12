namespace _03.ReverseAnArray
{
    internal class Program
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Enter the number of elements:");
                int N = int.Parse(Console.ReadLine());

                int[] numbers = new int[N];

                Console.WriteLine("Enter the numbers:");

                
                for (int i = 0; i < N; i++)
                {
                    numbers[i] = int.Parse(Console.ReadLine());
                }

                
                for (int i = 0; i < N / 2; i++)
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[N - i - 1];
                    numbers[N - i - 1] = temp;
                }

                
                Console.Write("Reversed array: ");
                foreach (int number in numbers)
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}
