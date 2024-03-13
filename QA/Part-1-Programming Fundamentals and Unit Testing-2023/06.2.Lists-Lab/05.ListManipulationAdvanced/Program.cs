namespace _05.ListManipulationAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                if (action == "Contains")
                {
                    int number = int.Parse(tokens[1]);
                    if (numbers.Contains(number))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (action == "PrintEven")
                {
                    Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 == 0)));
                }
                else if (action == "PrintOdd")
                {
                    Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 != 0)));
                }
                else if (action == "GetSum")
                {
                    Console.WriteLine(numbers.Sum());
                }
                else if (action == "Filter")
                {
                    string condition = tokens[1];
                    int number = int.Parse(tokens[2]);

                    if (condition == ">")
                    {
                        numbers = numbers.Where(x => x > number).ToList();
                    }
                    else if (condition == "<")
                    {
                        numbers = numbers.Where(x => x < number).ToList();
                    }
                    else if (condition == ">=")
                    {
                        numbers = numbers.Where(x => x >= number).ToList();
                    }
                    else if (condition == "<=")
                    {
                        numbers = numbers.Where(x => x <= number).ToList();
                    }
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
