namespace _07.Coin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());

            
            int changeInStotinki = (int)(change * 100);

            
            int[] coinValues = { 200, 100, 50, 20, 10, 5, 2, 1 };

            
            int coinCount = 0;

            
            for (int i = 0; i < coinValues.Length; i++)
            {
                
                int coinsNeeded = changeInStotinki / coinValues[i];

                
                coinCount += coinsNeeded;

                
                changeInStotinki %= coinValues[i];
            }

            Console.WriteLine(coinCount);
        }
    }
    
}
