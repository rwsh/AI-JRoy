using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JRoy
{
    class TNonlocalRoy : TRoy
    {
        public double h;

        public TNonlocalRoy() : base()
        {
            h = 2.0 / Info.N;
        }

        public void Print(string Name)
        {
            StreamWriter f = new StreamWriter(Name);

            for (int n = 0; n < Info.N; n++)
            {
                f.WriteLine(Agents[0].X[n].ToString());
            }

            f.Close();
        }

        public override double F(TX X)
        {
            int N = Info.N;

            TX D2X = new TX();

            D2X[0] = (1.0 / (h * h)) * (X[2] - 2 * X[1] + X[0]);

            for (int n = 1; n < N - 1; n++)
            {
                D2X[n] = (1.0 / (h * h)) * (X[n - 1] - 2 * X[n] + X[n + 1]);
            }

            D2X[N - 1] = (1.0 / (h * h)) * (X[N - 1] - 2 * X[N - 2] + X[N - 3]);

            double Res = 0;

            for (int n = 0; n < N; n++)
            {
                Res += Math.Abs(D2X[n] - 1.0);
            }

            Res += Math.Abs(X[0] - X[N / 2]);

            return Res;
        }
    }
}
