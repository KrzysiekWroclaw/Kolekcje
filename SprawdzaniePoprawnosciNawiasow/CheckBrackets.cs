using System;
using System.Collections;
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

            foreach (char character in entireText)
            {
                CheckingCompatibilitingBrakets(character, openingBracketsStack);
            }
            CheckIsOpeningBrWithoutClosingBr(openingBracketsStack);
        }


        private char? GetOppositeBracket(char character)
        {
            if (character == ')')
            {
                return '(';
            }
            else if (character == ']')
            {
                return '[';
            }
            else if (character == '}')
            {
                return '{';
            }
            else if (character == '(')
            {
                return ')';
            }
            else if (character == '[')
            {
                return ']';
            }
            else if (character == '{')
            {
                return '}';
            }
            else return null;
        }

        private char? GetOpeningBracket(char character)
        {
            if (character == '(' || character == '[' || character == '{')
            {
                return character;
            }
            else return null;
        }
        private char? GetClosingBracket(char character)
        {
            if ((character == ')' || character == ']' || character == '}'))
            {
                return character;
            }
            else return null;
        }

        private bool CheckingCompatibilitingBrakets(char character, Stack<char> openingBracketsStack)
        {
            if (character == GetOpeningBracket(character))
            {
                openingBracketsStack.Push(character);
            }
            else if (character == GetClosingBracket(character))
            {
                if (openingBracketsStack.Count > 0)
                {
                    char lastOpeningBracket = openingBracketsStack.Peek();
                    if (character == GetOppositeBracket(lastOpeningBracket))
                    {
                        openingBracketsStack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("Wyrażenie matematyczne nie jest poprawne pod względem nawiasów.\n" +
                            $"Nawias zamykający {character} nie pasuje do nawiasu otwierającego {lastOpeningBracket}");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine($"Wyrażenie matematyczne nie jest poprawne pod względem nawiasów.\n" +
                        $"Napotkano nawias zamykający {character} bez wcześniejszego nawiasu otwierającego.");
                    return false;
                }
            }
            return false;
        }

        private void CheckIsOpeningBrWithoutClosingBr(Stack<char> openingBracketsStack)
        {
            if (openingBracketsStack.Count > 0)
            {
                Console.WriteLine($"Wyrażenie matematyczne nie jest poprawne pod względem nawiasów.");
                foreach (char character in openingBracketsStack)
                {
                    Console.WriteLine($"Brakuje nawiasu zamykającego {GetOppositeBracket(character)}.");
                }
            }
        }
    }
}