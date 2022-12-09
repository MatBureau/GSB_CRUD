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
    public static class InterlocuteurController
    {
        public static List<cls_interlocuteur> GetListInterlocuteur()
        {
            List<cls_interlocuteur> list_interloc = DAO_interlocuteur.requete_selectToList();
            if (list_interloc.Count != 0)
            {
                foreach(cls_interlocuteur interlocuteur in list_interloc)
                {
                    Persistance.dic_Interlocuteur.TryAdd(interlocuteur.ID, interlocuteur);
                }
                return list_interloc;
            }
            return list_interloc = new List<cls_interlocuteur>();
        }
    }
}
