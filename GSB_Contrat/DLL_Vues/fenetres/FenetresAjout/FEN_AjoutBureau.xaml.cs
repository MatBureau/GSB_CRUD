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
using DLL_Controller.Controller;
using DLL_Modele;

namespace DLL_Vues.fenetres.FenetresAjout
{
    /// <summary>
    /// Logique d'interaction pour FEN_AjoutBureau.xaml
    /// </summary>
    public partial class FEN_AjoutBureau : Window
    {
        bool gEdit = false;
        cls_bureau gBureauEdit;
        public FEN_AjoutBureau()
        {
            InitializeComponent();
        }

        public FEN_AjoutBureau(bool Edit,cls_bureau bureauEdit)
        {
            InitializeComponent();
            gEdit = Edit;
            gBureauEdit = bureauEdit;
        }


        private void Window_ContentRendered(object sender, EventArgs e)
        {
            if (gEdit)
            {
                TBX_Pays.Text = gBureauEdit.Pays;
                TBX_Ville.Text = gBureauEdit.VilleBureau;
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

        private void BTN_Save_Click(object sender, RoutedEventArgs e)
        {
            if (gEdit)
            {
                gBureauEdit.VilleBureau = TBX_Ville.Text;
                gBureauEdit.Pays = TBX_Pays.Text;
                BureauController.UpdateBureau(gBureauEdit);
            }
            else
            {
                if (TBX_Pays.Text != String.Empty && TBX_Ville.Text != String.Empty)
                {
                    cls_bureau bureau = new cls_bureau(666, TBX_Ville.Text, TBX_Pays.Text);
                    BureauController.AddBureau(bureau);
                    
                }
                else
                {
                    LBL_Warning.Visibility = Visibility.Visible;
                }
            }
            this.Close();
        }
    }
}
