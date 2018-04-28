using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.IO;

namespace JRoy
{
    abstract class TRoy
    {
        public TAgent[] Agents;

        public TX G;

        public double J;

        public TRoy()
        {
            Agents = new TAgent[Info.M];
            
            for (int m = 0; m < Info.M; m++)
            {
                Agents[m] = new TAgent(this);
            }

            Calc();
        }

        void Calc()
        {
            G = new TX(Agents[0].P);
            J = F(G);

            for (int m = 1; m < Info.M; m++)
            {
                double j = F(Agents[m].P);

                if (j < J)
                {
                    G = new TX(Agents[m].P);
                    J = j;
                }
            }

        }

        abstract public double F(TX X);

        virtual public void Check()
        {

        }

        public void Run()
        {
            for (int m = 0; m < Info.M; m++)
            {
                Agents[m].Move(G);
            }

            Calc();

            Check();
        }
    }

    class TX
    {
        public int N;
        double[] A;

        public TX(TX X = null)
        {
            N = Info.N;

            A = new double[N];

            if (X == null)
            {
                for (int n = 0; n < N; n++)
                {
                    this[n] = Calc.U(Info.A, Info.B);
                }
            }
            else
            {
                for (int n = 0; n < N; n++)
                {
                    this[n] = X[n];
                }
            }
        }

        public double this[int Ind]
        {
            get
            {
                return A[Ind];
            }

            set
            {
                A[Ind] = value;
            }
        }

        public void Print(string Name)
        {
            StreamWriter f = new StreamWriter(Name);

            for (int n = 0; n < Info.N; n++)
            {
                f.WriteLine(this[n]);
            }

            f.Close();
        }
    }

    class TAgent
    {
        TRoy Roy;

        public TX X;

        public TX V;

        public TX P;

        public double J;

        public TAgent(TRoy Roy)
        {
            this.Roy = Roy;

            X = new TX();
            P = new TX(X);
            J = Roy.F(P);

            V = new TX();

            for (int n = 0; n < Info.N; n++)
            {
                V[n] = Calc.U(-(Info.B - Info.A), Info.B - Info.A);
            }
        }

        public void Move(TX G)
        {
            for (int n = 0; n < Info.N; n++)
            {
                V[n] = Info.alpha * V[n] + Info.beta * (P[n] - X[n]) * Calc.U(0, 1) +
                    Info.gamma * (G[n] - X[n]) * Calc.U(0, 1);

                X[n] = X[n] + V[n];

                //if (X[n] < 0)
                //{
                //    X[n] = 0;
                //}
            }

            double j = Roy.F(X);

            if (j < J)
            {
                P = new TX(X);
                J = j;
            }
        }
    }

}
