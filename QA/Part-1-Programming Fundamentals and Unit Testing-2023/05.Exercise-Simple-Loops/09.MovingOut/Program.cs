namespace _09.MovingOut
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int totalVolume = width * length * height;

            string input;
            while ((input = Console.ReadLine()) != "Done")
            {
                int boxesVolume = int.Parse(input);
                totalVolume -= boxesVolume;

                if (totalVolume <= 0)
                {
                    int neededVolume = Math.Abs(totalVolume);
                    Console.WriteLine($"No more free space! You need {neededVolume} Cubic meters more.");
                    return;
                }
            }

            Console.WriteLine($"{totalVolume} Cubic meters left.");
        }
    }
    
}
