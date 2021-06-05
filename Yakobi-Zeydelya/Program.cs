using System;

namespace A3Lab
{
    class Program
    {
        static double X1(double x2)
        {
            return (4444.0/655.0 - 3003.0/1310.0 * x2) / 3.3;
        }
        static double X2()
        {
            return (29593.0/3930.0 / 774.0/655.0);
        }
        static double X3(double x2)
        {
            return (28.0/11.0 - 9.0/110.0*x2) /(131.0/110.0);
        }
        static void Main(string[] args)
        {
            int i = 0;
            double x1 = 0, x2 = X2(), x3 = 0;
            double nextx1, nextx3;
            Console.WriteLine("№ \t\t x1 \t\t\tx2 \t\t\tx3 \t\t\tПогрешность");
            do
            {
                i++;
                nextx1 = X1(x2);
                nextx3 = X3(x2);
                Console.WriteLine($"{i}\t \t {x1:f5} \t \t{x2:f5} \t\t{x3:f5} \t\t{Math.Max(Math.Abs(nextx1 - x1), Math.Abs(nextx3 - x3))}");
            } while (Math.Max(Math.Abs(nextx1 - x1), Math.Abs(nextx3 - x3)) >= 0.0001 && i < 100);
            Console.WriteLine("Система решена методом Якоби" + "\n" + "Oтвет:");
            Console.WriteLine($"x1: {x1}");
            Console.WriteLine($"x2: {x2}");
            Console.WriteLine($"x3: {x3}");
            Console.WriteLine($"Вектор невязки по первому уравнению: {4444.0 / 655.0 - 3003.0 / 1310.0 * x2 - 3.3 * x1}");
            Console.WriteLine($"Вектор невязки по второму уравнению: {29593.0 / 3930.0 - 774.0 / 655.0 * x2}");
            Console.WriteLine($"Вектор невязки по третьему уравнению: {28.0 / 11.0 - 9.0 / 110.0 * x2 + 131.0 / 110.0 * x3}");
            Console.ReadKey();
        }
    }
}