using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejkaZakupow
{
    class Operations
    {
        public static List<string> GetNewBasket()
        {
            Console.WriteLine("Dodaj produkty do koszyka (oddzielone spacją): ");
            string? entireText = Console.ReadLine();
            string[] basketTab = entireText.Split(' ');
            List<string> basketList = new List<string>(basketTab);
            Queue<List<string>> basketsQueue = new Queue<List<string>>();
            Queue<List<string>> kassQueue = new Queue<List<string>>();

            basketsQueue.Enqueue(basketList);

            Console.WriteLine("Następujące produkty dodane zostały do kolejki klientów: ");

            foreach (string product in basketList)
            {
                Console.Write($"{product} ");
            }
            Console.WriteLine("\n");
            return basketList;
        }

        public static void MoveBasketToKassQueue(Queue<List<string>> basketsQueue, Queue<List<string>> kassQueue)
        {
            List<string> basket;
            if (basketsQueue.Count > 0)
            {
                basket = basketsQueue.Dequeue();
                kassQueue.Enqueue(basket);
                Console.WriteLine("Obsłużony klient. Zawartość koszyka przeniesionego do kolejki kasowej: ");
                foreach (string product in basket)
                {
                    Console.Write($"{product} ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Kolejka koszyków jest pusta. Brak koszyków do przesunięcia.\n");
            }
        }
        public static void DecisionYorN(Queue<List<string>> basketsQueue,
                                        Queue<List<string>> kassQueue)
        {
            if (basketsQueue.Count > 0)
            {
                Console.WriteLine("Uwaga: nie wszystkie koszyki" +
                    " zostały przesunięte do kolejki kasowej! " +
                    " Czy chcesz je wszystkie teraz tam przesunąć? Wpisz \"tak/nie\"");
                string? yesOrNo = Console.ReadLine();
                if (yesOrNo == "tak")
                {
                    while (basketsQueue.Count > 0)
                    {
                        Operations.MoveBasketToKassQueue(basketsQueue, kassQueue);
                    }
                }
                else if (yesOrNo == "nie")
                {
                    Operations.MoveBasketToKassQueue(basketsQueue, kassQueue);
                }
            }
            else
            {
                Operations.MoveBasketToKassQueue(basketsQueue, kassQueue);
            }        
        }
        public static void DisplayBasketsInKassQueue(Queue<List<string>> kassQueue)
        {
            if (kassQueue.Count > 0)
            {
                Console.WriteLine("Lista koszyków w kolejce kasowej: ");
                int i = 1;
                foreach (List<string> list in kassQueue)
                {
                    Console.Write($"{i}. ");
                    int j = 1;
                    foreach (var item in list)
                    {
                        Console.Write($"{item}");
                        if (j < (list.Count))
                        {
                            Console.Write(", ");
                            j++;
                        }
                    }
                    i++;
                    Console.WriteLine();
                }
            }            
            Console.WriteLine("Program zakończony.");
        }
    }
}