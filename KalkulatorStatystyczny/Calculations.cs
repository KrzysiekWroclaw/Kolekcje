using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalkulatorStatystyczny
{
    public class Calculations
    {
        public static double Average(double[] items)
        {
            double average, sum = 0;
            for (int i = 0; i < items.Length; i++)
            {
                sum = sum + items[i];
            }
            return average = sum / items.Length;
        }

        public static double ItemMax(double[] items)
        {
            double itemMax = items[0];
            for (int i = 0; i < items.Length - 1; i++)
            {
                if (itemMax < items[i + 1])
                {
                    itemMax = items[i + 1];
                }
            }
            return itemMax;
        }

        public static double ItemMin(double[] items)
        {
            double itemMin = items[0];
            for (int i = 0; i < items.Length - 1; i++)
            {
                if (itemMin > items[i + 1]) 
                {
                    itemMin = items[i + 1];
                }
            }
            return itemMin;
        }

        public static double SumOfItems(double[] items)
        {
            double sumOfItems = 0;
            for (int i = 0; i < items.Length; i++)
            {
                sumOfItems = sumOfItems + items[i];
            }
            return sumOfItems;
        }        
    }
}