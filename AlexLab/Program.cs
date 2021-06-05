using System;

namespace Algo1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("\n Метод бисекции");
            B(1, 2.5);
            B(4, 5.5);
            B(7.4, 8.4);

            Console.WriteLine("\n \n Метод Ньютона");
            N(1, 2.5);
            N(4, 5.5);
            N(7.4, 8.4);

            Console.ReadLine();
        }

        static void B(double a, double b)
        {
            int k = 0;
            double x = 0;
            double ans = 0;
            double val = 0;

            Console.WriteLine($"Нахождение корней на отрезке от {a} до {b}");
            WriteHeaderB();

            do
            {
                k++;
                x = (a + b) / 2;


                if (F(x) == 0)
                {
                    ans = x;
                    val = F(x);
                    Console.WriteLine("  {0,-7}{1,-14}{2,-14}{3,-14}{4,-14}{5,-14}{6,-14}",
                                 k, a, b, x, Math.Abs(b - a), val, Math.Log10(Math.Abs(b - a)));
                    break;
                }
                else if (F(a) * F(x) < 0)
                {
                    val = F(x);
                    Console.WriteLine("  {0,-7}{1,-14:G6}{2,-14:G6}{3,-14:G6}{4,-14:G6}{5,-14:G6}{6,-14:G6}",
                             k, a, b, x, Math.Abs(b - a), val, Math.Log10(Math.Abs(b - a)));
                    b = x;
                }
                else
                {
                    val = F(x);
                    Console.WriteLine("  {0,-7}{1,-14:G6}{2,-14:G6}{3,-14:G6}{4,-14:G6}{5,-14:G6}{6,-14:G6}",
                             k, a, b, x, Math.Abs(b - a), val, Math.Log10(Math.Abs(b - a)));
                    a = x;
                }

                ans = x;


            } while ((Math.Abs(F(x)) > 0.0001) || Math.Abs(a - b) > 0.0001);


            Console.WriteLine("{0, 0:G6}— корень уравнения", ans);
            double p = (b - a) / Math.Pow(2, k);
            Console.WriteLine("{0, 0:G6} - погрешность", p);

        }

        static void WriteHeaderB()
        {
            Console.WriteLine("  {0,-7:G6}{1,-14:G6}{2,-14:G6}{3,-14:G6}{4,-14:G6}{5,-14:G6}{6,-14:G6}",
                                 "k", "a", "b", "x", "|b-a|", "f(х)", "lg(|b - a|)");
        }

        static void WriteHeaderN()
        {
            Console.WriteLine("  {0,-7:G6}{1,-14:G6}{2,-14:G6}{3,-14:G6}{4,-14:G6}",
                                 "k", "x", "|xk -x(k-1)|", "f(х) – приближ.", "lg(|x1 - x0|)");
        }

        static double F(double x) //Значение функции
        {
            return Math.Tan(2 + (Math.Pow(x, 2)) / (1 + x));
        }

        static double F_P1(double x) //Первая производная
        {
            return (x * (2 + x) / Math.Pow(Math.Cos(2 + Math.Pow(x, 2) / (1 + x)), 2)) / Math.Pow(1 + x, 2);
        }

        static double F_P2(double x) //Вторая производная
        {
            return ((2 + x) / (Math.Pow(Math.Cos(2 + Math.Pow(x, 2) / (1 + x)), 2)) / Math.Pow(1 + x, 2) - 2 * x * (2 + x) / (Math.Pow(Math.Cos(2 + Math.Pow(x, 2)) / (1 + x), 2)) / Math.Pow(1 + x, 3) + x / Math.Pow(Math.Cos(2 + Math.Pow(x, 2) / (1 + x)), 2)) / Math.Pow(1 + x, 2) + 1 / Math.Pow(1 + x, 2) * 2 * x * 2 * x / (1 + x) - Math.Pow(x, 2) / Math.Pow(1 + x, 2) * (2 + x) * Math.Tan(2 + Math.Pow(x, 2) / (1 + x)) / Math.Pow(Math.Cos(2 + Math.Pow(x, 2) / (1 + x)), 2);
        }

        static void N(double a, double b)
        {
            int k = 0;
            double x = 0;
            double xnew = 0;

            Console.WriteLine($"Нахождение корней на отрезке от {a} до {b}");
            WriteHeaderN();




            do
            {
                k++;

                if (k == 1)
                {
                    if (F(a) * F_P2(a) > 0)
                        x = a;
                    else
                        x = b;
                }
                else
                    x = xnew;

                xnew = x - (F(x) / F_P1(x));
                double L = Math.Log(Math.Abs(xnew - x), 10);

                if (F(xnew) == 0)
                {
                    Console.WriteLine("  {0,-7:G6}{1,-14:G6}{2,-14:G6}{3,-14:G6}{4,-14:G6} ",
                                 k, xnew, Math.Abs(xnew - x), F(xnew), L);
                    Console.WriteLine(xnew + " — корень");
                    break;
                }

                Console.WriteLine("  {0,-7:G6}{1,-14:G6}{2,-14:G6}{3,-14:G6}{4,-14:G6}",
                                 k, xnew, Math.Abs(xnew - x), F(xnew), L);
                Console.WriteLine();

            } while (Math.Abs(xnew - x) >= 0.0001);


            Console.WriteLine("{0, 0:G6}— корень уравнения", xnew);
            double p = F(x) / Math.Abs(F_P1(x));
            Console.WriteLine("{0, 0:G6} - погрешность", p);

        }
    }
}

