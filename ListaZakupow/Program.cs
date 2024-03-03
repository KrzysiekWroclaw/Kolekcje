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
            Console.WriteLine("Program \"Lista zakupów\".");

            List<string> listOfProducts = new List<string>();

            ShoppingListManager.IterationOfChoiseOfOperation(listOfProducts);
        }
    }
}   