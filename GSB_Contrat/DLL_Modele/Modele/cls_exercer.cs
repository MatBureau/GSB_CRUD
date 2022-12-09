using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Modele
{
    public class cls_exercer
    {
        private int _Codeclient;
        private int _CodeSecteur;

        public cls_exercer(int codeclt, int codesct)
        {
            _Codeclient = codeclt;
            _CodeSecteur = codesct;
        }

        public int Codeclient
        {
            get { return _Codeclient; }
            set { _Codeclient = value; }
        }

        public int CodeSecteur 
        { 
            get { return _CodeSecteur; }
            set { _CodeSecteur = value; }
        }
    }
}
