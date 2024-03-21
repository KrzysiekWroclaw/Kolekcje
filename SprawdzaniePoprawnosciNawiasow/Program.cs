using System;
using System.Collections;

namespace SprawdzaniePoprawnosciNawiasow
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Program: Sprawdzanie poprawności nawiasów.\n" +
                             "Wprowadź wyrażenie matematyczne: ");
            string? entireText = Console.ReadLine();

            char lastOpeningBracket = new char();

            CheckBrackets.CheckExistsClosingBrWithoutOpeningBr(entireText, lastOpeningBracket);
            Console.WriteLine();

            CheckBrackets.CheckExistsClosingBraket(entireText);
            Console.WriteLine();
            
            CheckBrackets.CheckCompatibilityClosingToOpeningBracket(entireText, lastOpeningBracket);
        }
    }
}