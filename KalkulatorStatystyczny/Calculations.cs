using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalkulatorStatystyczny
{
    public class Calculations
    {
        public static void Average(double[] items)
        {
            double average, sum = 0;
            for (int i = 0; i < items.Length; i++)
            {
                sum = sum + items[i];
            }
            average = sum / items.Length;
            Console.WriteLine($"Średnia arytmetyczna wynosi: = {average}");            
        }

        public static void ItemMax(double[] items)
        {
            double itemMax = items[0];
            for (int i = 0; i < items.Length - 1; i++)
            {
                if (items[i] < items[i + 1])
                {
                    itemMax = items[i + 1];
                }
            }
            Console.WriteLine($"Największa wprowadzona liczba to: {itemMax}");
        }

        public static void ItemMin(double[] items)
        {
            double itemMin = items[0];
            for (int i = 0; i < items.Length - 1; i++)
            {
                if (items[i] > items[i + 1])
                {
                    itemMin = items[i + 1];
                }
            }
            Console.WriteLine($"Najmniejsza wprowadzona liczba to: {itemMin}");
        }

        public static void SumOfItems(double[] items)
        {
            double sumOfItems = 0;
            for (int i = 0; i < items.Length; i++)
            {
                sumOfItems = sumOfItems + items[i];
            }
            Console.WriteLine($"Suma liczb wynosi: {sumOfItems}");
        }        
    }
}