using DLL_Controller.Controller;
using DLL_Modele;
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

namespace DLL_Vues.fenetres
{
    /// <summary>
    /// Logique d'interaction pour FEN_Interlocuteurs.xaml
    /// </summary>
    public partial class FEN_Interlocuteurs : Window
    {
        bool gFromAjout = false;
        public FEN_Interlocuteurs()
        {
            InitializeComponent();
        }

        public FEN_Interlocuteurs(bool FromAjout)
        {
            InitializeComponent();
            gFromAjout = FromAjout;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            DTG_Interloc.ItemsSource = InterlocuteurController.GetListInterlocuteur();
            if (gFromAjout)
            {
                BTN_Back.IsEnabled = false;
                BTN_SaveSelectedInterloc.IsEnabled = true;
                BTN_SaveSelectedInterloc.Visibility = Visibility.Visible;
                PathSaveBTN.Visibility = Visibility.Visible;
                DTG_Interloc.Margin = new Thickness(46, 64, 77, 54);
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

        private void BTN_AddInterloc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Refresh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_SaveSelectedInterloc_Click(object sender, RoutedEventArgs e)
        {
            if (DTG_Interloc.SelectedItems.Count > 0)
            {
                ContacterController.InitListeInterloc();
                ContacterController.ListSelectedInterlocuteur.Clear();
                foreach (var data in DTG_Interloc.SelectedItems)
                {
                    ContacterController.ListSelectedInterlocuteur.Add(data as cls_interlocuteur);
                }
                this.Close();
            }
        }
    }
}
