using DLL_Persistance;
using DLL_Modele;
using Npgsql;
using System.Collections.Concurrent;


namespace DLL_DAO
{
    public class DAO_interlocuteur
    {
        public static ConcurrentDictionary<int, cls_interlocuteur> requete_select()
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();
            ConcurrentDictionary<int, cls_interlocuteur> dic_temp = new ConcurrentDictionary<int, cls_interlocuteur>();
            try
            {
                using (var conn = connexion.Connexion)

                {
                    Console.Out.WriteLine("Opening connection");

                    using (var command = new NpgsqlCommand("select codeinterlocuteur,nominterlocuteur from interlocuteur", conn))
                    {
                        int compteur = 0;
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            cls_interlocuteur interlocuteur = new cls_interlocuteur(reader.GetInt32(0), reader.GetString(1));
                            Console.WriteLine(interlocuteur.ID+" "+interlocuteur.NomInterlocuteur);
                            dic_temp.TryAdd(interlocuteur.ID,interlocuteur);
                            compteur++;
                        }
                        Console.Out.WriteLine(String.Format("Nombre d'interlocuteur sélectionnés={0}", compteur));
                    }
                }
                DAO_BDD.CloseConn();
                return dic_temp;
            }
            catch (Exception ex)
            {
                DAO_BDD.CloseConn();
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }


        public static List<cls_interlocuteur> requete_selectToList()
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();
            List<cls_interlocuteur> dic_temp = new List<cls_interlocuteur>();
            try
            {
                using (var conn = connexion.Connexion)

                {
                    Console.Out.WriteLine("Opening connection");

                    using (var command = new NpgsqlCommand("select codeinterlocuteur,nominterlocuteur from interlocuteur", conn))
                    {
                        int compteur = 0;
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            cls_interlocuteur interlocuteur = new cls_interlocuteur(reader.GetInt32(0), reader.GetString(1));
                            Console.WriteLine(interlocuteur.ID + " " + interlocuteur.NomInterlocuteur);
                            Persistance.dic_Interlocuteur.TryAdd(interlocuteur.ID, interlocuteur);
                            dic_temp.Add(interlocuteur);
                            compteur++;
                        }
                        Console.Out.WriteLine(String.Format("Nombre d'interlocuteur sélectionnés={0}", compteur));
                    }
                }
                DAO_BDD.CloseConn();
                return dic_temp;
            }
            catch (Exception ex)
            {
                DAO_BDD.CloseConn();
                Console.WriteLine(ex.Message);
                return null;
            }
            
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

                    using (var command = new NpgsqlCommand("delete from interlocuteur where codeinterlocuteur =@ID", conn))
                    {
                        command.Parameters.AddWithValue("ID", pID);
                        command.Prepare();
                        command.ExecuteNonQuery();
                    }
                }
                Persistance.dic_Interlocuteur = requete_select();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            DAO_BDD.CloseConn();
        }

        public static void RequeteInsert(cls_interlocuteur interlocuteur)
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();

            try
            {
                using (var conn = connexion.Connexion)

                {
                    Console.Out.WriteLine("Opening connection");
                    using (var command = new NpgsqlCommand($"insert into interlocuteur(codeinterlocuteur,nominterlocuteur) values (@ID,@Nom)", conn))
                    {
                        command.Parameters.AddWithValue("ID", interlocuteur.CodeInterlocuteur);
                        command.Parameters.AddWithValue("Nom", interlocuteur.NomInterlocuteur);
                        command.Prepare();
                        command.ExecuteNonQuery();
                    }
                }
                Persistance.dic_Interlocuteur = requete_select();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            DAO_BDD.CloseConn();
        }
        public static void Update(cls_interlocuteur interlocuteur)
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();

            try
            {
                using (var conn = connexion.Connexion)

                {
                    Console.Out.WriteLine("Opening connection");
                    using (var command = new NpgsqlCommand($"update interlocuteur set nominterlocuteur=@Nom where codeinterlocuteur=@ID)", conn))
                    {
                        command.Parameters.AddWithValue("ID", interlocuteur.CodeInterlocuteur);
                        command.Parameters.AddWithValue("Nom", interlocuteur.NomInterlocuteur);
                        command.Prepare();
                        command.ExecuteNonQuery();
                    }
                }
                Persistance.dic_Interlocuteur = requete_select();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            DAO_BDD.CloseConn();
        }
    }
}
