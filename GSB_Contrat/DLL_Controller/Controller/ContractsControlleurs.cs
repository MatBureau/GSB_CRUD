using DLL_Modele;
using DLL_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL_Persistance;

namespace DLL_Controller.Controller
{
    public static class ContractsControlleurs
    {
        public static List<cls_contrat> GetListContrats()
        {
            List<cls_contrat> list_ctr = DAO_Contrat.requete_select();
            if (list_ctr.Count != 0)
            {
                foreach(cls_contrat contrat in list_ctr)
                {
                    Persistance.dic_contrat.TryAdd(contrat.ID, contrat);
                }
                return list_ctr;
            }
            return list_ctr = new List<cls_contrat>();
        }
    }
}
