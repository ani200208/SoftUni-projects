namespace _04.ListManipulationBasics
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

                if (action == "Add")
                {
                    int number = int.Parse(tokens[1]);
                    numbers.Add(number);
                }
                else if (action == "Remove")
                {
                    int number = int.Parse(tokens[1]);
                    numbers.Remove(number);
                }
                else if (action == "RemoveAt")
                {
                    int index = int.Parse(tokens[1]);
                    numbers.RemoveAt(index);
                }
                else if (action == "Insert")
                {
                    int number = int.Parse(tokens[1]);
                    int index = int.Parse(tokens[2]);
                    numbers.Insert(index, number);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
