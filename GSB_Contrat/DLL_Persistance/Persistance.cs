using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL_Modele;

namespace DLL_Persistance
{
    public class Persistance
    {
        private static ConcurrentDictionary<int, cls_bureau> _Dic_Bureau;
        private static ConcurrentDictionary<int, cls_client> _Dic_Client;
        private static ConcurrentDictionary<int, cls_interlocuteur> _Dic_interlocuteur;
        private static ConcurrentDictionary<int, cls_secteur> _Dic_secteur;
        private static ConcurrentDictionary<int, cls_contrat> _Dic_Contrat;
        private static ConcurrentDictionary<int, cls_contacter> _Dic_Contacter;
        private static ConcurrentDictionary<int, cls_exercer> _Dic_Exercer;


        public static void InitListes()
        {
            _Dic_Bureau = new ConcurrentDictionary<int, cls_bureau>();
            _Dic_Client = new ConcurrentDictionary<int, cls_client>();
            _Dic_interlocuteur = new ConcurrentDictionary<int, cls_interlocuteur>();
            _Dic_secteur = new ConcurrentDictionary<int, cls_secteur>();
            _Dic_Contrat = new ConcurrentDictionary<int, cls_contrat>();
            _Dic_Contacter = new ConcurrentDictionary<int, cls_contacter>();
            _Dic_Exercer = new ConcurrentDictionary<int, cls_exercer>();

        }

        public static ConcurrentDictionary<int,cls_contrat> dic_contrat
        {
            get { return _Dic_Contrat; }
            set { _Dic_Contrat = value; }
        }
        public static ConcurrentDictionary<int,cls_bureau> dic_Bureau
        {
            get { return _Dic_Bureau; }
            set { _Dic_Bureau = value; }
        }

        public static ConcurrentDictionary<int,cls_client> dic_Client
        {
            get { return _Dic_Client; }
            set { _Dic_Client=value; }
        }

        public static ConcurrentDictionary<int,cls_interlocuteur> dic_Interlocuteur
        {
            get { return _Dic_interlocuteur;}
            set { _Dic_interlocuteur = value; }
        }

        public static ConcurrentDictionary<int,cls_secteur> dic_secteur
        {
            get { return _Dic_secteur; }
            set { _Dic_secteur = value; }
        }

        public static ConcurrentDictionary<int, cls_contacter> dic_contacter
        {
            get { return _Dic_Contacter; }
            set { _Dic_Contacter = value; }
        }

        public static ConcurrentDictionary<int,cls_exercer> dic_exercer
        {
            get { return _Dic_Exercer; }
            set { _Dic_Exercer = value; }
        }
    }
}
