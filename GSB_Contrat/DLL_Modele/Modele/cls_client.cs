using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Modele
{
    public class cls_client:cls_ID
    {
        private int _CodeClient;
        private string _RaisonSociale;
        private string _Adresse;
        private ConcurrentDictionary<int,List<int>> _CodeSecteur;

        public cls_client(int p_CodeClient,string p_RaisonSociale,string p_Adresse, ConcurrentDictionary<int,List<int>> p_CodeSecteur) : base(p_CodeClient)
        {
            _CodeClient = p_CodeClient;
            _RaisonSociale = p_RaisonSociale;
            _Adresse = p_Adresse;
            _CodeSecteur = p_CodeSecteur;//j'ajoute ce commentaire
        }

        public int CodeClient
        {
            get { return _CodeClient; }
            set { _CodeClient = value; }
        }
        public string RaisonSociale
        {
            get { return _RaisonSociale; }
            set { _RaisonSociale = value; }
        }
        public string Adresse
        {
            get { return _Adresse; }
            set { _Adresse = value; }
        }
        public ConcurrentDictionary<int,List<int>> CodeSecteur
        {
            get { return _CodeSecteur; }
            set { _CodeSecteur = value; }
        }
        
    }
}
