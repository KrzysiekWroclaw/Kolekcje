using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;



namespace ListaZakupow
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<string> listOfOperations = new List<string>() { "1. Dodaj produkt do listy", "2. Wyświetl listę zakupów", "3. Usuń produkt z listy", "4. Zakończ program\n" };

            Console.WriteLine("Program \"Lista zakupów\".");

            List<string> listOfProducts = new List<string>();

            Calculate.IterationOfChoiseOfOperation(listOfOperations, listOfProducts);

        }
    }
}   