using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Modele
{
    public class cls_interlocuteur:cls_ID
    {
        private int _CodeInterlocuteur;
        private string _NomInterlocuteur;
        public cls_interlocuteur(int p_CodeInterlocuteur,string p_NomInterlocuteur):base(p_CodeInterlocuteur)
        {
            _CodeInterlocuteur = p_CodeInterlocuteur;
            _NomInterlocuteur = p_NomInterlocuteur;
        }

        public int CodeInterlocuteur
        {
            get { return _CodeInterlocuteur; }
            set { _CodeInterlocuteur = value; }
        }

        public string NomInterlocuteur
        {
            get { return _NomInterlocuteur; }
            set { _NomInterlocuteur=value; }
        }
    }
}
