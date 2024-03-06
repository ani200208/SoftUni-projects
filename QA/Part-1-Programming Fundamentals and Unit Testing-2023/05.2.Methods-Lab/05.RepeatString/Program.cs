namespace _05.RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a text:");
            string text = Console.ReadLine();

            Console.WriteLine("Enter repeat count:");
            int repeatCount = Convert.ToInt32(Console.ReadLine());

            string repeatedString = RepeatString(text, repeatCount);
            Console.WriteLine("Result: " + repeatedString);
        }

        static string RepeatString(string text, int repeatCount)
        {
            string result = "";

            for (int i = 0; i < repeatCount; i++)
            {
                result += text;
            }

            return result;
        }
    }
}

