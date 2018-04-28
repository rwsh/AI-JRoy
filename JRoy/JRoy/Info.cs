using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRoy
{
    static class Info
    {
        public static int N = 2; // размерность

        public static int M = 100; // количество частиц

        public static int L = 10000; // количество итераций

        public static double A = -10; // ширина куба

        public static double B = 10; // ширина куба

        public static double alpha = 0.95;

        public static double beta = 0.2;

        public static double gamma = 0.2;

        public static void Init()
        {
            Calc.Init();
        }

    }

    static class Calc
    {
        public static Random rnd;

        public static void Init()
        {
            rnd = new Random();
        }

        public static double S2(double x)
        {
            return x * x;
        }

        public static double U(double a, double b)
        {
            return a + (b - a) * rnd.NextDouble();
        }

    }
}
