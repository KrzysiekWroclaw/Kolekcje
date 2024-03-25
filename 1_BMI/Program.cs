using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Net.Http;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.Design;

namespace _1_BMI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Program wyliczający BMI dla osób w wieku od 19 lat.");

            Console.WriteLine("Podaj imię:");
            string? name = Console.ReadLine();

            Console.WriteLine("Podaj wiek [liczba całkowita >= 19]:");
            int intAge;
            while (true)
            {
                string stringAge = Console.ReadLine();
                if (!int.TryParse(stringAge, out intAge) || intAge < 19)
                {
                    Console.WriteLine("Podano niewłaściwe dane. Podaj wiek [liczba całkowita >= 19]:");
                }
                else { break; }
            }

            Console.WriteLine("Podaj wagę w [g]:");
            double doubleWeight;
            while (true)
            {
                string stringWeight = Console.ReadLine();
                if (!double.TryParse(stringWeight, out doubleWeight))
                {
                    Console.WriteLine("Podano niewłaściwe dane. Podaj wagę w [g]:");
                }
                else { break; }
            }



            Console.WriteLine("Podaj wzrost z dokładnością 2 miejsc po przecinku w [m]");
            double doubleHeight;
            while (true)
            {
                string stringHeight = Console.ReadLine();
                if (!double.TryParse(stringHeight, out doubleHeight))
                {
                    Console.WriteLine("Podano niewłaściwe dane. Podaj wzrost z dokładnością 2 miejsc po przecinku w [m]:");
                }
                else { break; }
            }

            double BMI = (doubleWeight / 1000) / (doubleHeight * doubleHeight);

            bool gender;
            char lastLetterOfName = (name[name.Length - 1]);
            if (lastLetterOfName == 'A' || lastLetterOfName == 'a')
            {
                gender = true;
            }
            else { gender = false; }

            WeightCalculator weightCalculator = new WeightCalculator();
            bool isNormalWeight = weightCalculator.IsNormalWeight(intAge, BMI);


            while (true)
            {
                try
                {
                    Console.WriteLine("Wpisz ścieżkę pliku do zapisu danych: ");
                    string path = Console.ReadLine();
                    using StreamWriter sw = new StreamWriter(path);
                    sw.WriteLine("Imię: {0}", name);
                    string genderText = (gender) ? ("K") : ("M");
                    sw.WriteLine("Płeć: {0}", genderText);
                    sw.WriteLine("Wiek: {0}", intAge);
                    sw.WriteLine("Waga [kg]: {0}", doubleWeight / 1000);
                    sw.WriteLine("Wzrost [cm]: {0}", doubleHeight * 100);
                    sw.WriteLine("BMI: {0}", Math.Round(BMI, 4));
                    string isNormalWeightText = isNormalWeight ? ("TAK") : ("NIE");
                    sw.WriteLine("Pożądana masa ciała: {0}", isNormalWeightText);
                    break;

                }
                catch (System.ArgumentException e)
                {

                }
                catch (IOException e2)
                {
                    Console.WriteLine("Niepoprawna ścieżka pliku.");
                }
            }
        }
    }
}



