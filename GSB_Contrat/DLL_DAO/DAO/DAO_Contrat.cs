using DLL_Modele;
using Npgsql;

namespace DLL_DAO
{
    public class DAO_Contrat
    {
        public static List<cls_contrat> requete_select()
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();
            List<cls_contrat> lst_ctr = new List<cls_contrat>();
            try
            {
                using (var conn = connexion.Connexion)

                {
                    Console.Out.WriteLine("Opening connection");

                    using (var command = new NpgsqlCommand("select refcontrat,objetcontrat,datecontrat,tauxcommission,montantcontrat,codebureau,codeclient,codeinterlocuteur from contrat", conn))
                    {
                        int compteur = 0;
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string montantcontratToString = reader.GetInt32(4).ToString();
                            string TauxCommissionToString = reader.GetInt32(3).ToString();
                            cls_contrat contrat = new cls_contrat(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), TauxCommissionToString, montantcontratToString, reader.GetInt32(5),reader.GetInt32(6),reader.GetInt32(7)) ;
                            Console.WriteLine(contrat.ID+" "+contrat.ObjetContrat);
                            lst_ctr.Add(contrat);
                            compteur++;
                        }
                        Console.Out.WriteLine(String.Format("Nombre de contrat sélectionnées={0}", compteur));
                    }
                }
                DAO_BDD.CloseConn();
                return lst_ctr;
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

                    using (var command = new NpgsqlCommand("delete from contrat where refcontrat =@ID" , conn))
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

        public static void RequeteInsert(cls_contrat contrat)
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();

            try
            {
                using (var conn = connexion.Connexion)

                {
                    Console.Out.WriteLine("Opening connection");
                    using (var command = new NpgsqlCommand("insert into contrat(refcontrat,objetcontrat,datecontrat,tauxcommission,montantcontrat,codebureau,codeclient,codeinterlocuteur) values (@ID,@ObjetContrat,@DateContrat,@TauxCommission,@MontantContrat,@CodeBureau,@CodeClient,@CodeInterlocuteur)", conn))
                    {
                        command.Parameters.AddWithValue("ID", contrat.RefContrat);
                        command.Parameters.AddWithValue("ObjetContrat", contrat.ObjetContrat);
                        command.Parameters.AddWithValue("DateContrat", contrat.DateContrat);
                        command.Parameters.AddWithValue("TauxCommission", contrat.TauxCommission);
                        command.Parameters.AddWithValue("MontantContrat", contrat.MontantContrat);
                        command.Parameters.AddWithValue("CodeBureau", contrat.CodeBureau);
                        command.Parameters.AddWithValue("CodeClient", contrat.CodeClient);
                        command.Parameters.AddWithValue("CodeInterlocuteur", contrat.CodeInterlocuteur);
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
        public static void Update(cls_contrat contrat)
        {
            DAO_BDD.Connecter();
            DAO_BDD connexion = new DAO_BDD();

            try
            {
                using (var conn = connexion.Connexion)

                {
                    Console.Out.WriteLine("Opening connection");
                    using (var command = new NpgsqlCommand("update contrat set objetcontrat=@ObjetContrat,datecontrat=@DateContrat,tauxcommission=@TauxCommission,montantcontrat=@MontantContrat,codebureau=@CodeBureau,codeclient=@CodeClient,codeinterlocuteur=@CodeInterlocuteur where refcontrat=@ID", conn))
                    {
                        command.Parameters.AddWithValue("ID", contrat.RefContrat);
                        command.Parameters.AddWithValue("ObjetContrat", contrat.ObjetContrat);
                        command.Parameters.AddWithValue("DateContrat", contrat.DateContrat);
                        command.Parameters.AddWithValue("TauxCommission", contrat.TauxCommission);
                        command.Parameters.AddWithValue("MontantContrat", contrat.MontantContrat);
                        command.Parameters.AddWithValue("CodeBureau", contrat.CodeBureau);
                        command.Parameters.AddWithValue("CodeClient", contrat.CodeClient);
                        command.Parameters.AddWithValue("CodeInterlocuteur", contrat.CodeInterlocuteur);
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
