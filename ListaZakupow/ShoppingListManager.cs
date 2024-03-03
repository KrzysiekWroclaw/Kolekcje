using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaZakupow
{
    public class ShoppingListManager
    {
        public static void AddProductToList(List<string> listOfProducts)
        {
            Console.WriteLine("Podaj nazwę produktu do dodania:");          //test
            string product = Console.ReadLine();

            string? foundElement = null;
            foreach (string item in listOfProducts)
            {
                int result = string.Compare(item, product, true);

                if (result == 0)
                {
                    foundElement = item;
                    break;
                }
            }
            if (foundElement != null)
            {
                Console.WriteLine($"\nNie dodano produktu {product}, bo jest już na liście!\n");
            }
            else
            {
                listOfProducts.Add(product);
                Console.WriteLine($"Produkt \"{product}\" dodano do listy zakupów.\n");
            }
            DisplayActualListOfProducts(listOfProducts);
        }

        public static void DisplayActualListOfProducts(List<string> listOfProducts)
        {
            Console.WriteLine("Aktualna lista zakupów: ");
            if (listOfProducts.Count > 0)
            {
                foreach (string item in listOfProducts)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Koszyk pusty\n");
            }
        }

        public static void RemoveProductFromList(List<string> listOfProducts)
        {
            Console.WriteLine("Podaj nazwę produktu do usunięcia:");
            string product = Console.ReadLine();

            string? foundElement = null;
            foreach (string item in listOfProducts)
            {
                int result = string.Compare(item, product, true);

                if (result == 0)
                {
                    foundElement = item;
                    break;
                }
            }
            if (foundElement != null)
            {
                listOfProducts.Remove(foundElement);
                Console.WriteLine($"\nProdukt \"{product}\" usunięty z listy zakupów!\n");
                DisplayActualListOfProducts(listOfProducts);
            }
            else
            {
                Console.WriteLine($"Produktu \"{product}\" nie ma na liście!\n");
            }
        }

        public static int ChoiseOperations(List<string> listOfOperations)
        {
            int intNumberOfOperation;

            Console.WriteLine("Wybierz operację:\n");
            foreach (string operation in listOfOperations)
            {
                Console.WriteLine(operation);
            }
            string stringNumberOfOperation = Console.ReadLine();

            if (int.TryParse(stringNumberOfOperation, out intNumberOfOperation)
                            && intNumberOfOperation >= 1
                            && intNumberOfOperation <= listOfOperations.Count)
            {
                Console.WriteLine($"Twój wybór: {intNumberOfOperation}\n");
                return intNumberOfOperation;
            }
            else
            {
                Console.WriteLine("Wprowadzono niepoprawną wartość.\n");
            }
            return intNumberOfOperation;
        }

        public static void PerformOperation(int intNumberOfOperation,
                                            List<string> listOfProducts)
        {
            if (intNumberOfOperation == 1)
            {
                AddProductToList(listOfProducts);
                //DisplayActualListOfProducts(listOfProducts);
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
            //DisplayActualListOfProducts(listOfProducts);
        }


        public static void IterationOfChoiseOfOperation(List<string> listOfProducts)
        {
            List<string> listOfOperations = new List<string>() { "1. Dodaj produkt do listy", "2. Wyświetl listę zakupów",
                                                                "3. Usuń produkt z listy", "4. Zakończ program\n" };
            while (true)
            {
                int intNumberOfOperation = ChoiseOperations(listOfOperations);


                if (intNumberOfOperation >= 1 && intNumberOfOperation <= 3)
                {
                    PerformOperation(intNumberOfOperation, listOfProducts);
                }
                else if (intNumberOfOperation == (listOfOperations.Count))
                { break; }
            }

        }
    }
}