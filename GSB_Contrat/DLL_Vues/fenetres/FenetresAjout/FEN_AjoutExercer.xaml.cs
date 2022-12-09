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

namespace DLL_Vues.fenetres.FenetresAjout
{
    /// <summary>
    /// Logique d'interaction pour FEN_AjoutExercer.xaml
    /// </summary>
    public partial class FEN_AjoutExercer : Window
    {
        public FEN_AjoutExercer()
        {
            InitializeComponent();
        }

        private void BTN_ChoseSecteur_Click(object sender, RoutedEventArgs e)
        {
            FEN_Secteurs fen_sec = new FEN_Secteurs(true);
            fen_sec.Show();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void BTN_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BTN_Save_Click(object sender, RoutedEventArgs e)
        {
            if (TBX_Bureau.Text != String.Empty && TBX_Interlocteur.Text != null && ContacterController.ListSelectedBureau.Count > 0 && ContacterController.ListSelectedInterlocuteur.Count > 0)
            {
                //var contacter = new cls_contacter(ContacterController.ListSelectedBureau[0].CodeBureau, ContacterController.ListSelectedInterlocuteur[0].CodeInterlocuteur);
                //ContacterController.AddContacter(contacter);
                //this.Close();
            }
            else
            {
                LBL_Warning.Visibility = Visibility.Visible;
            }
        }



        private void BTN_ChoseBureau_Click(object sender, RoutedEventArgs e)
        {
            FEN_Bureau bur = new FEN_Bureau(true);
            bur.Show();
        }

        private void BTN_ChoseInterlocuteur_Click(object sender, RoutedEventArgs e)
        {
            FEN_Interlocuteurs inter = new FEN_Interlocuteurs(true);
            inter.Show();
        }
    }
}
