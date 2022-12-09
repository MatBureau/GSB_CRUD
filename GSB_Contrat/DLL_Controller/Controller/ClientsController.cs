using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL_Modele;
using DLL_DAO;
using DLL_Persistance;

namespace DLL_Controller.Controller
{
    public static class ClientsController
    {
        private static List<cls_secteur> _ListSelectedSec;
        public static List<cls_client> GetListClients()
        {
            List<cls_client> list_clients = DAO_client.requete_select();
            if (list_clients.Count != 0)
            {
                foreach(cls_client client in list_clients)
                {
                    Persistance.dic_Client.TryAdd(client.ID, client);
                }
                    
                return list_clients;
            }
            return list_clients = new List<cls_client>();
        }

        public static bool AddClient(cls_client client)
        {
            try
            {
                if (client != null)
                {
                    client.CodeClient = DAO_client.GetNewIDClient();
                    DAO_client.RequeteInsert(client);
                    Persistance.dic_Client.Clear();
                    GetListClients();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }

        public static void InitListe()
        {
            _ListSelectedSec = new List<cls_secteur>();
        }

        public static List<cls_secteur> ListSelectedSecteurs
        {
            get { return _ListSelectedSec; }
            set { _ListSelectedSec = value; }
        }

        public static bool DeleteClient(List<cls_client> clients)
        {
            try
            {
                foreach (cls_client clt in clients)
                {
                    DAO_client.RequeteSupprimer(clt.CodeClient);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
