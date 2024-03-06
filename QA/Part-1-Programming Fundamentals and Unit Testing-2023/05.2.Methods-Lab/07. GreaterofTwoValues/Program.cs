namespace _07._GreaterofTwoValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the type (int, char, or string):");
            string type = Console.ReadLine();

            Console.WriteLine("Enter the first value:");
            string value1 = Console.ReadLine();

            Console.WriteLine("Enter the second value:");
            string value2 = Console.ReadLine();

            string result = "";

            if (type == "int")
            {
                result = CompareInt(int.Parse(value1), int.Parse(value2)).ToString();
            }
            else if (type == "char")
            {
                result = CompareChar(char.Parse(value1), char.Parse(value2)).ToString();
            }
            else if (type == "string")
            {
                result = CompareString(value1, value2);
            }
            else
            {
                Console.WriteLine("Invalid type entered.");
                return;
            }

            Console.WriteLine("Result: " + result);
        }

        static int CompareInt(int a, int b)
        {
            return Math.Max(a, b);
        }

        static char CompareChar(char a, char b)
        {
            return a > b ? a : b;
        }

        static string CompareString(string a, string b)
        {
            return string.Compare(a, b) > 0 ? a : b;
        }
    }
}

