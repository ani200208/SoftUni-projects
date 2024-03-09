namespace _04.CalculateRectangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the width:");
            int width = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the length:");
            int length = Convert.ToInt32(Console.ReadLine());

            int area = CalculateRectangleArea(width, length);
            Console.WriteLine("The area of the rectangle is: " + area);
        }

        static int CalculateRectangleArea(int width, int length)
        {
            return width * length;
        }
    }
}

