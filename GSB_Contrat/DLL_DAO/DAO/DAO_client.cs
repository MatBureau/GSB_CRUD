using DLL_Modele;
using Npgsql;
using System.Collections.Concurrent;

namespace DLL_DAO
{
    public class DAO_client
    {
        public static List<cls_client> requete_select()
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();
            List<cls_client> list_client = new List<cls_client>();
            try
            {
                using (var conn = connexion.Connexion)
                {
                    ConcurrentDictionary<int, List<int>> secteurByClient = new ConcurrentDictionary<int, List<int>>();
                    Console.Out.WriteLine("Opening connection");
                    using (var command = new NpgsqlCommand("select codeclient,raisonsocialeclient,adresseclient from client", conn))
                    {
                        int compteur = 0;
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            secteurByClient = GetSecteursByClient(reader.GetInt32(0));
                            cls_client client = new cls_client(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), secteurByClient);
                            Console.WriteLine(client.ID + " " + client.RaisonSociale);
                            list_client.Add(client);
                            compteur++;
                        }
                        Console.Out.WriteLine(String.Format("Nombre de client sélectionnées={0}", compteur));
                    }
                }
                DAO_BDD.CloseConn();
                return list_client;
            }
            catch (Exception ex)
            {
                DAO_BDD.CloseConn();
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        private static ConcurrentDictionary<int, List<int>> GetSecteursByClient(int pCodeClient)
        {
            ConcurrentDictionary<int, List<int>> secteur = new ConcurrentDictionary<int, List<int>>();
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();
            using (var conn = connexion.Connexion)
            {
                using (var secteurcommand = new NpgsqlCommand($"select codesecteur from exercer where codeclient=@ID", conn))
                {
                    secteurcommand.Parameters.AddWithValue("ID", pCodeClient);
                    secteurcommand.Prepare();
                    var readercommand = secteurcommand.ExecuteReader();
                    List<int> codesecteur = new List<int>();
                    while (readercommand.Read())
                    {
                        codesecteur.Add(readercommand.GetInt32(0));

                    }
                    secteur.TryAdd(pCodeClient, codesecteur);
                }
            }
            DAO_BDD.CloseConn();
            return secteur;
        }

        public static void RequeteSupprimer(int pID)
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();

            try
            {
                using (var conn = connexion.Connexion)

                {
                    Console.Out.WriteLine("Opening connection");

                    using (var command = new NpgsqlCommand("delete from exercer where codeclient=@ID;"+
                                "delete from contrat where codeclient = @ID; "+
                                "delete from client where codeclient = @ID", conn))
                    {
                        command.Parameters.AddWithValue("ID", pID);
                        command.Prepare();
                        command.ExecuteNonQuery();
                    }
                }
                requete_select();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            DAO_BDD.CloseConn();
        }

        public static void RequeteInsert(cls_client client)
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();

            try
            {
                using (var conn = connexion.Connexion)

                {
                    Console.Out.WriteLine("Opening connection");
                    using (var command = new NpgsqlCommand($"insert into client(codeclient,raisonsocialeclient,adresseclient) values (@ID,@RaisonSociale,@Adresse)", conn))
                    {
                        command.Parameters.AddWithValue("ID", client.CodeClient);
                        command.Parameters.AddWithValue("RaisonSociale", client.RaisonSociale);
                        command.Parameters.AddWithValue("Adresse", client.Adresse);
                        command.Prepare();
                        command.ExecuteNonQuery();
                    }
                }
                requete_select();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            DAO_BDD.CloseConn();
        }

        public static void Update(cls_client client)
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();

            try
            {
                using (var conn = connexion.Connexion)

                {
                    Console.Out.WriteLine("Opening connection");
                    using (var command = new NpgsqlCommand($"update client set raisonsocialeclient=@RaisonSociale,adresseclient=@Adresse where codeclient=@ID", conn))
                    {
                        command.Parameters.AddWithValue("ID", client.ID);
                        command.Parameters.AddWithValue("RaisonSociale", client.RaisonSociale);
                        command.Parameters.AddWithValue("Adresse", client.Adresse);
                        command.Prepare();
                        command.ExecuteNonQuery();
                    }
                }
                requete_select();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            DAO_BDD.CloseConn();
        }

        public static int GetNewIDClient()
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();
            int id = 0;
            try
            {
                using (var conn = connexion.Connexion)

                {
                    Console.Out.WriteLine("Opening connection");

                    using (var command = new NpgsqlCommand("select MAX(codeclient) from client", conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            id = reader.GetInt32(0);
                        }
                    }
                }
                DAO_BDD.CloseConn();
                return id + 1;
            }
            catch (Exception ex)
            {
                DAO_BDD.CloseConn();
                Console.WriteLine(ex.Message);
                return id + 1;
            }
        }
    }
}
