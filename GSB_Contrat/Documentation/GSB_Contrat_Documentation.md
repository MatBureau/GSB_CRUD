# **Documentation du GSB_COntrat :**

## Objectif: faire une application console qui va effectuer le chargement de la persistance en .NET 6

## Organisation structurelle:

### -Modèle:
	-Classes métiers:
		-cls_ID (private int c_ID) --> toutes les classes vont hériter de cls_ID. 
		-cls_bureau (int codebureau, string villebureau, string pays)
			-Constructeur et getter/setter pour les membres privées.
		-cls_interlocuteur (int codeinterlocuteur, string nominterlocuteur)
		-cls_client (int codeclient, string raisonsociale, string adresse)
		-cls_secteur (int codesecteur, string libellesecteur)
### (-Vues)

### -DAO: liaison avec la base de données --> une classe DAO par classe métiers avec fonction récupère, insère, supprime de base:
	-DAO_bureau (public static InsertBureau(),public static DeleteBureau(), public static GetBureau())
	-DAO_interlocuteur
	-DAO_client
	-DAO_secteur

### -Persistance: Une classe unique qui contiendra les listes d'objets chargés en mémoire avec les listes en static (membre à portée de classe)

### -Controller: liaison entre modèle/persistance et les vues.


#### Pour les collections on utilisera des dictionary.

### On séparera nos éléments en plusieurs projets:
- DLL_Controller (bibliothèque de classe): Controller, persistance
- DLL_DAO (bibliothèque de classe): DAO
- DLL_Modele (bibliothèque de classe): Modèle 
- GSB_Contrat (Application Console)