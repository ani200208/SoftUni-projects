﻿namespace _02.NumbersFrom1ToN_Reversed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

           
            for (int i = n; i >= 1; i--)
            {
                Console.WriteLine(i);
            }
        }
    }
}
