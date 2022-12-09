using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DLL_Controller.Controller;
using DLL_Modele;

namespace DLL_Vues.fenetres
{
    /// <summary>
    /// Logique d'interaction pour FEN_Secteurs.xaml
    /// </summary>
    public partial class FEN_Secteurs : Window
    {
        bool gFromSecteur = false;
        public FEN_Secteurs()
        {
            InitializeComponent();
        }

        public FEN_Secteurs(bool fromSecteur)
        {
            gFromSecteur=fromSecteur;
            InitializeComponent();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            DTG_Secteurs.ItemsSource = SecteursController.GetListSecteurs();
            if (gFromSecteur)
            {
                BTN_Back.IsEnabled = false;
                BTN_SaveSelectedSecteurs.IsEnabled = true;
                BTN_SaveSelectedSecteurs.Visibility = Visibility.Visible;
                PathSaveBTN.Visibility = Visibility.Visible;
                DTG_Secteurs.Margin = new Thickness(46, 64, 77, 54);
                //...
            }
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

        private void BTN_SaveSelectedSecteurs_Click(object sender, RoutedEventArgs e)
        {
            if (DTG_Secteurs.SelectedItems.Count > 0)
            {
                ClientsController.InitListe();
                ClientsController.ListSelectedSecteurs.Clear();
                foreach (var data in DTG_Secteurs.SelectedItems)
                {
                    ClientsController.ListSelectedSecteurs.Add(data as cls_secteur);
                }
                this.Close();
            }
        }

        private void BTN_AddSecteur_Click(object sender, RoutedEventArgs e)
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
