using DLL_Modele;
using DLL_DAO;
using DLL_Persistance;

namespace DLL_Controller.Controller
{
    public static class BureauController
    {
        public static List<cls_bureau> GetListBureau()
        {
            List<cls_bureau> list_bur = DAO_bureau.requete_select();
            if(list_bur.Count != 0)
            {
                foreach(cls_bureau bureau in list_bur)
                {
                    Persistance.dic_Bureau.TryAdd(bureau.ID, bureau);
                }
                return list_bur;
            }
            return list_bur = new List<cls_bureau>();
        }

        public static bool AddBureau(cls_bureau bureau)
        {
            try
            {
                if (bureau != null)
                {
                    bureau.CodeBureau = DAO_bureau.GetNewIDBureau();
                    DAO_bureau.RequeteInsert(bureau);
                    Persistance.dic_Bureau.Clear();
                    GetListBureau();
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
            
        }

        public static bool DeleteBureau(List<cls_bureau> lst_bur)
        {
            try
            {
                foreach (cls_bureau bureau in lst_bur)
                {
                    DAO_bureau.RequeteSupprimer(bureau.CodeBureau);
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static bool UpdateBureau(cls_bureau bur)
        {
            if (bur != null)
            {
                DAO_bureau.Update(bur);
                return true;
            }
            return false;
        }
    }
}
