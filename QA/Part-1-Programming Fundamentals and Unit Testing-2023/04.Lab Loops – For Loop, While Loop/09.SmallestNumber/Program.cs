namespace _09.SmallestNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minNumber = int.MaxValue; 

           
            while (true)
            {
                string input = Console.ReadLine();

               
                if (input == "Stop")
                    break;

                
                int number;
                if (!int.TryParse(input, out number))
                {
                    Console.WriteLine("Invalid input. Please enter an integer or 'Stop'.");
                    continue;
                }

                
                if (number < minNumber)
                {
                    minNumber = number;
                }
            }

            
            Console.WriteLine(minNumber);
        }
    }
    
}
