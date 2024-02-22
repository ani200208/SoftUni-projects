namespace _04.FishingBoat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermenCount = int.Parse(Console.ReadLine());

            double boatRentPrice = 0;

            switch (season)
            {
                case "Spring":
                    boatRentPrice = 3000;
                    break;
                case "Summer":
                case "Autumn":
                    boatRentPrice = 4200;
                    break;
                case "Winter":
                    boatRentPrice = 2600;
                    break;
            }

            if (fishermenCount <= 6)
            {
                boatRentPrice *= 0.9;
            }
            else if (fishermenCount >= 7 && fishermenCount <= 11)
            {
                boatRentPrice *= 0.85;
            }
            else // fishermenCount >= 12
            {
                boatRentPrice *= 0.75;
            }

            if (fishermenCount % 2 == 0 && season != "Autumn")
            {
                boatRentPrice *= 0.95;
            }

            double moneyLeft = budget - boatRentPrice;
            double moreMoney = Math.Abs(moneyLeft);

            if (moneyLeft >= 0)
            {
                Console.WriteLine($"Yes! You have {moneyLeft:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {moreMoney:f2} leva.");
            }
        }
    }
}
