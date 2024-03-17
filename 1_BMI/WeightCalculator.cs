using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_BMI
{
    public class WeightCalculator //w osobnym pliku - zrobione
    {

        private bool CheckBMI(double minBMI, double maxBMI, double BMI)
        {

            if (BMI >= minBMI && BMI <= maxBMI)
            {
                return true;
            }
            else { return false; }
        }


        public bool IsNormalWeight(int age, double BMI)
        {
            int liczba = 0;
            switch (liczba)
            {
                case 1 when (age >= 19 && age <= 24):
                    return CheckBMI(19, 24, BMI);
                    break;
                case 2 when (age <= 34 && BMI >= 20 && BMI <= 25):
                    return CheckBMI(20, 25, BMI);
                    break;
                case 3 when (age <= 44 && BMI >= 21 && BMI <= 26):
                        return CheckBMI(21, 26, BMI);
                    break;
                case 4 when (age <= 54 && BMI >= 22 && BMI <= 27):
                    return CheckBMI(22, 27, BMI);
                    break;
                case 5 when (age <= 64 && BMI >= 23 && BMI <= 28):
                    return CheckBMI(23, 28, BMI);
                    break;
                case 6 when (age > 64 && BMI >= 24 && BMI <= 29):
                    return CheckBMI(24, 29, BMI);
                    break;

                default:
                    return false;
                    Console.WriteLine("niewłaściwy wiek");
                    break;
            }
        }
    }
}
