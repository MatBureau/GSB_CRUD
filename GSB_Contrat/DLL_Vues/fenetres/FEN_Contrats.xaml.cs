using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DLL_Controller.Controller;
using DLL_DAO;

namespace DLL_Vues.fenetres
{
    /// <summary>
    /// Logique d'interaction pour FEN_Contrats.xaml
    /// </summary>
    public partial class FEN_Contrats : Window
    {
        public FEN_Contrats()
        {
            InitializeComponent();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            DTG_Contrats.ItemsSource = ContractsControlleurs.GetListContrats();
        }

        private void BTN_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void BTN_AddContrat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Refresh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
