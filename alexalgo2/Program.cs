using System;

namespace Algo2
{
    class Program
    {
        static void Main()
        {
            Method(0, 1);


            Console.ReadLine();
        }

        static void Method(double x, double y)
        {
            double yk = 0, xk = 0, max = 0, k = 1;

            WriteHeader();

            do
            {
                yk = y;
                xk = x;
                x = 1.5 - Math.Cos(y);
                y = (1 + Math.Sin(x - 0.5)) / 2;


                if (Math.Abs(xk - x) > Math.Abs(yk - y))
                {
                    max = Math.Abs(xk - x);
                }
                else
                {
                    max = Math.Abs(yk - y);
                }

                Console.WriteLine("  {0,-7}{1,-14:G8}{2,-14:G8}{3,-14:G8}{4,-14:G8}{5,-14:G5}",
                                 k, xk, x, yk, y, max);

                k++;
            } while (Math.Abs(max) > 0.0001);

            Console.WriteLine("Підставляємо знайдені корені у початкові рівняння:");

            Console.WriteLine("2y - sin(x - 0.5) - 1 = " + F1(x, y));
            Console.WriteLine("cos(y) + x - 1.5 = " + F2(x, y));

        }

        static double F1(double x, double y)
        {
            return 2 * y - Math.Sin(x - 0.5) - 1;
        }

        static double F2(double x, double y)
        {
            return Math.Cos(y) + x - 1.5;
        }

        static void WriteHeader()
        {
            Console.WriteLine("  {0,-7}{1,-14}{2,-14}{3,-14}{4,-14}{5,-14}",
                                 "k", "xk", "x", "yk", "y", "max|xk - x|");
        }
    }
}