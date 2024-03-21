using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprawdzaniePoprawnosciNawiasow
{
    public class CheckBrackets
    {
        public static void CheckExistsClosingBrWithoutOpeningBr(string entireText, char lastOpeningBracket)
        {
            Stack<char> openingBracketsStack = new Stack<char>();
            foreach (char character in entireText)
            {
                if (character == '(' || character == '[' || character == '{')
                {
                    openingBracketsStack.Push(character);

                }
                else if (character == ')' || character == ']' || character == '}')
                {
                    if (openingBracketsStack.Count > 0)
                    {
                        lastOpeningBracket = openingBracketsStack.Pop();
                    }
                    if (
                        (character == ')' && lastOpeningBracket != '(') ||
                        (character == ']' && lastOpeningBracket != '[') ||
                        (character == '}' && lastOpeningBracket != '{')
                        )
                    {
                        Console.WriteLine("Wyrażenie matematyczne nie jest poprawne pod względem nawiasów. ");
                        Console.WriteLine($"Napotkano nawias zamykający {character}" +
                                          $" bez wcześniejszego nawiasu otwierającego.");
                    }
                }
            }
            
        }

        public static void CheckExistsClosingBraket(string entireText)
        {
            Stack<char> openingBracketsStack = new Stack<char>();
            foreach (char character in entireText)
            {
                if (character == '(' || character == '[' || character == '{')
                {
                    openingBracketsStack.Push(character);
                }
                else if (character == ')' || character == ']' || character == '}')
                {
                    if (openingBracketsStack.Count > 0)
                    {
                        openingBracketsStack.Pop();
                    }
                }
            }

            if (openingBracketsStack.Count > 0)
            {
                foreach (char ch in openingBracketsStack)
                {
                    if (ch == '(')
                    {
                        Console.WriteLine("Wyrażenie matematyczne nie jest poprawne pod względem nawiasów.\n" +
                            " Brakuje nawiasu zamykającego ).");
                    }
                    if (ch == '{')
                    {
                        Console.WriteLine("Wyrażenie matematyczne nie jest poprawne pod względem nawiasów.\n" +
                            " Brakuje nawiasu zamykającego }.");
                    }
                    if (ch == '[')
                    {
                        Console.WriteLine("Wyrażenie matematyczne nie jest poprawne pod względem nawiasów.\n" +
                            "Brakuje nawiasu zamykającego ].");
                    }
                }
            }
        }

        public static void CheckCompatibilityClosingToOpeningBracket(string entireText, char lastOpeningBracket)
        {
            Stack<char> openingBracketsStack = new Stack<char>();
            foreach (char character in entireText)
            {
                if (character == '(' || character == '[' || character == '{')
                {
                    openingBracketsStack.Push(character);

                }
                else if (character == ')' || character == ']' || character == '}')
                {
                    if (openingBracketsStack.Count > 0)
                    {
                        lastOpeningBracket = openingBracketsStack.Pop();
                    }
                    if (
                        (character == ')' && (lastOpeningBracket == '[' || lastOpeningBracket == '{')) ||
                        (character == ']' && (lastOpeningBracket == '(' || lastOpeningBracket == '{')) ||
                        (character == '}' && (lastOpeningBracket == '[' || lastOpeningBracket == '('))
                       )
                    {
                        Console.WriteLine("Wyrażenie matematyczne nie jest poprawne pod względem nawiasów.");
                        Console.WriteLine($"Nawias zamykający {character} nie pasuje do nawiasu" +
                            $" otwierającego {lastOpeningBracket}.");
                    }
                }
            }

        }
    }
}