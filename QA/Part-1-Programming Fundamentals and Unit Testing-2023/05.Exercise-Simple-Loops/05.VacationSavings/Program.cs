namespace _05.VacationSavings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double moneyNeeded = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());

          
            int totalDays = 0;
            int consecutiveSpendingDays = 0;

          
            while (availableMoney < moneyNeeded && consecutiveSpendingDays < 5)
            {
                string action = Console.ReadLine();
                double amount = double.Parse(Console.ReadLine());
                totalDays++;

                if (action == "save")
                {
                    availableMoney += amount;
                    consecutiveSpendingDays = 0;
                }
                else if (action == "spend")
                {
                    availableMoney -= amount;
                    consecutiveSpendingDays++;

                    if (availableMoney < 0)
                        availableMoney = 0;
                }
            }

            
            if (consecutiveSpendingDays == 5)
            {
                Console.WriteLine($"You can't save the money.");
                Console.WriteLine($"{totalDays}");
            }
            else
            {
                Console.WriteLine($"You saved the money for {totalDays} days.");
            }
        }
    }
}
