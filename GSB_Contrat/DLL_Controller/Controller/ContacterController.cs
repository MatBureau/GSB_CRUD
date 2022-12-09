using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL_Controller.Controller;
using DLL_DAO;
using DLL_Modele;
using DLL_Persistance;

namespace DLL_Controller.Controller
{
    public static class ContacterController
    {
        private static List<cls_interlocuteur> _ListSelectedInterloc;
        private static List<cls_bureau> _ListSelectedBureau;

        public static  List<cls_contacter> GetListContacter()
        {
            List<cls_contacter> lst_cont = DAO_contacter.requete_select();
            if (lst_cont.Count != 0)
            {
                int compteur = 0;
                int max = GetMaxValueDic(Persistance.dic_contacter);
                List<cls_contacter> lst_trie = new List<cls_contacter>();
                

                //Algo vérifie si le dictionnaire de persistance contient déjà tout les objets afin de ne pas les ajouter en double
                if (Persistance.dic_contacter.Count != 0)
                {
                    foreach (var ct in lst_cont)
                    {
                        if (ct != null)
                        {
                            cls_contacter conTemp = Persistance.dic_contacter.Values.Where(x => x.CodeInterlocuteur == ct.CodeInterlocuteur && x.CodeBureau == ct.CodeBureau && x.DateContact == ct.DateContact && x.Commentaire == ct.Commentaire).ToList().First();
                            if (conTemp == null)
                            {
                                lst_trie.Add(conTemp);
                            }
                        }
                    }
                    int yeet = 0;
                    foreach (cls_contacter contacter in lst_trie)
                    {
                        Persistance.dic_contacter.TryAdd(max + compteur, contacter);
                        compteur++;
                    }
                }
                else
                {
                    foreach (cls_contacter contacter in lst_cont)
                    {
                        Persistance.dic_contacter.TryAdd(max + compteur, contacter);
                        compteur++;
                    }
                }

                return lst_cont;
            }
            return lst_cont = new List<cls_contacter>();
        }

        public static int GetMaxValueDic(ConcurrentDictionary<int, cls_contacter> dic)
        {
            KeyValuePair<int, cls_contacter> max = new KeyValuePair<int, cls_contacter>();
            foreach (var kvp in dic)
            {
                if (kvp.Key > max.Key)
                    max = kvp;
            }
            return max.Key;
        }

        public static bool AddContacter(cls_contacter contacter)
        {
            try
            {
                if (contacter != null)
                {
                    DAO_contacter.RequeteInsert(contacter);
                    Persistance.dic_contacter.Clear();
                    GetListContacter();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }

        public static bool DeleteContacter(List<cls_contacter> lst_cont)
        {
            try
            {
                foreach (cls_contacter cont in lst_cont)
                {
                    DAO_contacter.RequeteSupprimer(cont.CodeBureau,cont.CodeInterlocuteur,cont.DateContact);
                    GetListContacter();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static void InitListeBureau()
        {
            _ListSelectedBureau = new List<cls_bureau>();
        }

        public static void InitListeInterloc()
        {
            _ListSelectedInterloc = new List<cls_interlocuteur>();
        }

        public static List<cls_interlocuteur> ListSelectedInterlocuteur
        {
            get { return _ListSelectedInterloc; }
            set { _ListSelectedInterloc = value; }
        }

        public static List<cls_bureau> ListSelectedBureau
        {
            get { return _ListSelectedBureau; }
            set { _ListSelectedBureau = value; }
        }
    }
}
