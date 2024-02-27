namespace _07.AccountBalance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double totalBalance = 0;

            
            while (true)
            {
                string input = Console.ReadLine();

                
                if (input == "NoMoreMoney")
                    break;

                
                double amount;
                if (!double.TryParse(input, out amount))
                {
                    Console.WriteLine("Invalid operation!");
                    return;
                }

                
                if (amount < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    return;
                }

                
                totalBalance += amount;
                Console.WriteLine("Increase: " + amount.ToString("F2"));
            }

            
            Console.WriteLine("Total: " + totalBalance.ToString("F2"));
        }
    }
    
}
