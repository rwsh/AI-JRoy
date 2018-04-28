using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace JRoy
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Info.Init();

            //TNonlocalRoy R = new TNonlocalRoy();

            //for (int l = 0; l < Info.L; l++)
            //{
            //    R.Run();
            //}

            //R.G.Print("n.txt");

            //Close();


            TGraph Graph = new TGraph(g);

//            Roy = new TIJRoy(Graph);
            Roy = new TMyRoy(Graph);

            TX X0 = new TX();
            X0[0] = 1;
            X0[1] = 1;
           
            Graph.SetU(X0);

            Timer = new DispatcherTimer();
            Timer.Tick += new EventHandler(onTick);
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 10);

            Timer.Start();

            //Close();


        }

//        TIJRoy Roy;
        TMyRoy Roy;

        DispatcherTimer Timer;

        int Counter = 0;

        void onTick(object sender, EventArgs e)
        {
            Counter++;

            if (Counter > Info.L)
            {
                Timer.Stop();

                Roy.G.Print("a.txt");

                //Roy.Print("b.txt");
            }

            Roy.Run();

        }


    }
}
