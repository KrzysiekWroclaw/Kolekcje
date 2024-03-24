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
            foreach (char character in entireText)
            {
                CheckExistsClosingBrWithoutOpeningBr(character);
                CheckExistsClosingBracket(character);
                CheckCompatibilityClosingToOpeningBracket(character);
            }
        }

        private bool IsOpeningBracket(char character)
        {
            if (character == '(' || character == '[' || character == '{')
            {
                return true;
            }
            else return false;
        }
        private bool IsClosingBracket(char character)
        {
            if ((character == ')' || character == ']' || character == '}'))
            {
                return true;
            }
            else return false;
        }

        private char GetLastOpeningBracket(Stack<char> openingBracketsStack)
        {
            char lastOpeningBracket = openingBracketsStack.Pop();
            return lastOpeningBracket;
        }

        private char GetCorrectOpeningBrForClosingBr(char character)
        {
            char correctOpeningBrForClosingBr = ' ';

            if (character == ')')
            {
                correctOpeningBrForClosingBr = '(';
            }
            else if (character == ']')
            {
                correctOpeningBrForClosingBr = '[';
            }
            else if (character == '}')
            {
                correctOpeningBrForClosingBr = '{';
            }
            return correctOpeningBrForClosingBr;
        }

        private Stack<char> AddOpeningBracketToOpeningBrStack(char character, Stack<char> openingBracketsStack)
        {
            openingBracketsStack.Push(character);
            return openingBracketsStack;
        }


        private void CheckExistsClosingBrWithoutOpeningBr(char character)
        {
            Stack<char> openingBracketsStack = new Stack<char>();
            char lastOpeningBracket = new char();
                if (IsOpeningBracket(character))
                {
                    AddOpeningBracketToOpeningBrStack(character, openingBracketsStack);
                }
                else if (IsClosingBracket(character))
                {
                    if (openingBracketsStack.Count > 0)
                    {
                        lastOpeningBracket = GetLastOpeningBracket(openingBracketsStack);
                    }

                    if (lastOpeningBracket != GetCorrectOpeningBrForClosingBr(character))
                    {
                        Console.WriteLine("Wyrażenie matematyczne nie jest poprawne pod względem nawiasów. ");
                        Console.WriteLine($"Napotkano nawias zamykający {character}" +
                                          $" bez wcześniejszego nawiasu otwierającego.");
                    }
                }
        }

        private void CheckExistsClosingBracket(char character)
        {
            Stack<char> openingBracketsStack = new Stack<char>();
            char lastOpeningBracket = new char();           
            {
                if (IsOpeningBracket(character))
                {
                    AddOpeningBracketToOpeningBrStack(character, openingBracketsStack);
                }
                else if (IsClosingBracket(character))
                {
                    if (openingBracketsStack.Count > 0)
                    {
                        lastOpeningBracket = GetLastOpeningBracket(openingBracketsStack);
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
        private void CheckCompatibilityClosingToOpeningBracket(char character)
        {
            Stack<char> openingBracketsStack = new Stack<char>();
            char lastOpeningBracket = new char();            
            {
                if (IsOpeningBracket(character))
                {
                    AddOpeningBracketToOpeningBrStack(character, openingBracketsStack);
                }
                else if (IsClosingBracket(character))
                {
                    if (openingBracketsStack.Count > 0)
                    {
                        lastOpeningBracket = GetLastOpeningBracket(openingBracketsStack);
                    }
                    if (IsClosingBracket(character) && IsOpeningBracket(lastOpeningBracket))
                    {
                        if (GetCorrectOpeningBrForClosingBr(character) != lastOpeningBracket)
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
}
