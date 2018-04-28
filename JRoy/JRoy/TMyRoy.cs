using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRoy
{
    class TMyRoy : TGraphRoy
    {
        public TMyRoy(TGraph Graph) : base(Graph)
        {
            Info.N = 2;
        }

        public override double F(TX X)
        {
//            return 20 + Calc.S2(X[0]) - 10 * Math.Cos(2 * Math.PI * X[0]) +
//                Calc.S2(X[1]) - 10 * Math.Cos(2 * Math.PI * X[1]) + Calc.S2(X[0] - 1);

            return Calc.S2(1 - X[0]) + 100 * Calc.S2(X[1] - Calc.S2(X[0]));
        }

        public override void Check()
        {
            base.Check();

            Graph.Draw(this);

            //Console.WriteLine("{0}\t{1}\t{2}", J, G[0], G[1]);

            //System.Threading.Thread.Sleep(10);
        }
    }
}
