using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using DLL_Vues.fenetres;

namespace DLL_Vues
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DLL_Persistance.Persistance.InitListes();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void BTN_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BTN_Click(object sender, RoutedEventArgs e)
        {
            if ((Button)sender == BTN_Bureau)
            {
                FEN_Bureau fen = new FEN_Bureau();
                fen.Show();
            }
            else if(sender == BTN_Client)
            {
                FEN_Clients fen = new FEN_Clients();
                fen.Show();
            }
            else if (sender == BTN_Contacter)
            {
                FEN_Contacter fen_ctn = new FEN_Contacter();
                fen_ctn.Show();
            }
            else if (sender == BTN_Contrats)
            {
                FEN_Contrats fen_ctr = new FEN_Contrats();
                fen_ctr.Show();
            }
            else if (sender == BTN_Interlocuteur)
            {
                FEN_Interlocuteurs fen_interloc = new FEN_Interlocuteurs();
                fen_interloc.Show();
            }
            else if (sender == BTN_secteur)
            {
                FEN_Secteurs fen_sctr = new FEN_Secteurs();
                fen_sctr.Show();
            }
            else if(sender == BTN_BlackJack)
            {
                FEN_BlackJack fen_blackJack = new FEN_BlackJack();
                fen_blackJack.Show();
            }
            else if(sender == BTN_Tetris)
            {
                TetrisDotNet.MainWindow win = new TetrisDotNet.MainWindow();
                win.Show();
            }
            else if(sender == BTN_Exercer)
            {
                FEN_Exercer fen_ex = new FEN_Exercer();
                fen_ex.Show();
            }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            LBL_Version.Content = $"Version : {Assembly.GetEntryAssembly().GetName().Version}";
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void BTN_Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            LBL_Time.Content = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
