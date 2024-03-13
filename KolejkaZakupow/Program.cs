using System;
using System.Collections;
using System.Collections.Generic;

namespace KolejkaZakupow
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(
@"Program: Kolejka zakupów.

1. Nowy klient - dodaj produkty do koszyka
2. Zakończ zakupy i obsłuż klienta
3. Zakończ program");
            Console.WriteLine();

            List<string> basket = new List<string>();
            Queue<List<string>> queueOfBaskets = new Queue<List<string>>();
            Queue<List<string>> KassQueue = new Queue<List<string>>();


            while (true)
            {
                Console.WriteLine("Wprowadź wartość od 1 do 3: ");
                int operationNumber = Convert.ToInt32(Console.ReadLine());


                if (operationNumber == 1)
                {
                    Console.WriteLine("Twój wybór: 1");
                    basket = Operations.GetNewBasket();
                    queueOfBaskets.Enqueue(basket);                    

                }
                if (operationNumber == 2)
                {
                    Console.WriteLine("Twój wybór: 2");
                    Operations.MoveBasketToKassQueue(queueOfBaskets, KassQueue);
                   
                   
                }
                if (operationNumber == 3)
                {

                }
                //else
                //{
                //    Console.WriteLine("Wprowadzono niepoprawną wartość. Wprowadź poprawną wartość: \n");
                //}
            }
        }










        //List<string> currentList = queue.Dequeue();
        //foreach (string product in currentList)
        //{
        //    Console.WriteLine(product);
        //}



    }


}