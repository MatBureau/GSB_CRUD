using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DLL_Vues.fenetres
{
    /// <summary>
    /// Logique d'interaction pour FEN_BlackJack.xaml
    /// </summary>
    public partial class FEN_BlackJack : Window
    {
        public static Dictionary<int, string> gDeckCarr = new Dictionary<int, string>() { { 1, "As" },{ 2, "2" }, { 3, "3" }, { 4, "4" }, { 5, "5" }, { 6, "6" }, { 7, "7" }, { 8, "8" }, { 9, "9" }, { 10, "10" }, { 11, "Valet" }, { 12, "Dame" }, { 13, "Roi" }};
        public static Dictionary<int, string> gDeckCoeur = new Dictionary<int, string>() { { 1, "As" }, { 2, "2" }, { 3, "3" }, { 4, "4" }, { 5, "5" }, { 6, "6" }, { 7, "7" }, { 8, "8" }, { 9, "9" }, { 10, "10" }, { 11, "Valet" }, { 12, "Dame" }, { 13, "Roi" } };
        public static Dictionary<int, string> gDeckTrefle = new Dictionary<int, string>() { { 1, "As" }, { 2, "2" }, { 3, "3" }, { 4, "4" }, { 5, "5" }, { 6, "6" }, { 7, "7" }, { 8, "8" }, { 9, "9" }, { 10, "10" }, { 11, "Valet" }, { 12, "Dame" }, { 13, "Roi" } };
        public static Dictionary<int, string> gDeckPique = new Dictionary<int, string>() { { 1, "As" }, { 2, "2" }, { 3, "3" }, { 4, "4" }, { 5, "5" }, { 6, "6" }, { 7, "7" }, { 8, "8" }, { 9, "9" }, { 10, "10" }, { 11, "Valet" }, { 12, "Dame" }, { 13, "Roi" } };

        public FEN_BlackJack()
        {
            InitializeComponent();
            
        }

        private void BTN_Play_Click(object sender, RoutedEventArgs e)
        {
            //BTN_Play.Visibility = Visibility.Hidden;
            if (LBL_Joueur.Content != null && LBL_Joueur.Content != string.Empty && LBL_ScoreCroupier.Content != string.Empty && LBL_ScoreCroupier.Content != null)
            {

                int sommeJoueur = GetScoreCarte();
                LBL_CartesJoueur.Content += sommeJoueur.ToString() + "+";
                LBL_Joueur.Content = sommeJoueur + int.Parse(LBL_Joueur.Content.ToString());
                
                int sommeCroupier = GetScoreCarte();
                LBL_CartesCroupier.Content += sommeCroupier.ToString() + "+";
                LBL_ScoreCroupier.Content = sommeCroupier + int.Parse(LBL_ScoreCroupier.Content.ToString());
            }
            else
            {
                int sommeJoueur = GetScoreCarte();
                sommeJoueur += GetScoreCarte();
                LBL_Joueur.Content = sommeJoueur;
                int sommeCroupier = GetScoreCarte();
                sommeCroupier += GetScoreCarte();
                LBL_ScoreCroupier.Content = sommeCroupier;
            }
        }

        public void Window_ContentRendered(object sender, EventArgs e)
        {
            
        }

        private void BTN_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private int GetScoreCarte()
        {
            string carte = PickRandomCard();
            int valeurcarte = 0;
            switch (carte)
            {
                case "As":
                    //tst_lbl.Content += "+ As ";
                    string content = LBL_Joueur.Content.ToString();
                    if (int.Parse(content)+11>21)
                    {
                        valeurcarte = 1;
                    }
                    else
                    {
                        valeurcarte = 11;
                    }
                    break;
                case "2":
                    valeurcarte = 2;
                    //tst_lbl.Content += "+ 2 ";
                    break;
                case "3":
                    valeurcarte = 3;
                    //.Content += "+ 3 ";
                    break;
                case "4":
                    valeurcarte = 4;
                    //tst_lbl.Content += "+ 4 ";
                    break;
                case "5":
                    valeurcarte = 5;
                    //tst_lbl.Content += "+ 5 ";
                    break;
                case "6":
                    valeurcarte = 6;
                    //tst_lbl.Content += "+ 6 ";
                    break;
                case "7":
                    valeurcarte = 7;
                    //tst_lbl.Content += "+ 7 ";
                    break;
                case "8":
                    valeurcarte = 8;
                    //tst_lbl.Content += "+ 8 ";
                    break;
                case "9":
                    valeurcarte = 9;
                    //tst_lbl.Content += "+ 9 ";
                    break;
                case "10":
                    valeurcarte = 10;
                    //tst_lbl.Content += "+ 10 ";
                    break;
                case "Valet":
                    valeurcarte = 10;
                    //tst_lbl.Content += "+ Valet ";
                    break;
                case "Dame":
                    valeurcarte = 10;
                    //tst_lbl.Content += "+ Dame ";
                    break;
                case "Roi":
                    valeurcarte = 11;
                    //tst_lbl.Content += "+ Roi ";
                    break;
            }
                
            return valeurcarte;
        }

        private string PickRandomCard()
        {
            Dictionary<int, string> deck =  new Dictionary<int, string>();
            Random random = new Random();
            int indexList = random.Next(0,3);
            switch (indexList)
            {
                case 0:
                    deck = gDeckCarr;
                    break;
                case 1:
                    deck = gDeckCoeur;
                    break;
                case 2:
                    deck = gDeckPique;
                    break;
                case 3:
                    deck = gDeckTrefle;
                    break;
            }
            int indexCarte = random.Next(1,13);
            string yeet = deck[indexCarte];
            return yeet;
        }

        private void BTN_As_Click(object sender, RoutedEventArgs e)
        {
            if(sender == BTN_As1)
            {
                string score = LBL_Joueur.Content.ToString();
                int heyho = int.Parse(score) + 1;
                LBL_Joueur.Content = heyho;
                BTN_As1.Visibility = Visibility.Hidden;
                BTN_As11.Visibility = Visibility.Hidden;
            }
            else if(sender == BTN_As11)
            {
                string score = LBL_Joueur.Content.ToString();
                int heyho = int.Parse(score) + 11;
                LBL_Joueur.Content = heyho;
                BTN_As1.Visibility = Visibility.Hidden;
                BTN_As11.Visibility = Visibility.Hidden;
            }
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
