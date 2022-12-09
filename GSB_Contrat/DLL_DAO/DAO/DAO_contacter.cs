using DLL_Modele;
using Npgsql;

namespace DLL_DAO
{
    public class DAO_contacter
    {
        /// <summary>
        /// Requete select sans condition
        /// </summary>
        /// <returns></returns>
        public static List<cls_contacter> requete_select()
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();
            List < cls_contacter > lst_cont = new List<cls_contacter>();
            try
            {
                using (var conn = connexion.Connexion)

                {
                    Console.Out.WriteLine("Opening connection");

                    using (var command = new NpgsqlCommand("select codebureau,codeinterlocuteur,datecontact,commentaire from contacter", conn))
                    {
                        int compteur = 0;
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            cls_contacter contacter = new cls_contacter(reader.GetInt32(0), reader.GetInt32(1), reader.GetDateTime(2), reader.GetString(3));
                            Console.WriteLine(contacter.CodeBureau+" "+contacter.CodeInterlocuteur+ " " + contacter.DateContact+" "+contacter.Commentaire);
                            compteur++;
                            lst_cont.Add(contacter);
                        }
                        Console.Out.WriteLine(String.Format("Nombre de bureau sélectionnées={0}", compteur));
                    }
                }
                DAO_BDD.CloseConn();
                return lst_cont;
            }
            catch (Exception ex)
            {
                DAO_BDD.CloseConn(); 
                Console.WriteLine(ex.Message);
                return lst_cont;
            }
            
        }
        /// <summary>
        /// Ne pas utiliser pour le moment (aucune suppression des références à la clé CodeBureau)
        /// </summary>
        /// <param name="pID"></param>
        public static void RequeteSupprimer(int pCodeBureau, int pInterlocuteur,DateTime pDatecontact)
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();

            try
            {
                using (var conn = connexion.Connexion)

                {
                    Console.Out.WriteLine("Opening connection");

                    using (var command = new NpgsqlCommand("delete from contacter where codebureau = @CodeBureau and codeinterlocuteur= @interlocuteur and datecontact= @date", conn))
                    {
                        command.Parameters.AddWithValue("CodeBureau", pCodeBureau);
                        command.Parameters.AddWithValue("interlocuteur", pInterlocuteur);
                        command.Parameters.AddWithValue("date", pDatecontact);
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

        public static void RequeteInsert(cls_contacter contacter)
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();

            try
            {
                using (var conn = connexion.Connexion)

                {
                    Console.Out.WriteLine("Opening connection");
                    using (var command = new NpgsqlCommand($"insert into contacter(codebureau,codeinterlocuteur,datecontact,commentaire) values (@CodeBureau,@interlocuteur,@datecontact,@commentaire)", conn))
                    {
                        command.Parameters.AddWithValue("CodeBureau", contacter.CodeBureau);
                        command.Parameters.AddWithValue("interlocuteur", contacter.CodeInterlocuteur);
                        command.Parameters.AddWithValue("datecontact", contacter.DateContact);
                        command.Parameters.AddWithValue("commentaire", contacter.Commentaire);
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
        public static void Update(cls_contacter contacter)
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();

            try
            {
                using (var conn = connexion.Connexion)

                {
                    Console.Out.WriteLine("Opening connection");
                    using (var command = new NpgsqlCommand($"update contacter set codebureau=@CodeBureau,codeinterlocuteur=@interlocuteur,datecontact=@datecontact,commentaire=@commentaire where codebureau=@CodeBureau and codeinterlocuteur=@interlocuteur and datecontact=@datecontact", conn))
                    {
                        command.Parameters.AddWithValue("CodeBureau", contacter.CodeBureau);
                        command.Parameters.AddWithValue("interlocuteur", contacter.CodeInterlocuteur);
                        command.Parameters.AddWithValue("datecontact", contacter.DateContact);
                        command.Parameters.AddWithValue("commentaire", contacter.Commentaire);
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
