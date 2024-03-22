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
            CheckExistsClosingBracket(entireText);
            Console.WriteLine();
            CheckCompatibilityClosingToOpeningBracket(entireText);
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
        private Stack<char> AddOpeningBracketToOpeningBrStack(char character, Stack<char> openingBracketsStack)
        {
            openingBracketsStack.Push(character);
            return openingBracketsStack;
        }
        private char GetLastOpeningBracket(Stack<char> openingBracketsStack)
        {
            char lastOpeningBracket = openingBracketsStack.Pop();
            return lastOpeningBracket;
            
        }
        private bool IsIncorrectOpeningToClosingBracket(char character, char lastOpeningBracket)
        {
            if ((character == ')' && lastOpeningBracket != '(') ||
                (character == ']' && lastOpeningBracket != '[') ||
                (character == '}' && lastOpeningBracket != '{')
              )
                return true;
            else
            { return false; }
        }
        private bool MatchesOpeningBracketToClosingBracket(char character, char lastOpeningBracket)
        {

          if    (
                character == ')' && (lastOpeningBracket == '[' || lastOpeningBracket == '{') ||
                character == ']' && (lastOpeningBracket == '(' || lastOpeningBracket == '{') ||
                character == '}' && (lastOpeningBracket == '[' || lastOpeningBracket == '(')
                )
                    return true;
          else return false;
        }


        private void CheckExistsClosingBrWithoutOpeningBr(string entireText)
        {
            Stack<char> openingBracketsStack = new Stack<char>();
            char lastOpeningBracket = new char();
            foreach (char character in entireText)
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

                    if (IsIncorrectOpeningToClosingBracket(character, lastOpeningBracket))
                    {
                        Console.WriteLine("Wyrażenie matematyczne nie jest poprawne pod względem nawiasów. ");
                        Console.WriteLine($"Napotkano nawias zamykający {character}" +
                                          $" bez wcześniejszego nawiasu otwierającego.");
                    }
                }
            }
        }

        private void CheckExistsClosingBracket(string entireText)
        {
            Stack<char> openingBracketsStack = new Stack<char>();
            char lastOpeningBracket = new char();
            foreach (char character in entireText)
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
        private void CheckCompatibilityClosingToOpeningBracket(string entireText)
        {
            Stack<char> openingBracketsStack = new Stack<char>();
            char lastOpeningBracket = new char();

            foreach (char character in entireText)
            {
                if (IsOpeningBracket(character))
                {
                    AddOpeningBracketToOpeningBrStack(character, openingBracketsStack);
                }
                else if (character == ')' || character == ']' || character == '}')
                {
                    if (openingBracketsStack.Count > 0)
                    {
                        lastOpeningBracket = GetLastOpeningBracket(openingBracketsStack);
                    }
                    if (MatchesOpeningBracketToClosingBracket(character, lastOpeningBracket))
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