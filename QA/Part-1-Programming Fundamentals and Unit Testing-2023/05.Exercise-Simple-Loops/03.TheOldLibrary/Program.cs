namespace _03.TheOldLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string favoriteBook = Console.ReadLine();



            int booksChecked = 0;
            bool bookFound = false;

            
            while (true)
            {
                string book = Console.ReadLine();

                
                if (book == "No More Books")
                {
                    
                    if (!bookFound)
                        Console.WriteLine($"The book you search is not here!\nYou checked {booksChecked} books.");
                    break; 
                }

                
                booksChecked++;

                
                if (book == "Troy") 
                {
                    bookFound = true;
                    Console.WriteLine($"You checked {booksChecked} books and found it.");
                    break; 
                }
            }
        }
    }
}
