using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg4
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 0;
            double[] x = new double[10] { -0.11, 0.11, 0.24, 0.36, 0.56, 0.66, 0.89, 1.1, 1.39, 1.6 };
            double[] y = new double[10] { 0.7764, 1.2382, 1.5394, 1.8374, 2.4101, 2.6780, 3.4356, 4.2396, 5.5884, 6.7991 };

            double lagr = 0, form;
            double x0 = x[0], x1 = x[1], x2 = x[2], x3 = x[3], y0 = y[0], y1 = y[1], y2 = y[2], y3 = y[3];
            double temp = 0, t = double.MaxValue;

            int k1 = 0, k2 = 3;
            for (double i = 0; i <= 1.5; i = i + 0.01)
            {


                for (int j = 0; j < x.Length; j++)
                {
                    double a = Math.Abs(x[j] - i);

                    if (a < t)
                    {
                        temp = x[j];
                        t = a;
                    }
                }
                lagr = Pol(i, x0, x1, x2, x3, y0, y1, y2, y3);
                k++;
                Console.ReadKey();
            }


             for (double i = 0; i <= 1.5; i = i + 0.01)
             {

                 form = Form(x, y,i);
                 lagr = Pol(x, y, i,0,3);

                 p1 = FormD1(x, y, i);
                 pd1 = D1(x, y, i);

                 p2 = FormD2(x, y, i);

                 Console.WriteLine($"k={k,-7} i={i,-10} || form={form,-20} lagr={lagr,-20} || Произв1={p1,-20} Числ.Диф.1={pd1,-20} || Произв2={p2,-20} Числ.Диф.2=");
                 k++;
             }
            k = 0;



        }

        public static double Form(double[] x, double[] y, double i)
        {
            return Math.Pow(3, i) + Math.Sin(i);
        }

        public static double GeneralPol(double[] x, double[] y, double i, int k1, int k2)
        {
            double lagr = 0; int j1 = k1, j2 = k2;
            for (k1 = 0; k1 < k2; k1++)
            {
                double basicsPol = 1;
                for (j1 = 0; j1 < j2; j1++)
                {
                    if (j1 != k1)
                    {
                        basicsPol *= (i - x[j1]) / (x[k1] - x[j1]);
                    }

                }
                lagr += basicsPol * y[k1];

            }
            return lagr;
        }

        public static double Pol(double x, double x1, double x2, double x3, double x4, double y1, double y2, double y3, double y4)
        {
            return y1 * ((x - x2) * (x - x3) * (x - x4)) / ((x1 - x2) * (x1 - x3) * (x1 - x4)) +
                   y2 * ((x - x1) * (x - x3) * (x - x4)) / ((x2 - x1) * (x2 - x3) * (x2 - x4)) +
                   y3 * ((x - x1) * (x - x2) * (x - x4)) / ((x3 - x1) * (x3 - x2) * (x3 - x4)) +
                   y4 * ((x - x1) * (x - x2) * (x - x3)) / ((x4 - x1) * (x4 - x2) * (x4 - x3));
        }



        public static double FormD1(double[] x, double[] y, double i)
        {

            return Math.Pow(3, i) * Math.Log(3) + Math.Cos(i);
        }

        public static double FormD2(double[] x, double[] y, double i)
        {

            return Math.Pow(3, i) * Math.Log(3) * Math.Log(3) - Math.Sin(i);
        }


        public static double D1(double[] x, double[] y, double i)
        {
            return (GeneralPol(x, y, i + 0.01, 1, 4) - GeneralPol(x, y, i - 0.01, 1, 4)) / (2 * i);
        }
       

    }
   
}


//lagr = y[0]*(i-x[1])*(i-x[2])*(i-x[3])/((x[0]-x[1])*(x[0]-x[2])*(x[0]-x[3])) + y[1] * (i - x[0]) * (i - x[2]) * (i - x[3]) / ((x[1] - x[0]) * (x[1] - x[2]) * (x[1] - x[3])) + y[2] * (i - x[0]) * (i - x[1]) * (i - x[3]) / ((x[2] - x[0]) * (x[2] - x[1]) * (x[2] - x[3])) + y[3] * (i - x[0]) * (i - x[1]) * (i - x[2]) / ((x[3] - x[0]) * (x[3] - x[1]) * (x[3] - x[2]));