using DLL_DAO;
using DLL_Controller;
using System.Collections.Concurrent;
using DLL_Modele;
using DLL_Controller.Controller;

string connectionStringTest =ConnectionService.GetConnectionString();
Console.WriteLine(connectionStringTest);
//Persistance.InitListes();
DAO_bureau.requete_select();
DAO_client.requete_select();
DAO_interlocuteur.requete_select();
DAO_secteur.requete_select();

