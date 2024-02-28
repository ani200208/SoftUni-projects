namespace _08.BirthdayCake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());

            int cakePieces = width * length;

            string input;
            while ((input = Console.ReadLine()) != "STOP")
            {
                int takenPieces = int.Parse(input);
                cakePieces -= takenPieces;

                if (cakePieces < 0)
                {
                    int missingPieces = Math.Abs(cakePieces);
                    Console.WriteLine($"No more cake left! You need {missingPieces} pieces more.");
                    return;
                }
            }

            Console.WriteLine($"{cakePieces} pieces are left.");
        }
    }
    
}
