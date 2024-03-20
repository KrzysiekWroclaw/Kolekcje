using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprawdzaniePoprawnosciNawiasow
{
    public class CheckBrackets
    {
        public static void iterateThroughCharacters(string entireText)
        {
            Stack<char> openBracketsStack = new Stack<char>();
            
            foreach (char character in entireText)
            {
                if (character == '(' || character == '[' || character == '{')
                {
                    openBracketsStack.Push(character);
                }

                char lastOpenedBracket;
                if ((character == ')' || character == ']' || character == '}'))
                {
                    lastOpenedBracket = openBracketsStack.Pop();

                    if (character == ')' && lastOpenedBracket != '(')
                    {
                        Console.WriteLine("Napotkano nawias zamykający ) bez wcześniejszego nawiasu otwierającego.");
                    }
                    if (character != ')' && lastOpenedBracket == '(')
                    {
                        Console.WriteLine("Brakuje nawiasu zamykającego ).");
                    }
                    if (character == ')' && (lastOpenedBracket == '['))
                    {
                        Console.WriteLine("Nawias zamykający ) nie pasuje do otwierającego [. ");
                    }
                    if (character == ')' && lastOpenedBracket == '{')
                    {
                        Console.WriteLine("Nawias zamykający ) nie pasuje do otwierającego {. ");
                    }



                    if (character == ']' && lastOpenedBracket != '[')
                    {
                        Console.WriteLine("Napotkano nawias zamykający ] bez wcześniejszego nawiasu otwierającego.");
                    }
                    if (character != ']' && lastOpenedBracket == '[')
                    {
                        Console.WriteLine("Brakuje nawiasu zamykającego ].");
                    }
                    if (character == ']' && (lastOpenedBracket == '('))
                    {
                        Console.WriteLine("Nawias zamykający ] nie pasuje do otwierającego (. ");
                    }
                    if (character == ']' && lastOpenedBracket == '{')
                    {
                        Console.WriteLine("Nawias zamykający ) nie pasuje do otwierającego {. ");
                    }




                    if (character == '}' && lastOpenedBracket != '{')
                    {
                        Console.WriteLine("Napotkano nawias zamykający } bez wcześniejszego nawiasu otwierającego.");
                    }
                    if (character != '}' && lastOpenedBracket == '{')
                    {
                        Console.WriteLine("Brakuje nawiasu zamykającego }.");
                    }
                    if (character == '}' && (lastOpenedBracket == '('))
                    {
                        Console.WriteLine("Nawias zamykający } nie pasuje do otwierającego (. ");
                    }
                    if (character == '}' && lastOpenedBracket == '[')
                    {
                        Console.WriteLine("Nawias zamykający } nie pasuje do otwierającego [. ");
                    }
                }
                    
                
            }
        }
    }
}