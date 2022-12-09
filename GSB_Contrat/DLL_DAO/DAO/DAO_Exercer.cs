using DLL_Modele;
using Npgsql;

namespace DLL_DAO
{
    public class DAO_Exercer
    {
        /// <summary>
        /// Requete select sans condition
        /// </summary>
        /// <returns></returns>
        public static List<cls_exercer> requete_select()
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();
            List<cls_exercer> list = new List<cls_exercer>();
            try
            {
                using (var conn = connexion.Connexion)

                {
                    Console.Out.WriteLine("Opening connection");

                    using (var command = new NpgsqlCommand("select codeclient,codesecteur from exercer", conn))
                    {
                        int compteur = 0;
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            cls_exercer exercer = new cls_exercer(reader.GetInt32(0), reader.GetInt32(1));
                            list.Add(exercer);
                            compteur++;
                        }
                        Console.Out.WriteLine(String.Format("Nombre de exercer sélectionnées={0}", compteur));
                    }
                }
                DAO_BDD.CloseConn();
                return list;
            }
            catch (Exception ex)
            {
                DAO_BDD.CloseConn();
                Console.WriteLine(ex.Message);
                return null;
            }

        }
        /// <summary>
        /// Ne pas utiliser pour le moment (aucune suppression des références à la clé CodeBureau)
        /// </summary>
        /// <param name="pID"></param>
        public static void RequeteSupprimer(cls_exercer exercer)
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();

            try
            {
                using (var conn = connexion.Connexion)

                {
                    Console.Out.WriteLine("Opening connection");

                    using (var command = new NpgsqlCommand("delete from exercer where codeclient = @CodeClient AND codesecteur=@CodeSecteur", conn))
                    {
                        command.Parameters.AddWithValue("CodeClient", exercer.Codeclient);
                        command.Parameters.AddWithValue("CodeSecteur", exercer.CodeSecteur);
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

        public static void RequeteInsert(cls_exercer exercer)
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();

            try
            {
                using (var conn = connexion.Connexion)

                {
                    Console.Out.WriteLine("Opening connection");
                    using (var command = new NpgsqlCommand($"insert into exercer(codeclient,codesecteur) values (@CodeClient,@CodeSecteur)", conn))
                    {
                        command.Parameters.AddWithValue("CodeClient", exercer.Codeclient);
                        command.Parameters.AddWithValue("CodeSecteur", exercer.CodeSecteur);
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

        public static void Update(cls_exercer exercer, int codeclientintial, int codesecteurinitial)
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();

            try
            {
                using (var conn = connexion.Connexion)

                {
                    Console.Out.WriteLine("Opening connection");
                    using (var command = new NpgsqlCommand($"update exercer set codeclient=@CodeClient,codesecteur=@CodeSecteur where codeclient=@CodeBureauInit and codesecteur=@CodeSecteurInit", conn))
                    {
                        command.Parameters.AddWithValue("CodeClient", exercer.Codeclient);
                        command.Parameters.AddWithValue("VilleBureau", exercer.CodeSecteur);
                        command.Parameters.AddWithValue("CodeClientInit", codeclientintial);
                        command.Parameters.AddWithValue("CodeSecteurInit", codesecteurinitial);
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
    }
}
