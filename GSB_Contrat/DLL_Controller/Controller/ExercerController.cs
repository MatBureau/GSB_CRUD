using DLL_DAO;
using DLL_Modele;
using DLL_Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Controller.Controller
{
    public static class ExercerController
    {
        private static List<cls_secteur> _ListSelectedSecteur;
        private static List<cls_client> _ListSelectedClient;

        public static List<cls_exercer> GetListeExercer()
        {
            List<cls_exercer> list_ex = DAO_Exercer.requete_select();
            if (list_ex.Count != 0)
            {
                foreach (cls_exercer ex in list_ex)
                {
                    int maxKey = Persistance.dic_exercer.Count;
                    Persistance.dic_exercer.TryAdd(maxKey, ex);
                }
                return list_ex;
            }
            return list_ex = new List<cls_exercer>();
        }

        public static bool AddExercer(cls_exercer exer)
        {
            try
            {
                if (exer != null)
                {
                    DAO_Exercer.RequeteInsert(exer);
                    Persistance.dic_exercer.Clear();
                    GetListeExercer();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }

        public static bool DeleteExercer(List<cls_exercer> lst_ex)
        {
            try
            {
                foreach (cls_exercer exer in lst_ex)
                {
                    DAO_Exercer.RequeteSupprimer(exer);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static void InitListeSecteur()
        {
            _ListSelectedSecteur = new List<cls_secteur>();
        }

        public static void InitListeClient()
        {
            _ListSelectedClient = new List<cls_client>();
        }

        public static List<cls_client> ListeSelectedClient
        {
            get { return _ListSelectedClient; }
            set { _ListSelectedClient = value; }
        }

        public static List<cls_secteur> ListSelectedSecteur
        {
            get { return _ListSelectedSecteur; }
            set { _ListSelectedSecteur = value; }
        }
    }
}
