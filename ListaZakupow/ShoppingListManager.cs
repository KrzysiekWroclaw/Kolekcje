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
            Console.WriteLine("Podaj nazwę produktu do dodania:");
            string product = Console.ReadLine();
            listOfProducts.Add(product);
            Console.WriteLine($"\nProdukt \"{product}\" dodany do listy zakupów!\n");
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


            try //usunąć is dać pętlę
            {
                int indexOflistOfProducts = 0; //tą zmienną usunąć
                string itemOflistOfProducts = listOfProducts[indexOflistOfProducts]; //usunąć
                char firstLetterItemOflistOfProducts = itemOflistOfProducts[0];
                int i = 0;


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
                }

                //if (listOfProducts.Contains(product))
                //{
                //    listOfProducts.Remove(product);
                //    Console.WriteLine($"\nProdukt \"{product}\" usunięty z listy zakupów!\n");
                //}
                //else
                //{
                //    Console.WriteLine($"Artykułu \"{product}\" nie ma na liście!\n");
                //}
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Koszyk pusty. Brak produktów do usunięcia.\n");
            } //string Compare - wykorzystać tą funkcję

            //else
            //{
            //    for (int j = 0; j < listOfProducts.Count; j++)
            //    {
            //        for (i = 0; i < itemOflistOfProducts.Length; i++)
            //        {
            //            if (char.ToUpper(itemOflistOfProducts[i]) == product[i] || char.ToUpper(product[i]) == itemOflistOfProducts[i] || itemOflistOfProducts[i] == product[i])
            //            {
            //                itemOflistOfProducts = listOfProducts[i];
            //            }
            //            if (i + 1 == itemOflistOfProducts.Length)
            //            {
            //                listOfProducts.Remove(listOfProducts[0]);
            //                Console.WriteLine($"\nProdukt \"{product}\" usunięty z listy zakupów!\n");
            //            }
            //            else
            //            {
            //                Console.WriteLine($" 1 Artykułu \"{product}\" nie ma na liście!\n");
            //            }
            //        }
            //    }
            //}               
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

        public static void PerformOperation(List<string> listOfOperations, //usunąć listofoperation
            int intNumberOfOperation,
            List<string> listOfProducts)
        {
            bool cont = true;
            while (cont)
            {
                if (intNumberOfOperation == 1)
                {
                    ShoppingListManager.AddProductToList(listOfProducts);
                    ShoppingListManager.DisplayActualListOfProducts(listOfProducts);
                    break;
                }
                else if (intNumberOfOperation == 2)
                {
                    ShoppingListManager.DisplayActualListOfProducts(listOfProducts);
                    break;
                }
                else if (intNumberOfOperation == 3)
                {
                    ShoppingListManager.RemoveProductFromList(listOfProducts);
                    ShoppingListManager.DisplayActualListOfProducts(listOfProducts);
                    break;
                }
                else if (intNumberOfOperation == 4)
                {
                    break;
                }
            }
        }

        public static void IterationOfChoiseOfOperation(List<string> listOfOperations, List<string> listOfProducts)
        {
            while (true)
            {
                int intNumberOfOperation = ChoiseOperations(listOfOperations);
                if (intNumberOfOperation >= 1 && intNumberOfOperation <= 3)
                {
                    PerformOperation(listOfOperations, intNumberOfOperation, listOfProducts);
                }
                else if (intNumberOfOperation == 4)
                { break; }
            }
        }
    }
}