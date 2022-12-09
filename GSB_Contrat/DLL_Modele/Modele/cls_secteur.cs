using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Modele
{
    public class cls_secteur:cls_ID
    {
        private int _CodeSecteur;
        private string _LibelleSecteur;
        private ConcurrentDictionary<int, List<int>> _CodeClient;

        public cls_secteur(int p_codeSecteur, string p_libelleSecteur, ConcurrentDictionary<int,List<int>> pCodeClient):base(p_codeSecteur)
        {
            _CodeSecteur = p_codeSecteur;
            _LibelleSecteur = p_libelleSecteur;
            _CodeClient = pCodeClient;
        }

        public int CodeSecteur
        {
            get { return _CodeSecteur; }
            set { _CodeSecteur = value; }
        }

        public string LibelleSecteur
        {
            get { return _LibelleSecteur; }
            set { _LibelleSecteur = value; }
        }
        public ConcurrentDictionary<int, List<int>> CodeClient
        {
            get { return _CodeClient; }
            set { _CodeClient = value; }
        }

    }
}
