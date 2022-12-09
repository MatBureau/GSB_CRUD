using DLL_Modele;
using DLL_DAO;
using DLL_Persistance;


namespace DLL_Controller.Controller
{
    public static class SecteursController
    {
        

        public static List<cls_secteur> GetListSecteurs()
        {
            List<cls_secteur> list_bur = DAO_secteur.requete_selectToList();
            if (list_bur.Count != 0)
            {
                foreach(cls_secteur secteur in list_bur)
                {
                    Persistance.dic_secteur.TryAdd(secteur.ID, secteur);
                }
                return list_bur;
            }
            return list_bur = new List<cls_secteur>();
        }
        
    }
}
