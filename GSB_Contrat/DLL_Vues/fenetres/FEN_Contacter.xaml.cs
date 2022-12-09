using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using DLL_Vues.fenetres.FenetresAjout;

namespace DLL_Vues.fenetres
{
    /// <summary>
    /// Logique d'interaction pour FEN_Contacter.xaml
    /// </summary>
    public partial class FEN_Contacter : Window
    {
        bool gFromAjout = false;
        public FEN_Contacter()
        {
            InitializeComponent();
        }

        public FEN_Contacter(bool FromAjout)
        {
            gFromAjout=FromAjout;
        }

        private async void Window_ContentRendered(object sender, EventArgs e)
        {
            DTG_Contacter.ItemsSource = ContacterController.GetListContacter();   
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

        private void BTN_AddContacter_Click(object sender, RoutedEventArgs e)
        {
            FEN_AjoutContacter fen_add = new FEN_AjoutContacter();
            fen_add.Show();
        }

        private async void BTN_Refresh_Click(object sender, RoutedEventArgs e)
        {
            refresh();
        }

        private void BTN_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DTG_Contacter.SelectedItems.Count != 0)
            {
                List<cls_contacter> ContASuppr = new List<cls_contacter>();
                foreach (cls_contacter cont  in DTG_Contacter.SelectedItems)
                {
                    ContASuppr.Add(cont);
                }
                if (MessageBox.Show("Attention voulez-vous supprimer une prise contact ? Cela entrainera la perte des données liées", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    ContacterController.DeleteContacter(ContASuppr);
                    refresh();
                }
            }
        }

        public void refresh()
        {
            DTG_Contacter.ItemsSource = null;
            DTG_Contacter.ItemsSource = ContacterController.GetListContacter();
        }
    }
}
