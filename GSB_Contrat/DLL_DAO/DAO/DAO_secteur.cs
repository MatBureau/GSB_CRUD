using DLL_Modele;
using Npgsql;
using System.Collections.Concurrent;

namespace DLL_DAO
{
    public class DAO_secteur
    {
        public static ConcurrentDictionary<int, cls_secteur> requete_select()
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();
            ConcurrentDictionary<int, cls_secteur> dic_temp = new ConcurrentDictionary<int, cls_secteur>();
            try
            {
                using (var conn = connexion.Connexion)
                {
                    ConcurrentDictionary<int, List<int>> ClientBySecteur = new ConcurrentDictionary<int, List<int>>();
                    Console.Out.WriteLine("Opening connection");

                    using (var command = new NpgsqlCommand("select codesecteur,libellesecteur from secteur", conn))
                    {
                        int compteur = 0;
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ClientBySecteur = GetClientBySecteur(reader.GetInt32(0));
                            cls_secteur secteur = new cls_secteur(reader.GetInt32(0), reader.GetString(1),ClientBySecteur);
                            Console.WriteLine(secteur.ID+" "+secteur.LibelleSecteur);
                            dic_temp.TryAdd(secteur.ID, secteur);
                            compteur++;
                        }
                        Console.Out.WriteLine(String.Format("Nombre de secteurs sélectionnées={0}", compteur));
                    }
                    DAO_BDD.CloseConn();
                    return dic_temp;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }


        public static List<cls_secteur> requete_selectToList()
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();
            List<cls_secteur> lst_sect = new List<cls_secteur>();
            try
            {
                using (var conn = connexion.Connexion)
                {
                    ConcurrentDictionary<int, List<int>> ClientBySecteur = new ConcurrentDictionary<int, List<int>>();
                    Console.Out.WriteLine("Opening connection");

                    using (var command = new NpgsqlCommand("select codesecteur,libellesecteur from secteur", conn))
                    {
                        int compteur = 0;
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ClientBySecteur = GetClientBySecteur(reader.GetInt32(0));
                            cls_secteur secteur = new cls_secteur(reader.GetInt32(0), reader.GetString(1), ClientBySecteur);
                            Console.WriteLine(secteur.ID + " " + secteur.LibelleSecteur);
                            lst_sect.Add(secteur);
                            compteur++;
                        }
                        Console.Out.WriteLine(String.Format("Nombre de secteurs sélectionnées={0}", compteur));
                    }
                    DAO_BDD.CloseConn();
                    return lst_sect;
                }

            }
            catch (Exception ex)
            {
                DAO_BDD.CloseConn();
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        private static ConcurrentDictionary<int, List<int>> GetClientBySecteur(int pCodeSecteur)
        {
            ConcurrentDictionary<int, List<int>> client = new ConcurrentDictionary<int, List<int>>();
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();
            using (var conn = connexion.Connexion)
            {
                using (var secteurcommand = new NpgsqlCommand($"select codeclient from exercer where codesecteur=@ID", conn))
                {
                    secteurcommand.Parameters.AddWithValue("ID", pCodeSecteur);
                    secteurcommand.Prepare();
                    var readercommand = secteurcommand.ExecuteReader();
                    List<int> codeclient = new List<int>();
                    while (readercommand.Read())
                    {
                        codeclient.Add(readercommand.GetInt32(0));

                    }
                    client.TryAdd(pCodeSecteur, codeclient);
                }
            }
            DAO_BDD.CloseConn();
            return client;
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

                    using (var command = new NpgsqlCommand("delete from secteur where codesecteur =@ID", conn))
                    {
                        command.Parameters.AddWithValue("ID", pID);
                        command.Prepare();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            DAO_BDD.CloseConn();
        }

        public static void RequeteInsert(cls_secteur secteur)
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();

            try
            {
                using (var conn = connexion.Connexion)

                {
                    Console.Out.WriteLine("Opening connection");
                    using (var command = new NpgsqlCommand($"insert into secteur(codesecteur,libellesecteur) values (@ID,@Libelle)", conn))
                    {
                        command.Parameters.AddWithValue("ID", secteur.CodeSecteur);
                        command.Parameters.AddWithValue("Libelle", secteur.LibelleSecteur);
                        command.Prepare();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            DAO_BDD.CloseConn();
        }
        public static void Update(cls_secteur secteur)
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();

            try
            {
                using (var conn = connexion.Connexion)

                {
                    Console.Out.WriteLine("Opening connection");
                    using (var command = new NpgsqlCommand($"update secteur set libellesecteur=@Libelle where codesecteur=@ID", conn))
                    {
                        command.Parameters.AddWithValue("ID", secteur.CodeSecteur);
                        command.Parameters.AddWithValue("Libelle", secteur.LibelleSecteur);
                        command.Prepare();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            DAO_BDD.CloseConn();
        }
    }
}
