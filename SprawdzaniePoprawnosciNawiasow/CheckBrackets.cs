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
            Stack<char> openingBracketsStack = new Stack<char>();
            Stack<char> closingBracketsStack = new Stack<char>();
            char lastOpeningBracket = new char();

            foreach (char character in entireText)
            {
                CheckExistsClosingBracket(character, openingBracketsStack, closingBracketsStack, lastOpeningBracket);
                CheckExistsClosingBrWithoutOpeningBr(character, openingBracketsStack, closingBracketsStack, lastOpeningBracket);
                CheckCompatibilityClosingToOpeningBracket(character, openingBracketsStack, lastOpeningBracket);
            }
        }

        private char? GetOpeningBracket(char character)
        {
            if (character == '(' || character == '[' || character == '{')
            {
                return character;
            }
            return null;
        }
        private char? GetClosingBracket(char character)
        {
            if ((character == ')' || character == ']' || character == '}'))
            {
                return character;
            }
            else return null;
        }

        private char GetLastOpeningBracket(Stack<char> openingBracketsStack)
        {
            char lastOpeningBracket = openingBracketsStack.Pop();
            return lastOpeningBracket;
        }

        private char GetCorrectOppositeBracket(char character)
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
            else if (character == '(')
            {
                correctOpeningBrForClosingBr = ')';
            }
            else if (character == '[')
            {
                correctOpeningBrForClosingBr = ']';
            }
            else if (character == '{')
            {
                correctOpeningBrForClosingBr = '}';
            }
            return correctOpeningBrForClosingBr;
        }

        private void AddOpeningBracketToOpeningBrStack(char character, Stack<char> openingBracketsStack)
        {
            openingBracketsStack.Push(character);
        }

        private void AddClosingBracketToClosingBrStack(char character, Stack<char> closingBracketsStack)
        {
            closingBracketsStack.Push(character);
        }

        private void CheckExistsClosingBrWithoutOpeningBr(char character, Stack<char> openingBracketsStack,
                                                            Stack<char> closingBracketsStack, char lastOpeningBracket)
        {
            char firstClosingBracket = ' ';
            if (character == GetOpeningBracket(character))
            {
                AddOpeningBracketToOpeningBrStack(character, openingBracketsStack);
            }
            else if (character == GetClosingBracket(character))
            {
                AddClosingBracketToClosingBrStack(character, closingBracketsStack);

                if (openingBracketsStack.Count > 0)
                {
                    if ((openingBracketsStack.Peek() == GetCorrectOppositeBracket(closingBracketsStack.Peek())))
                    {
                        lastOpeningBracket = GetLastOpeningBracket(openingBracketsStack);
                        firstClosingBracket = closingBracketsStack.Pop();
                    }
                }
                else if (closingBracketsStack.Count > openingBracketsStack.Count)
                {
                    Console.WriteLine("Wyrażenie matematyczne nie jest poprawne pod względem nawiasów. ");
                    Console.WriteLine($"Napotkano nawias zamykający {character}" +
                                          $" bez wcześniejszego nawiasu otwierającego.");
                }
            }
        }

        private void CheckExistsClosingBracket(char character, Stack<char> openingBracketsStack,
                                                Stack<char> closingBracketsStack, char lastOpeningBracket)
        {
            char firstClosingBracket = ' ';
            if (character == GetOpeningBracket(character))
            {
                AddOpeningBracketToOpeningBrStack(character, openingBracketsStack);
            }

            else if (character == GetClosingBracket(character))
            {
                AddClosingBracketToClosingBrStack(character, closingBracketsStack);

                if (openingBracketsStack.Count > 0)
                {
                    if ((openingBracketsStack.Peek() == GetCorrectOppositeBracket(closingBracketsStack.Peek())))
                    {
                        lastOpeningBracket = GetLastOpeningBracket(openingBracketsStack);
                        firstClosingBracket = closingBracketsStack.Pop();
                    }
                    if (closingBracketsStack.Count < openingBracketsStack.Count)
                    {
                        Console.WriteLine($"Wyrażenie matematyczne nie jest poprawne pod względem nawiasów.\n" +
                                        $"Brakuje nawiasu zamykającego {GetCorrectOppositeBracket(openingBracketsStack.Peek())}.");
                    }
                }                
            }

        }
        private void CheckCompatibilityClosingToOpeningBracket(char character, Stack<char> openingBracketsStack,
                                                                char lastOpeningBracket)
        {

            if (character == GetOpeningBracket(character))
            {
                AddOpeningBracketToOpeningBrStack(character, openingBracketsStack);
            }
            else if (character == GetClosingBracket(character))
            {
                if (openingBracketsStack.Count > 0)
                {
                    lastOpeningBracket = GetLastOpeningBracket(openingBracketsStack);
                }
                if (character != GetCorrectOppositeBracket(lastOpeningBracket))
                //if (IsClosingBracket(character) && IsOpeningBracket(lastOpeningBracket))

                {
                    Console.WriteLine("Wyrażenie matematyczne nie jest poprawne pod względem nawiasów.");
                    Console.WriteLine($"Nawias zamykający {character} nie pasuje do nawiasu" +
                        $" otwierającego {lastOpeningBracket}.");
                }
            }

        }

    }
}