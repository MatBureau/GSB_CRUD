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
using System.Windows.Shapes;
using DLL_Controller.Controller;
using DLL_Modele;

namespace DLL_Vues.fenetres
{
    /// <summary>
    /// Logique d'interaction pour FEN_Clients.xaml
    /// </summary>
    public partial class FEN_Clients : Window
    {
        public FEN_Clients()
        {
            InitializeComponent();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            DTG_Clients.ItemsSource = ClientsController.GetListClients();
        }

        private void BTN_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void BTN_AddClient_Click(object sender, RoutedEventArgs e)
        {
            var fen_add = new FenetresAjout.FEN_AjoutClient();
            fen_add.Show();
        }

        private void BTN_Refresh_Click(object sender, RoutedEventArgs e)
        {
            refresh();
        }

        private void BTN_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DTG_Clients.SelectedItems.Count != 0)
            {
                List<cls_client> cltASuppr = new List<cls_client>();
                foreach (cls_client clt in DTG_Clients.SelectedItems)
                {
                    cltASuppr.Add(clt);
                }
                if (MessageBox.Show("Attention voulez-vous supprimer un client ? Cela entrainera la perte de ses 'exercer' et des contrats liés", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    ClientsController.DeleteClient(cltASuppr);
                    refresh();
                }
            }
        }

        private void refresh()
        {
            DTG_Clients.ItemsSource = null;
            DTG_Clients.ItemsSource = ClientsController.GetListClients();
        }
    }
}
