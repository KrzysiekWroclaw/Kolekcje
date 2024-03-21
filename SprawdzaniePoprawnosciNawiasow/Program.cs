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

            CheckBrackets.CheckClosingBrWithoutOpeningBr(entireText, lastOpeningBracket);
            CheckBrackets.CheckExistsClosingBraket(entireText);


        }
    }
}