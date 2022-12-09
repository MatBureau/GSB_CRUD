using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Modele
{
    public class cls_contrat:cls_ID
    {
        private int _RefContrat;
        private string _ObjetContrat;
        private DateTime _DateContrat;
        private string _TauxCommission;
        private string _MontantContrat;
        private int _CodeBureau;
        private int _CodeClient;
        private int _CodeInterlocuteur;

        public cls_contrat(int pRefContrat, string pObjetContrat, DateTime pDateContrat, string pTauxCommission, string pMontantContrat, int pCodeBureau, int pCodeClient, int pCodeinterlocuteur):base(pRefContrat)
        {
            _RefContrat = pRefContrat;
            _ObjetContrat = pObjetContrat;
            _DateContrat = pDateContrat;
            _TauxCommission = pTauxCommission;
            _CodeBureau = pCodeBureau;
            _CodeClient = pCodeClient;
            _MontantContrat = pMontantContrat;
            _CodeInterlocuteur = pCodeinterlocuteur;
        }

        public int RefContrat { get { return _RefContrat; } set { _RefContrat = value; } }

        public string ObjetContrat
        {
            get { return _ObjetContrat; } set { _ObjetContrat = value;}
        }

        public DateTime DateContrat
        {
            get { return _DateContrat; } set { _DateContrat = value; }
        }

        public string TauxCommission
        {
            get { return _TauxCommission; } set { _TauxCommission = value;}
        }

        public string MontantContrat
        {
            get { return _MontantContrat; } set { _MontantContrat = value;}
        }

        public int CodeBureau
        {
            get { return _CodeBureau; } set { _CodeBureau = value;}
        }

        public int CodeInterlocuteur
        {
            get { return _CodeInterlocuteur; } set { _CodeInterlocuteur = value;}
        }

        public int CodeClient
        {
            get { return _CodeClient; } set { _CodeClient = value;}
        }
    }
}
