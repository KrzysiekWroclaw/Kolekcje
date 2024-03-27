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
            int index = 0;            

            foreach (char character in entireText)
            {
                index++;
                bool b = IsCompatibilitingBrakets(character, openingBracketsStack, entireText);
                if (index == entireText.Length && b == true)
                {
                    IsOpeningBrWithoutClosingBr(openingBracketsStack);
                }
            }
        }                               

        private char? GetOppositeBracket(char character)       
        {
            switch (character)
            {
                case ')':
                    return '(';
                    
                case ']':
                    return '[';

                case '}':
                    return '{';
                    
                case '(':
                    return ')';

                case '[':
                    return ']';

                case '{':
                    return '}';

                default: return null;
            }
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

        private Stack<char> PushCharToStack(char character, Stack<char> stack)
        {
            stack.Push(character);
            return stack;
        }

        private char PeekCharFromStack(Stack<char> stack)
        {
            char character = stack.Peek();
            return character;
        }

        private char PopCharFromStack(Stack<char> stack)
        {
            char character = stack.Pop();
            return character;
        }

        private bool IsCompatibilitingBrakets(char character, Stack<char> openingBracketsStack, string entireText)
        {
            if (character == GetOpeningBracket(character))
            {
                PushCharToStack(character, openingBracketsStack);
            }
            else if (character == GetClosingBracket(character))
            {
                if (openingBracketsStack.Count > 0)
                {
                    char lastOpeningBracket = PeekCharFromStack(openingBracketsStack);
                    if (character == GetOppositeBracket(lastOpeningBracket))
                    {
                        PopCharFromStack(openingBracketsStack);
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
            return true;
        }

        
        private bool IsOpeningBrWithoutClosingBr(Stack<char> openingBracketsStack)
        {
            if (openingBracketsStack.Count > 0)
            {
                Console.WriteLine($"Wyrażenie matematyczne nie jest poprawne pod względem nawiasów.");
                foreach (char character in openingBracketsStack)
                {
                    Console.WriteLine($"Brakuje nawiasu zamykającego {GetOppositeBracket(character)}.");
                }
                return true;
            }
            else return false;
        }
    }
}