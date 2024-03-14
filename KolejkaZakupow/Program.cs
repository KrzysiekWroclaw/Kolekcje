using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace KolejkaZakupow
{    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(
@"Program: Kolejka zakupów.

1. Nowy klient - dodaj produkty do koszyka
2. Zakończ zakupy i obsłuż klienta
3. Zakończ program");
            Console.WriteLine();

            List<string> basketList = new List<string>();
            Queue<List<string>> basketsQueue = new Queue<List<string>>();
            Queue<List<string>> kassQueue = new Queue<List<string>>();

            while (true)
            {
                int operationNumber;
                while (true)
                {
                    Console.WriteLine($"Wprowadź wartość od 1 do 3: ");
                    string? stringOperationNumber = Console.ReadLine();
                    if (int.TryParse(stringOperationNumber, out operationNumber))
                    {break;}
                    else {Console.WriteLine("Wprowadzono niepoprawną wartość.\n");}
                    break;
                }
                if (operationNumber == 1)
                {
                    Console.WriteLine("Twój wybór: 1");
                    basketList = Operations.GetNewBasket();
                    basketsQueue.Enqueue(basketList);
                }
                else if (operationNumber == 2)
                {
                    Console.WriteLine("Twój wybór: 2");
                    Operations.MoveBasketToKassQueue(basketsQueue, kassQueue);
                }
                else if (operationNumber == 3)
                {
                    Console.WriteLine("Twój wybór: 3");                    
                    
                    Operations.MoveBasketsFromQueue(basketsQueue, kassQueue);
                    Operations.DisplayBasketsInKassQueue(kassQueue);
                    break;
                }
                else
                {
                    Console.WriteLine("Wprowadzono niepoprawną wartość. Wprowadź poprawną wartość: \n");
                }
            }
        }
    }
}