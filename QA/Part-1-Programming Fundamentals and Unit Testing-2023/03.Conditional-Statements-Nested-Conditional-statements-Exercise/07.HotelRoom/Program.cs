namespace _07.HotelRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double studioPrice = 0;
            double apartmentPrice = 0;

            switch (month)
            {
                case "May":
                case "October":
                    studioPrice = 50 * nights;
                    apartmentPrice = 65 * nights;
                    if (nights > 14)
                    {
                        studioPrice *= 0.7; 
                    }
                    else if (nights > 7)
                    {
                        studioPrice *= 0.95; 
                    }
                    break;
                case "June":
                case "September":
                    studioPrice = 75.20 * nights;
                    apartmentPrice = 68.70 * nights;
                    if (nights > 14)
                    {
                        studioPrice *= 0.8; 
                    }
                    break;
                case "July":
                case "August":
                    studioPrice = 76 * nights;
                    apartmentPrice = 77 * nights;
                    break;
            }

            if (nights > 14)
            {
                apartmentPrice *= 0.9; 
            }

            Console.WriteLine($"Apartment: {apartmentPrice:f2} lv.");
            Console.WriteLine($"Studio: {studioPrice:f2} lv.");
        }
    }
    
}
