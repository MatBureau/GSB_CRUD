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
    /// Logique d'interaction pour FEN_Exercer.xaml
    /// </summary>
    public partial class FEN_Exercer : Window
    {
        bool gFromAjout = false;
        public FEN_Exercer()
        {
            InitializeComponent();
        }

        public FEN_Exercer(bool FromAjout)
        {
            gFromAjout=FromAjout;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            DTG_Exercer.ItemsSource = ExercerController.GetListeExercer();
            if (gFromAjout)
            {
                BTN_Back.IsEnabled = false;
                PathSaveBTN.Visibility = Visibility.Visible;
                DTG_Exercer.Margin = new Thickness(46, 64, 77, 54);
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
            //FEN_AjoutBureau fen_ajb = new FEN_AjoutBureau();
            //fen_ajb.Show();
        }

        private void BTN_Refresh_Click(object sender, RoutedEventArgs e)
        {
            refresh();
        }

        private void BTN_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DTG_Exercer.SelectedItems.Count != 0)
            {
                List<cls_exercer> exASuppr = new List<cls_exercer>();
                foreach (cls_exercer exer in DTG_Exercer.SelectedItems)
                {
                    exASuppr.Add(exer);
                }
                if (MessageBox.Show("Attention voulez-vous supprimer un 'exercer' ? Cela entrainera la perte des données liées", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    ExercerController.DeleteExercer(exASuppr);
                    refresh();
                }
            }
        }

        private void refresh()
        {
            DTG_Exercer.ItemsSource = null;
            DTG_Exercer.ItemsSource = ExercerController.GetListeExercer();
        }

        private void BTN_SaveSelectedBureau_Click(object sender, RoutedEventArgs e)
        {
            //if (DTG_Exercer.SelectedItems.Count > 0)
            //{
            //    ContacterController.InitListeBureau();
            //    ContacterController.ListSelectedBureau.Clear();
            //    foreach (var data in DTG_Exercer.SelectedItems)
            //    {
            //        ContacterController.ListSelectedBureau.Add(data as cls_bureau);
            //    }
            //    this.Close();
            //}
        }
    }
}
