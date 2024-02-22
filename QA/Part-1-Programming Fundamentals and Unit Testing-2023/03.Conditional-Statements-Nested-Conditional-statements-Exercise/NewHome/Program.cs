namespace NewHome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            int flowerCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double pricePerPiece = 0;

            switch (flowerType)
            {
                case "Roses":
                    pricePerPiece = 5;
                    if (flowerCount > 80)
                        pricePerPiece *= 0.9;
                    break;
                case "Dahlias":
                    pricePerPiece = 3.80;
                    if (flowerCount > 90)
                        pricePerPiece *= 0.85;
                    break;
                case "Tulips":
                    pricePerPiece = 2.80;
                    if (flowerCount > 80)
                        pricePerPiece *= 0.85;
                    break;
                case "Narcissus":
                    pricePerPiece = 3;
                    if (flowerCount < 120)
                        pricePerPiece *= 1.15;
                    break;
                case "Gladiolus":
                    pricePerPiece = 2.50;
                    if (flowerCount < 80)
                        pricePerPiece *= 1.20;
                    break;
            }

            double totalCost = flowerCount * pricePerPiece;
            double sumLeft = Math.Abs(budget - totalCost);

            if (totalCost <= budget)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowerCount} {flowerType} and {sumLeft:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {sumLeft:f2} leva more.");
            }
        }
    }
}
