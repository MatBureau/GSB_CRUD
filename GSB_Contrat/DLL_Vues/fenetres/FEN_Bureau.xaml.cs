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
using DLL_Vues.fenetres.FenetresAjout;

namespace DLL_Vues.fenetres
{
    /// <summary>
    /// Logique d'interaction pour FEN_Bureau.xaml
    /// </summary>
    public partial class FEN_Bureau : Window
    {
        bool gFromAjout = false;
        public FEN_Bureau()
        {
            InitializeComponent();
        }

        public FEN_Bureau(bool FromAjout)
        {
            gFromAjout=FromAjout;
            InitializeComponent();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            DTG_Bureau.ItemsSource = BureauController.GetListBureau();
            if (gFromAjout)
            {
                BTN_Back.IsEnabled = false;
                BTN_SaveSelectedBureau.IsEnabled = true;
                BTN_SaveSelectedBureau.Visibility = Visibility.Visible;
                PathSaveBTN.Visibility = Visibility.Visible;
                DTG_Bureau.Margin = new Thickness(46, 64, 77, 54);
            }
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

        private void BTN_AddBureau_Click(object sender, RoutedEventArgs e)
        {
            FEN_AjoutBureau fen_ajb = new FEN_AjoutBureau();
            fen_ajb.Show();
        }

        private void BTN_Refresh_Click(object sender, RoutedEventArgs e)
        {
            refresh();
        }

        private void BTN_Delete_Click(object sender, RoutedEventArgs e)
        {
            if(DTG_Bureau.SelectedItems.Count != 0)
            {
                List<cls_bureau> burASuppr = new List<cls_bureau>();
                foreach(cls_bureau bureau in DTG_Bureau.SelectedItems)
                {
                    burASuppr.Add(bureau);
                }
                if (MessageBox.Show("Attention voulez-vous supprimer un bureau ? Cela entrainera la perte de ses contrats et des prises de contacts liées", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    BureauController.DeleteBureau(burASuppr);
                    refresh();
                }
            }
        }

        private void refresh()
        {
            DTG_Bureau.ItemsSource = null;
            DTG_Bureau.ItemsSource = BureauController.GetListBureau();
        }

        private void BTN_SaveSelectedBureau_Click(object sender, RoutedEventArgs e)
        {
            if (DTG_Bureau.SelectedItems.Count > 0)
            {
                ContacterController.InitListeBureau();
                ContacterController.ListSelectedBureau.Clear();
                foreach (var data in DTG_Bureau.SelectedItems)
                {
                    ContacterController.ListSelectedBureau.Add(data as cls_bureau);
                }
                this.Close();
            }
        }

        private void BTN_Edit_Click(object sender, RoutedEventArgs e)
        {
            if(DTG_Bureau.SelectedItem != null)
            {
                cls_bureau bureau = (cls_bureau)DTG_Bureau.SelectedItem;
                FEN_AjoutBureau fen_bur = new FEN_AjoutBureau(true,bureau);
                fen_bur.Show();
            }
        }
    }
}
