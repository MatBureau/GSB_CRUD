using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Modele
{
    public class cls_contacter : IComparer<cls_contacter>
    {
        private int _CodeBureau;
        private int _CodeInterlocuteur;
        private DateTime _DateContact;
        private string _Commentaire;


        public int Compare(cls_contacter x, cls_contacter y)
        {
            return x.CodeBureau.CompareTo(y.CodeBureau);
        }

        public cls_contacter(int p_CodeBureau,int p_CodeInterlocuteur, DateTime p_DateContact, string p_Commentaire)
        {
            _CodeBureau = p_CodeBureau;
            _CodeInterlocuteur = p_CodeInterlocuteur;
            _DateContact = p_DateContact;
            _Commentaire = p_Commentaire;
        }

        public int CodeBureau
        {
            get { return _CodeBureau; }
            set { _CodeBureau = value; }
        }
        public int CodeInterlocuteur
        {
            get { return _CodeInterlocuteur; }
            set { _CodeInterlocuteur = value; }
        }
        public DateTime DateContact
        {
            get { return _DateContact; }
            set { _DateContact = value; }
        }
        public string Commentaire
        {
            get { return _Commentaire; }
            set { _Commentaire = value; }
        }
    }
}
