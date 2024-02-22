namespace _09.SkiHoliday
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int daysToStay = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string assessment = Console.ReadLine();

            
            int nights = daysToStay - 1;

            
            double pricePerNight = 0;
            switch (roomType)
            {
                case "room for one person":
                    pricePerNight = 118.00;
                    break;
                case "apartment":
                    pricePerNight = 155.00;
                    break;
                case "president apartment":
                    pricePerNight = 235.00;
                    break;
            }

            
            double totalPrice = nights * pricePerNight;

            
            if (daysToStay > 15)
            {
                switch (roomType)
                {
                    case "apartment":
                        totalPrice *= 0.50;
                        break;
                    case "president apartment":
                        totalPrice *= 0.80;
                        break;
                }
            }
            else if (daysToStay >= 10 && daysToStay <= 15)
            {
                switch (roomType)
                {
                    case "apartment":
                        totalPrice *= 0.65;
                        break;
                    case "president apartment":
                        totalPrice *= 0.85;
                        break;
                }
            }
            else if (daysToStay < 10 && daysToStay > 0)
            {
                
            }
            else
            {
                
                Console.WriteLine("Invalid number of days.");
                return;
            }

           
            if (assessment == "positive")
            {
                totalPrice *= 1.25;
            }
            else if (assessment == "negative")
            {
                totalPrice *= 0.90;
            }

            
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
    
    
}
