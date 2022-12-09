using DLL_Controller.Controller;
using DLL_Modele;
using System;
using System.Collections.Concurrent;
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
    /// Logique d'interaction pour FEN_AjoutClient.xaml
    /// </summary>
    public partial class FEN_AjoutClient : Window
    {
        public FEN_AjoutClient()
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
            if (TBX_Adresse.Text != String.Empty && TBX_Adresse.Text != String.Empty && ClientsController.ListSelectedSecteurs.Count >0)
            {
                ConcurrentDictionary<int,List<int>> dic = new ConcurrentDictionary<int,List<int>>();
                List<int> list = new List<int>();
                foreach (cls_secteur code in ClientsController.ListSelectedSecteurs)
                {
                    list.Add(code.CodeSecteur);
                }
                dic.TryAdd(0,list);
                var client = new cls_client(666, TBX_RaisonSociale.Text, TBX_Adresse.Text, dic);
                ClientsController.AddClient(client);
                this.Close();
            }
            else
            {
                LBL_Warning.Visibility = Visibility.Visible;
            }
        }
    }
}
