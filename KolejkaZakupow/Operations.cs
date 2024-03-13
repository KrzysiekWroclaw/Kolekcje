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
            string[] shoppingTab = entireText.Split(' ');
            List<string> basket = new List<string>();

            foreach (string product in shoppingTab)
            {
                basket.Add(product);
            }
           
            Console.WriteLine("Produkty dodane do koszyka!:\n");
            return basket;
           
        }

        public static Queue<List<string>> MoveBasketToKassQueue(Queue<List<string>> queueOfBaskets, Queue<List<string>> KassQueue)
        {
            while (queueOfBaskets.Count > 0)
            {
                List<string> products = queueOfBaskets.Dequeue();
                KassQueue.Enqueue(products);
                Console.WriteLine("Zawartość koszyka: "); 
                foreach (var item in products)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
                Console.WriteLine("Obsłużony klient. Koszyk przesunięty do kolejki kasowej.\n");
            }
            return KassQueue;


        }
    }

}
