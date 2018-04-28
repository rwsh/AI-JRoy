using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JRoy
{
    class TIJRoy : TGraphRoy
    {
        public TIJRoy(TGraph Graph) : base(Graph)
        {

        }

        public override void Check()
        {
            base.Check();
        }

        public void Print(string Name)
        {
            StreamWriter f = new StreamWriter(Name);

            double dt = 0.1;

            double t = 0;

            while (t < Info.N)
            {
                double r = I(t, G);

                f.WriteLine(r);

                t += dt;
            }


            f.Close();
        }

        public override double F(TX X)
        {
            double res = 0;

            double dt = 0.1;

            double t = 0;

            double Js = 10;

            while (t < Info.N)
            {
                double r = I(t, X);

                res += Calc.S2(r - Js) * dt;

                t += dt;
            }

            return Math.Sqrt(res); // + 0.01 * Omega(X);
        }

        double Omega(TX X)
        {
            double res = 0;

            for (int k = 0; k < Info.N; k++)
            {
                res = Calc.S2(X[k]);
            }

            return res;
        }

        public double I(double t, TX X)
        {
            double res = 0;

            for (int k = 0; k < Info.N; k++)
            {
                res += K(t - k) * X[k];
            }

            return res;
        }

        double K(double t)
        {
            if (t <= 0)
            {
                return 0;
            }

            return t / (1 + t * t);
        }
    }
}
