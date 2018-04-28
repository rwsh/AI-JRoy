using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRoy
{
    class TDERoy : TGraphRoy
    {
        public TDERoy(TGraph Graph) : base(Graph)
        {
        }

        public override double F(TX X)
        {
            TX DX = Diff(X, 1.0 / Info.N);

            double I = 0;

            for (int n = 0; n < Info.N; n++)
            {
                I += Math.Abs(DX[n] + X[n] - 1.0);
            }

            return I;
        }

        public override void Check()
        {
            base.Check();
        }

        public TX Diff(TX X, double h)
        {
            TX DX = new TX();

            DX[0] = X[0] / h;

            for (int n = 1; n < Info.N; n++)
            {
                DX[n] = (X[n] - X[n - 1]) / h;
            }

            return DX;
        }
    }
}
