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
            int intNumberOfItems = ReadNumberOfItems();
            Console.WriteLine();

            double[] items = ReadItems(intNumberOfItems);
            Console.WriteLine();

            int intNumberOfOperation = ChoiceNumberOfOperation();
            Console.WriteLine();

            Calculate(items, intNumberOfOperation);
        }

        //Metods:

        private static int ReadNumberOfItems()
        {
            int intNumberOfItems;
            while (true)
            {
                Console.Write("Program: Kalkulator statystyczny.\nPodaj liczbę elementów zestawu danych: ");
                string stringNumberOfItems = Console.ReadLine();
                if (int.TryParse(stringNumberOfItems, out intNumberOfItems) || intNumberOfItems >= 1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wprowadzono niepoprawną wartość.\n");
                }
            }
            return intNumberOfItems;
            Console.WriteLine();
        }

        private static double[] ReadItems(int intNumberOfItems)
        {
            Console.Write("Wprowadź dane liczbowe: \n");
            double doubleItem;
            double[] items = new double[intNumberOfItems];
            int numberOfItem = 1;
            for (int i = 0; i < intNumberOfItems; i++)
            {
                Console.Write($"{numberOfItem}. Wprowadź liczbę: ");
                string stringItem = Console.ReadLine();

                if (double.TryParse(stringItem, out doubleItem))
                {
                    items[i] = doubleItem;
                    numberOfItem++;
                }
                else
                {
                    Console.WriteLine("Wprowadzono niepoprawną wartość.\n");
                    i--;
                }
            }
            return items;
        }

        private static int ChoiceNumberOfOperation()
        {
            int intNumberOfOperation;
            while (true)
            {
                Console.WriteLine("Wybierz operację statystyczną:");
                string[] Operations = { "1. Średnia arytmetyczna", "2. Największa liczba", "3. Najmniejsza liczba", "4. Suma wszystkich liczb" };
                foreach (string operation in Operations)
                {
                    Console.WriteLine(operation);
                }

                string stringNumberOfOperation = Console.ReadLine();
                if (int.TryParse(stringNumberOfOperation, out intNumberOfOperation) && intNumberOfOperation >= 1 && intNumberOfOperation <= Operations.Length)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wprowadzono niepoprawną wartość.");
                }
            }
            Console.WriteLine($"Twój wybór: {intNumberOfOperation}");
            return intNumberOfOperation;
        }

        private static void Calculate(double[] items, int intNumberOfOperation)
        {
            switch (intNumberOfOperation)
            {
                case 1:
                    Calculations.Average(items);
                    break;
                case 2:
                    Calculations.ItemMax(items);
                    break;
                case 3:
                    Calculations.ItemMin(items);
                    break;
                case 4:
                    Calculations.SumOfItems(items);
                    break;
            }
        }
    }
}