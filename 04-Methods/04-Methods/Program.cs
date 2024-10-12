using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double areaOfCircle = Area(4);
            Console.WriteLine($"Area of circle is: {areaOfCircle}");

            double areaOfRectangular = Area(3, 8);
            Console.WriteLine($"Area of rectangular is: {areaOfRectangular}");

            double areaOfParallelepiped = Area(5, 8, 10);
            Console.WriteLine($"Area of parallelepiped is: {areaOfParallelepiped}");

            double areOfCircleTriangle = Area(4, 6, 7, 5);
            Console.WriteLine($"Area of circle inside triangle is: {areOfCircleTriangle}");

            double calc = Calculation(12, 6, '+');
            Console.WriteLine($"Result of operation is: {calc}");

            double calcPow = CustomPow(4, 3);
            Console.WriteLine($"Result of Pow will be: {calcPow}");

            string finalName = NameChecker("Ruslan", "Bayramov", "Yaqub");
            Console.WriteLine($"The name at the end is: {finalName}");
        }

        static double Area(double radius)
        {
            int pi = 3;
            return radius * radius * pi; // Çevrənin sahəsi
        }

        static double Area(double a, double b)
        {
            return a * b; // Düzbucaqlının sahəsi
        }

        static double Area(double a, double b, double c)
        {
            return 2 * (a * b + a * c + b * c); // paralelpipedin tam səthi
        }

        static double Area(double a, double b, double c, double radius)
        {
            double p = (a + b + c) / 2;

            return p * radius;  //  Üçbucaqlının daxilinə çəkilmiş çevrə
        }

        static double Calculation(double a, double b, char opr)
        {
            double result = -1; // 2 eded ve 1 operator('+','-','*','/')
            if (opr == '+') result = a + b;
            else if (opr == '-') result = a - b;
            else if (opr == '*') result = a * b;
            else if (opr == '/') result = a / b;

            return result;
        }

        static double CustomPow(int num, int pow = 2)
        {
            double multi = 1;
            bool isOdd;

            if (pow == 2)
            {
                return num * num;
            }

            if (pow == 0) multi = 1;
            else if (pow > 0)
            {
                isOdd = pow % 2 == 1; // is pow odd ?
                for (int i = 0; i < pow; i++)
                {
                    if (num >= 0) multi *= num;  // 2^3 // 2^4
                    if (num <= 0 && isOdd) multi *= num; // -2^3
                    else if (num <= 0 && !isOdd) multi *= -num; // -2^4
                }
            }
            else if (pow < 0)
            {
                isOdd = pow % 2 == -1; // is pow odd ?
                for (int i = pow; i < 0; i++)
                {
                    if (num >= 0) multi /= num; // 2^-3 // 2^-4
                    if (num <= 0 && isOdd) multi /= num; // -2^-3 
                    else if (num <= 0 && !isOdd) multi /= -num; // -2^-4
                }
            }

            return multi;
        }

        static string NameChecker(string name)
        {
            string str = "";

            foreach (char s in name)
            {
                str += s;
            }
            return str;
        }

        static string NameChecker(string name, string surname)
        {
            string str = "";

            foreach (char c in surname)
            {
                str += c;
            }
            str += ' '; // adding space between them
            foreach (char s in name)
            {
                str += s;
            }

            return str;
        }

        static string NameChecker(string name, string surname , string fatherName)
        {
            string str = "";

            str = name[0] + "."; // selecting first letter of name and adding . to it (R.)
            foreach (char c in surname)
            {
                str += c;
            }
            str += ' '; // adding space between them
            foreach (char s in fatherName)
            {
                str += s;
            }

            return str;
        }
    }
}
