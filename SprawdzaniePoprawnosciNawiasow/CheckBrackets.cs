using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprawdzaniePoprawnosciNawiasow
{
    public class BracketsChecker
    {
        public void CheckBrackets(string entireText)
        {
            CheckExistsClosingBrWithoutOpeningBr(entireText);
            Console.WriteLine();

            CheckExistsClosingBraket(entireText);
            Console.WriteLine();

            CheckCompatibilityClosingToOpeningBracket(entireText);
        }
        private void CheckExistsClosingBrWithoutOpeningBr(string entireText)
        {
            Stack<char> openingBracketsStack = new Stack<char>();
            char lastOpeningBracket = new char();
            foreach (char character in entireText)
            {
                if (character != '(' && character != '[' && character != '{')
                {
                    if (character == ')' || character == ']' || character == '}')
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
                else
                {
                    openingBracketsStack.Push(character);
                }
            }
            
        }

        private void CheckExistsClosingBraket(string entireText)
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

        private void CheckCompatibilityClosingToOpeningBracket(string entireText)
        {
            Stack<char> openingBracketsStack = new Stack<char>();
            char lastOpeningBracket = new char();

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