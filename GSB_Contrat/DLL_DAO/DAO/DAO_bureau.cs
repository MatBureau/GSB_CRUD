using DLL_Modele;
using Npgsql;

namespace DLL_DAO
{
    public class DAO_bureau
    {
        /// <summary>
        /// Requete select sans condition
        /// </summary>
        /// <returns></returns>
        public static List<cls_bureau> requete_select()
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();
            List<cls_bureau> list = new List<cls_bureau>();
            try
            {
                using (var conn = connexion.Connexion)

                {
                    Console.Out.WriteLine("Opening connection");

                    using (var command = new NpgsqlCommand("select codebureau,villebureau,pays from bureau", conn))
                    {
                        int compteur=0;
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            cls_bureau bureau = new cls_bureau(reader.GetInt32(0),reader.GetString(1),reader.GetString(2));
                            Console.WriteLine(bureau.ID +" "+bureau.VilleBureau);
                            list.Add(bureau);
                            compteur++;
                        }
                        Console.Out.WriteLine(String.Format("Nombre de bureau sélectionnées={0}", compteur));
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
        public static void RequeteSupprimer(int pID)
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();

            try
            {
                using (var conn = connexion.Connexion)

                {
                    Console.Out.WriteLine("Opening connection");

                    using (var command = new NpgsqlCommand("delete from contrat where codebureau = @CodeBureau" +
                        ";delete from contacter where codebureau = @CodeBureau" +
                        ";delete from bureau where codebureau = @CodeBureau", conn))
                    {
                        command.Parameters.AddWithValue("CodeBureau",pID);
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

        public static void RequeteInsert(cls_bureau bureau)
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();

            try
            {
                using (var conn = connexion.Connexion)

                {
                    Console.Out.WriteLine("Opening connection");
                    using (var command = new NpgsqlCommand($"insert into bureau(codebureau,villebureau,pays) values (@CodeBureau,@VilleBureau,@Pays)", conn))
                    {
                        command.Parameters.AddWithValue("CodeBureau", bureau.CodeBureau);
                        command.Parameters.AddWithValue("VilleBureau", bureau.VilleBureau);
                        command.Parameters.AddWithValue("Pays", bureau.Pays);
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

        public static void Update(cls_bureau bureau)
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();

            try
            {
                using (var conn = connexion.Connexion)

                {
                    Console.Out.WriteLine("Opening connection");
                    using (var command = new NpgsqlCommand($"update bureau set villebureau=@VilleBureau,pays=@Pays where codebureau=@CodeBureau", conn))
                    {
                        command.Parameters.AddWithValue("CodeBureau", bureau.CodeBureau);
                        command.Parameters.AddWithValue("VilleBureau", bureau.VilleBureau);
                        command.Parameters.AddWithValue("Pays", bureau.Pays);
                        command.Prepare();
                        command.ExecuteNonQuery();
                    }
                }
                requete_select();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            DAO_BDD.CloseConn();
        }

        public static int GetNewIDBureau()
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();
            int id = 0;
            try
            {
                using (var conn = connexion.Connexion)

                {
                    Console.Out.WriteLine("Opening connection");

                    using (var command = new NpgsqlCommand("select MAX(codebureau) from bureau", conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            id= reader.GetInt32(0);
                        }
                    }
                }
                DAO_BDD.CloseConn();
                return id+1;
            }
            catch (Exception ex)
            {
                DAO_BDD.CloseConn();
                Console.WriteLine(ex.Message);
                return id+1;
            }
        }
    }
}