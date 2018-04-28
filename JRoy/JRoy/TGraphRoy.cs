using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRoy
{
    abstract class TGraphRoy : TRoy
    {
        public TGraph Graph;

        public TGraphRoy(TGraph Graph) : base()
        {
            this.Graph = Graph;
        }

        public override void Check()
        {
            base.Check();

            Graph.Draw(this);

            Console.WriteLine("{0}", J);

            //System.Threading.Thread.Sleep(10);
        }
    }
}
