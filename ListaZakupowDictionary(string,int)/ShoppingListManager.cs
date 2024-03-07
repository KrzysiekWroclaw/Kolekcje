using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaZakupowDictionary_String_Int
{
    public class ShoppingListManager
    {
        public static void ShowMenu()
        {
            Dictionary<string, int> listOfProducts = new Dictionary<string, int>();

            Dictionary<int, string> listOfOperations = new Dictionary<int, string> { { 1, "Dodaj produkt do listy"},
                                                                                     { 2, "Wyświetl listę zakupów"},
                                                                                     { 3, "Usuń produkt z listy"},
                                                                                     { 4, "Zakończ program\n" },
                                                                                   };
            while (true)
            {
                int numberOfOperation = ChoiseOperations(listOfOperations);

                if (numberOfOperation >= 1 && numberOfOperation <= 3)
                {
                    PerformOperation(numberOfOperation, listOfProducts);
                }
                else if (numberOfOperation == 4)
                { break; }
            }
        }

        public static int ChoiseOperations(Dictionary<int, string> listOfOperations)
        {
            int intNumberOfOperation;

            Console.WriteLine("Wybierz operację:\n");
            foreach (var key in listOfOperations)
            {
                Console.WriteLine($"{key.Key}. {key.Value}");
            }
            string stringNumberOfOperation = Console.ReadLine();

            if (int.TryParse(stringNumberOfOperation, out intNumberOfOperation)
                            && intNumberOfOperation >= 1
                            && intNumberOfOperation <= listOfOperations.Count)
            {
                Console.WriteLine($"Twój wybór: {intNumberOfOperation}");
                return intNumberOfOperation;
            }
            else
            {
                Console.WriteLine("Wprowadzono niepoprawną wartość.\n");
            }
            return intNumberOfOperation;
        }

        public static void PerformOperation(int intNumberOfOperation,
                                            Dictionary<string, int> listOfProducts)
        {
            if (intNumberOfOperation == 1)
            {
                AddProductToDictionary(listOfProducts);
            }
            else if (intNumberOfOperation == 2)
            {
                DisplayActualListOfProducts(listOfProducts);

            }
            else if (intNumberOfOperation == 3)
            {
                if (listOfProducts.Count != 0)
                {
                    RemoveProductFromList(listOfProducts);
                }
                else { Console.WriteLine("Koszyk pusty. Brak produktów do usunięcia.\n"); }
            }
            else if (intNumberOfOperation == 4)
            {
                return;
            }
        }
        public static void AddProductToDictionary(Dictionary<string, int> listOfProducts)
        {
            Console.WriteLine("Podaj nazwę produktu do dodania:");
            string product = Console.ReadLine();
            if (listOfProducts.ContainsKey(product))
            {
                listOfProducts[product]++;
            }
            else
            {
                listOfProducts.Add(product, 1);

            }
            DisplayActualListOfProducts(listOfProducts);
        }

        public static void DisplayActualListOfProducts(Dictionary<string, int> listOfProducts)
        {
            Console.WriteLine("Aktualna lista zakupów: ");
            if (listOfProducts.Count > 0)
            {
                foreach (var kvp in listOfProducts)
                {
                    Console.WriteLine($"{kvp.Key} - {kvp.Value} szt.");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Koszyk pusty\n");
            }
        }

        public static void RemoveProductFromList(Dictionary<string, int> listOfProducts)
        {
            Console.WriteLine("Podaj nazwę produktu do usunięcia:");
            string? product = Console.ReadLine();

            if (product != null && listOfProducts.ContainsKey(product))
            {
                listOfProducts.Remove(product);
                Console.WriteLine($"\nProdukt \"{product}\" usunięty z listy zakupów!\n");
            }
            else
            {
                Console.WriteLine($"Produktu \"{product}\" nie ma na liście!\n");
            }
           Console.WriteLine();
           DisplayActualListOfProducts(listOfProducts);
        }
    }
}