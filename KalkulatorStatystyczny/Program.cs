using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Channels;

namespace KalkulatorStatystyczny
{
    public class Program
    {
        static void Main(string[] args)
        {
            int intNumberOfItems; 
            while (true)
            {                    
                Console.Write("Program: Kalkulator statystyczny.\nPodaj liczbę elementów zestawu danych: ");
                string stringNumberOfItems = Console.ReadLine();
                    if(int.TryParse(stringNumberOfItems, out intNumberOfItems) || intNumberOfItems >= 1)
                        {
                        break;
                        }
                    else
                        {
                            Console.WriteLine("Wprowadzono niepoprawną wartość.\n");                    
                        }              
            }
            Console.WriteLine();

            //--------------------------------------------------------------------------------

            List<double> items = [];
                        
            Console.Write("Wprowadź dane liczbowe: \n");

            double doubleItem;
            for(int i = 1; i <= intNumberOfItems;)
            {
                Console.Write(i + ". Wprowadź liczbę: ");
                string stringItem = Console.ReadLine();
                if (double.TryParse(stringItem, out doubleItem))
                {
                    items.Add(doubleItem);
                    i++;
                }
                else
                {
                    Console.WriteLine("Wprowadzono niepoprawną wartość.\n");
                }
            }
            Console.WriteLine();

            //--------------------------------------------------------------------------------

            int intOperationNumer;
            while (true)
            {
            Console.WriteLine(@"Wybierz operację statystyczną:
            1. Średnia arytmetyczna
            2. Największa liczba
            3. Najmniejsza liczba
            4. Suma wszystkich liczb");

                string stringOperationNumer = Console.ReadLine();
                if (int.TryParse(stringOperationNumer, out intOperationNumer) && intOperationNumer >= 1 && intOperationNumer <= 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wprowadzono niepoprawną wartość.");
                }
            }
            Console.WriteLine("Twój wybór: " + intOperationNumer);
            Console.WriteLine();

            //--------------------------------------------------------------------------------

            switch (intOperationNumer)
            {
                case 1: Console.WriteLine("Średnia arytmetyczna wynosi: " + items.Average());
                    break;
                case 2: Console.WriteLine("Największa wprowadzona liczba to: " + items.Max());
                    break;
                case 3: Console.WriteLine("Najmniejsza wprowadzona liczba to: " + items.Min());
                    break;
                case 4: Console.WriteLine("Suma liczb wynosi: " + items.Sum());
                    break;
            }
        }
    }
}