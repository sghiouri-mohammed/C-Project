using System;
using Org.BouncyCastle.Math.EC.Rfc7748;
using MySql.Data.MySqlClient;
using VeloMax.Models;
using VeloMax.Services;
using Org.BouncyCastle.Asn1.Misc;

namespace VeloMax
{
    class Program
    {

        static void Main(string[] args)
        {
            
            string x = " " ;
            while ( x != "stop" && x != "Stop" && x != "STOP" )
            {
                Console.WriteLine("Bienvenue dans le système VeloMax !");
                Console.WriteLine("Bonjour Monsieur Legrand !");
                Console.WriteLine("Que souhaitez-vous faire ? ");
                Console.WriteLine("1. Gérer Les Clients Particulier ");
                Console.WriteLine("2. Gérer Les Boutiques ");
                Console.WriteLine("3. Gérer Les Fournisseurs ");
                Console.WriteLine("4. Voir les Statistiques du Magasin ");
                Console.WriteLine("5. Gestion Fidelio ");
                Console.WriteLine("6. Gestion Programme Fidelio ");
                Console.WriteLine("7. Gestion des Modèles de Vélo eet Assemblage ");
                Console.WriteLine("8. Gestion des commandes de Vélos ");

                Console.Write("Votre choix : ");
                string choix = Console.ReadLine();

                if (choix == "1")
                {
                    Console.WriteLine("Que souhaitez-vous faire ? ");
                    Console.WriteLine("1. Ajouter un particulier ");
                    Console.WriteLine("2. Modifier un particulier ");
                    Console.WriteLine("3. Supprimer un particulier ");
                    Console.WriteLine("4. Lister les particuliers ");

                    Console.Write("Votre choix : ");
                    string choix_particulier = Console.ReadLine();

                    if (choix_particulier == "1"){
                        // Ajouter un particulier
                        AjouterParticulier();

                    }else if (choix_particulier == "2") {
                        Console.Write(" Donner l'id du particulier que vous voulez modifier : ");
                        string id_particulier = Console.ReadLine();
                        // Modifier un particulier
                        ModifierParticulier();

                    }else if (choix_particulier == "3") {
                        SupprimerParticulier();

                    }else if (choix_particulier == "4") {
                        PrintAllParticuliers();
                    }
                    
                }
                else if (choix == "2")
                {
                    Console.WriteLine(" Que souhaitez-vous faire ? ");
                    Console.WriteLine("1. Ajouter une Boutique ");
                    Console.WriteLine("2. Modifier une Boutique ");
                    Console.WriteLine("3. Supprimer une Boutique ");
                    Console.WriteLine("4. Lister les Boutiques ");

                    Console.Write("Votre choix : ");
                    string choix_particulier = Console.ReadLine();

                    if (choix_particulier == "1"){
                        // Ajouter une Boutique
                        AjouterBoutique();

                    }else if (choix_particulier == "2") {
                        // Modifier une Boutique
                        ModifierBoutique();

                    }else if (choix_particulier == "3") {
                        SupprimerBoutique();

                    }else if (choix_particulier == "4") {
                        PrintAllBoutiques();

                    }
                }else if(choix == "3") {

                    Console.WriteLine("Que souhaitez-vous faire ? ");
                    Console.WriteLine("1. Ajouter un Fournisseur ");
                    Console.WriteLine("2. Modifier un Fournisseur ");
                    Console.WriteLine("3. Supprimer un Fournisseur ");
                    Console.WriteLine("4. Lister les Fournisseurs ");

                    Console.Write("Votre choix : ");
                    string choix_fournisseur = Console.ReadLine();

                    if (choix_fournisseur == "1"){
                        // Ajouter une Boutique
                        AjouterFournisseur();

                    }else if (choix_fournisseur == "2") {
                        // Modifier une Boutique
                        ModifierFournisseur();

                    }else if (choix_fournisseur == "3") {
                        SupprimerFournisseur();

                    }else if (choix_fournisseur == "4") {
                        PrintAllFournisseurs();

                    }   
                }else if (choix == "4"){

                    Console.WriteLine("1. Stock par Vélo");
                    Console.WriteLine("2. Nombre de Fournisseurs");
                    Console.WriteLine("3. Nombre de Vélos");
                    Console.WriteLine("4. Quantité vendue pour chaque Vélo");
                    Console.WriteLine("5. Meilleur client Particulier (qui fait le plus de ventes)");
                    Console.WriteLine("6. Liste des membres pour chaque programme Fidelio");
                    Console.WriteLine("7. Moyenne des montants des commandes");
                    Console.WriteLine("8. Liste des produits ayant une quantité en stock <= 2");
                    Console.WriteLine("9. Nombre de commandes par client Particulier");

                    
                    Console.Write("Votre choix : ");
                    string choix_stats = Console.ReadLine();

                    StatistiqueService stats = new StatistiqueService();


                    if (choix_stats == "1") {
                        Console.WriteLine("Affichage du stock par vélo...");
                        stats.StockParVelo();
                    }
                    else if (choix_stats == "2") {
                        Console.WriteLine("Affichage du nombre de fournisseurs...");
                        stats.NombreFournisseurs();
                    }
                    else if (choix_stats == "3") {
                        Console.WriteLine("Affichage du nombre de vélos...");
                        stats.NombreVelos();
                    }
                    else if (choix_stats == "4") {
                        Console.WriteLine("Affichage de la quantité vendue pour chaque vélo...");
                        stats.QuantiteVendueParVelo();
                    }
                    else if (choix_stats == "5") {
                        Console.WriteLine("Affichage du meilleur client particulier...");
                        stats.MeilleurClientParticulier();
                    }
                    else if (choix_stats == "6") {
                        Console.WriteLine("Affichage de la liste des membres pour chaque programme fidélité...");
                        stats.MembresParProgrammeFidelite();
                    }
                    else if (choix_stats == "7") {
                        Console.WriteLine("Affichage de la moyenne des montants des commandes...");
                        stats.MoyenneMontantsCommandes();
                    }
                    else if (choix_stats == "8") {
                        Console.WriteLine("Affichage de la liste des produits ayant une quantité en stock <= 2...");
                        stats.ProduitsQuantiteStockFaible();
                    }
                    else if (choix_stats == "9") {
                        Console.WriteLine("Affichage du nombre de commandes par client particulier...");
                        stats.NombreCommandesParClientParticulier();
                    }               
                    
                }else if ( choix == "5"){

                    Console.WriteLine("Que souhaitez-vous faire ? ");
                    Console.WriteLine("1. Ajouter un programme Fidelio ");
                    Console.WriteLine("2. Modifier un programme Fidelio ");
                    Console.WriteLine("3. Supprimer un programme Fidelio ");
                    Console.WriteLine("4. Lister les programmes Fidelio ");

                    Console.Write("Votre choix : ");
                    string choix_fidelio = Console.ReadLine();

                    if (choix_fidelio == "1"){
                        // Ajouter une Boutique
                        AjouterFidelio();

                    }else if (choix_fidelio == "2") {
                        // Modifier une Boutique
                        ModifierFidelio();

                    }else if (choix_fidelio == "3") {
                        SupprimerFidelio();

                    }else if (choix_fidelio == "4") {
                        PrintAllFidelio();
                    }   

                }else if( choix == "6" ){
                    Console.WriteLine("Que souhaitez-vous faire ? ");
                    Console.WriteLine("1. Afficher le nombre de commandes par clients ");
                    Console.WriteLine("2. Affecter un Client à un Programme Fidelio ");
                    Console.WriteLine("3. Affecter la liste des clients affectés à un programme Fidelio ");

                    Console.Write("Votre choix : ");
                    string choix_fidelio = Console.ReadLine();

                    if (choix_fidelio == "1"){
                        // Ajouter une Boutique
                        AjouterFidelio();

                    }else if (choix_fidelio == "2") {
                        // Modifier une Boutique
                        AffecterClientAFidelio();

                    }else if (choix_fidelio == "3") {
                        // Modifier une Boutique
                        PrintAllClientFidelio();
                    } 
                }else if ( choix == "7"){

                    Console.WriteLine("Que souhaitez-vous faire ? ");
                    Console.WriteLine("1. Ajouter un Modèle d'assemblage ");
                    Console.WriteLine("2. Modifier un Modèle d'assemblage ");
                    Console.WriteLine("3. Supprimer un Modèle d'assemblage ");
                    Console.WriteLine("4. Lister les Modèles d'assemblage ");

                    Console.Write("Votre choix : ");
                    string choix_assemblage = Console.ReadLine();

                    if (choix_assemblage == "1"){
                        // Ajouter une Boutique
                        AjouterAssemblage();

                    }else if (choix_assemblage == "2") {
                        // Modifier une Boutique
                        ModifierAssemblage();

                    }else if (choix_assemblage == "3") {
                        SupprimerAssemblage();

                    }else if (choix_assemblage == "4") {
                        PrintAllAssemblages();
                    }   

                }else if ( choix == "8"){

                    Console.WriteLine("Que souhaitez-vous faire ? ");
                    Console.WriteLine("1. Ajouter une Commande pour un client Particulier ");
                    Console.WriteLine("2. Modifier une Commande pour un client Particulier ");
                    Console.WriteLine("3. Supprimer une Commande pour un client Particulier ");
                    Console.WriteLine("4. Lister les Commandes ");

                    Console.Write("Votre choix : ");
                    string choix_assemblage = Console.ReadLine();

                    if (choix_assemblage == "1"){
                        // Ajouter une Boutique
                        AjouterCommandeParticulier();

                    }else if (choix_assemblage == "2") {
                        // Modifier une Boutique
                        ModifierCommandeParticulier();

                    }else if (choix_assemblage == "3") {
                        SupprimerCommandeParticulier();

                    }else if (choix_assemblage == "4") {
                        PrintAllCommandesParticulier();
                    }   

                }
                else
                {
                    Console.WriteLine("Choix invalide !");
                }

                Console.WriteLine("Pour arrêter le programme tapez STOP sinon vous tapez Entrer pour recommencer !");
                x = Console.ReadLine();

            }
            
        }

        // Gestion Particuliers
        static void AjouterParticulier()
        {
            Console.WriteLine("===================== Ajout d'un particulier =============== \n");

            Console.Write("Entrez le nom : ");
            string nom = Console.ReadLine();

            Console.Write("Entrez le prénom : ");
            string prenom = Console.ReadLine();

            Console.Write("Entrez la rue : ");
            string rue = Console.ReadLine();

            Console.Write("Entrez la ville : ");
            string ville = Console.ReadLine();

            Console.Write("Entrez le code postal : ");
            int codePostal = int.Parse(Console.ReadLine());

            Console.Write("Entrez la province : ");
            string province = Console.ReadLine();

            Console.Write("Entrez le numéro de téléphone : ");
            string tel = Console.ReadLine();

            Console.Write("Entrez l'adresse e-mail : ");
            string courriel = Console.ReadLine();

            // Création d'une instance de Particulier avec les valeurs saisies
            Particulier particulier = new Particulier(nom, prenom, rue, ville, codePostal, province, tel, courriel);

            // Ajout du particulier à la base de données
            ParticulierService service = new ParticulierService();
            service.AjouterParticulier(particulier);

            Console.WriteLine(" ======================= Particulier ajouté avec succès ! ======================= \n");
        }

        static void ModifierParticulier()
        {
            // Demander l'ID du particulier à modifier
            Console.WriteLine("Entrez l'ID du particulier à modifier : ");
            int id_particulier = int.Parse(Console.ReadLine());

            Console.Write("Entrez le nom : ");
            string nom = Console.ReadLine();

            Console.Write("Entrez le prénom : ");
            string prenom = Console.ReadLine();

            Console.Write("Entrez la rue : ");
            string rue = Console.ReadLine();

            Console.Write("Entrez la ville : ");
            string ville = Console.ReadLine();

            Console.Write("Entrez le code postal : ");
            int codePostal = int.Parse(Console.ReadLine());

            Console.Write("Entrez la province : ");
            string province = Console.ReadLine();

            Console.Write("Entrez le numéro de téléphone : ");
            string tel = Console.ReadLine();

            Console.Write("Entrez l'adresse e-mail : ");
            string courriel = Console.ReadLine();

            // Création d'une instance de Particulier avec les valeurs saisies
            Particulier particulier = new Particulier(id_particulier, nom, prenom, rue, ville, codePostal, province, tel, courriel);

            // Modifier le particulier dans la base de données
            ParticulierService service = new ParticulierService();
            service.ModifierParticulier(particulier);

            Console.WriteLine(" =========================== Particulier modifié avec succès ! =========================== \n");
        }

        static void SupprimerParticulier()
        {
            Console.WriteLine("Entrez l'ID du particulier à supprimer : ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Veuillez entrer un ID valide (nombre entier) : ");
            }

            ParticulierService service = new ParticulierService();
            Particulier par = service.GetParticulierById(id);
            service.SupprimerParticulier(par);

            Console.WriteLine("Particulier supprimé avec succès !");
        }

        static void PrintAllParticuliers(){
            ParticulierService service = new ParticulierService();
            service.PrintAllParticuliers();
        }

        
        // Gestion Boutiques
        static void AjouterBoutique()
        {
            Console.WriteLine("======================= Ajout d'une boutique ======================= \n");
            Console.Write("Entrez le nom : ");
            string nom = Console.ReadLine();

            Console.Write("Entrez la rue : ");
            string rue = Console.ReadLine();

            Console.Write("Entrez la ville : ");
            string ville = Console.ReadLine();

            Console.Write("Entrez le code postal : ");
            int codePostal = int.Parse(Console.ReadLine());

            Console.Write("Entrez la province : ");
            string province = Console.ReadLine();

            Console.Write("Entrez le numéro de téléphone : ");
            string tel = Console.ReadLine();

            Console.Write("Entrez l'adresse e-mail : ");
            string courriel = Console.ReadLine();

            Console.Write("Entrez le nom de la personne de contact : ");
            string personneContact = Console.ReadLine();

            // Création d'une instance de Boutique avec les valeurs saisies
            Boutique boutique = new Boutique(nom, rue, ville, codePostal, province, tel, courriel, personneContact);

            // Ajout de la boutique à la base de données
            BoutiqueService service = new BoutiqueService();
            service.AjouterBoutique(boutique);

            Console.WriteLine("Boutique ajoutée avec succès !");
        }

        static void SupprimerBoutique()
        {
            Console.WriteLine("Entrez l'ID de la boutique à supprimer : ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Veuillez entrer un ID valide (nombre entier) : ");
            }

            BoutiqueService service = new BoutiqueService();
            Boutique boutique = service.GetBoutiqueById(id);
            if (boutique != null)
            {
                service.SupprimerBoutique(boutique);
                Console.WriteLine("Boutique supprimée avec succès !");
            }
            else
            {
                Console.WriteLine("Aucune boutique trouvée avec cet ID.");
            }
        }

        static void PrintAllBoutiques(){
            BoutiqueService service = new BoutiqueService();
            service.PrintAllBoutiques();
        }
    
        static void ModifierBoutique()
        {
            // Demander l'ID de la boutique à modifier
            Console.WriteLine("Entrez l'ID de la boutique à modifier : ");
            int id_boutique = int.Parse(Console.ReadLine());

            Console.Write("Entrez le nom : ");
            string nom = Console.ReadLine();

            Console.Write("Entrez la rue : ");
            string rue = Console.ReadLine();

            Console.Write("Entrez la ville : ");
            string ville = Console.ReadLine();

            Console.Write("Entrez le code postal : ");
            int codePostal = int.Parse(Console.ReadLine());

            Console.Write("Entrez la province : ");
            string province = Console.ReadLine();

            Console.Write("Entrez le numéro de téléphone : ");
            string tel = Console.ReadLine();

            Console.Write("Entrez l'adresse e-mail : ");
            string courriel = Console.ReadLine();

            Console.Write("Entrez le nom de la personne de contact : ");
            string personneContact = Console.ReadLine();

            // Création d'une instance de Boutique avec les valeurs saisies
            Boutique boutique = new Boutique(id_boutique, nom, rue, ville, codePostal, province, tel, courriel, personneContact);

            // Modifier la boutique dans la base de données
            BoutiqueService service = new BoutiqueService();
            service.ModifierBoutique(boutique);

            Console.WriteLine(" =========================== Boutique modifiée avec succès ! =========================== \n");
        }

        // Gestion Fournisseurs
        static void AjouterFournisseur()
        {
            Console.WriteLine("======================= Ajout d'un fournisseur ======================= \n");
            Console.Write("Entrez le numéro SIRET : ");
            int siret = int.Parse(Console.ReadLine());

            Console.Write("Entrez le nom de l'entreprise : ");
            string nomEntreprise = Console.ReadLine();

            Console.Write("Entrez le contact : ");
            string contact = Console.ReadLine();

            Console.Write("Entrez l'adresse : ");
            string adresse = Console.ReadLine();

            Console.Write("Entrez le statut : ");
            int statut = int.Parse(Console.ReadLine());

            // Création d'une instance de Fournisseur avec les valeurs saisies
            Fournisseur fournisseur = new Fournisseur(siret, nomEntreprise, contact, adresse, statut);

            // Ajout du fournisseur à la base de données
            FournisseurService service = new FournisseurService();
            service.AjouterFournisseur(fournisseur);

            Console.WriteLine("Fournisseur ajouté avec succès !");
        }

        static void SupprimerFournisseur()
        {
            Console.WriteLine("Entrez le numéro SIRET du fournisseur à supprimer : ");
            int siret;
            while (!int.TryParse(Console.ReadLine(), out siret))
            {
                Console.WriteLine("Veuillez entrer un numéro SIRET valide (nombre entier) : ");
            }

            FournisseurService service = new FournisseurService();
            Fournisseur fournisseur = service.GetFournisseurBySiret(siret);
            if (fournisseur != null)
            {
                service.SupprimerFournisseur(fournisseur);
                Console.WriteLine("Fournisseur supprimé avec succès !");
            }
            else
            {
                Console.WriteLine("Aucun fournisseur trouvé avec ce numéro SIRET.");
            }
        }

        static void PrintAllFournisseurs()
        {
            FournisseurService service = new FournisseurService();
            service.PrintAllFournisseurs();
        }

        static void ModifierFournisseur()
        {
            // Demander le numéro SIRET du fournisseur à modifier
            Console.WriteLine("Entrez le numéro SIRET du fournisseur à modifier : ");
            int siret = int.Parse(Console.ReadLine());

            Console.Write("Entrez le nom de l'entreprise : ");
            string nomEntreprise = Console.ReadLine();

            Console.Write("Entrez le contact : ");
            string contact = Console.ReadLine();

            Console.Write("Entrez l'adresse : ");
            string adresse = Console.ReadLine();

            Console.Write("Entrez le statut : ");
            int statut = int.Parse(Console.ReadLine());

            // Création d'une instance de Fournisseur avec les valeurs saisies
            Fournisseur fournisseur = new Fournisseur(siret, nomEntreprise, contact, adresse, statut);

            // Modifier le fournisseur dans la base de données
            FournisseurService service = new FournisseurService();
            service.ModifierFournisseur(fournisseur);

            Console.WriteLine(" =========================== Fournisseur modifié avec succès ! =========================== \n");

        }

        
        // Gestion Fidelio
        static void AjouterFidelio()
    {
        Console.WriteLine("======================= Ajout d'un enregistrement Fidelio ======================= \n");
        Console.Write("Entrez la description : ");
        string description = Console.ReadLine();
        
        Console.Write("Entrez le coût : ");
        decimal cout;
        while (!decimal.TryParse(Console.ReadLine(), out cout))
        {
            Console.WriteLine("Veuillez entrer un coût valide : ");
        }

        Console.Write("Entrez la durée : ");
        string duree = Console.ReadLine();

        Console.Write("Entrez le rabais (%) : ");
        int rabais;
        while (!int.TryParse(Console.ReadLine(), out rabais))
        {
            Console.WriteLine("Veuillez entrer un rabais valide : ");
        }

        // Code pour ajouter un enregistrement Fidelio
        FidelioService service = new FidelioService();
        Fidelio fidelio = new Fidelio(description, cout, duree, rabais);
        service.AjouterFidelio(fidelio);
        Console.WriteLine("Enregistrement Fidelio ajouté avec succès !");
    }

        static void ModifierFidelio()
        {
            Console.WriteLine("======================= Modification d'un enregistrement Fidelio ======================= \n");
            Console.Write("Entrez l'ID de l'enregistrement Fidelio à modifier : ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Veuillez entrer un ID valide : ");
            }

            Console.Write("Entrez la nouvelle description : ");
            string description = Console.ReadLine();
            
            Console.Write("Entrez le nouveau coût : ");
            decimal cout;
            while (!decimal.TryParse(Console.ReadLine(), out cout))
            {
                Console.WriteLine("Veuillez entrer un coût valide : ");
            }

            Console.Write("Entrez la nouvelle durée : ");
            string duree = Console.ReadLine();

            Console.Write("Entrez le nouveau rabais (%) : ");
            int rabais;
            while (!int.TryParse(Console.ReadLine(), out rabais))
            {
                Console.WriteLine("Veuillez entrer un rabais valide : ");
            }

            // Code pour modifier un enregistrement Fidelio
            FidelioService service = new FidelioService();
            Fidelio fidelio = service.GetFidelioById(id);
            if (fidelio != null)
            {
                fidelio.Description = description;
                fidelio.Cout = cout;
                fidelio.Duree = duree;
                fidelio.Rabais = rabais;
                service.ModifierFidelio(fidelio);
                Console.WriteLine("Enregistrement Fidelio modifié avec succès !");
            }
            else
            {
                Console.WriteLine("Aucun enregistrement Fidelio trouvé avec cet ID.");
            }
        }

        static void SupprimerFidelio()
        {
            Console.WriteLine("======================= Suppression d'un enregistrement Fidelio ======================= \n");
            Console.Write("Entrez l'ID de l'enregistrement Fidelio à supprimer : ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Veuillez entrer un ID valide : ");
            }

            // Code pour supprimer un enregistrement Fidelio
            FidelioService service = new FidelioService();
            Fidelio fidelio = service.GetFidelioById(id);
            if (fidelio != null)
            {
                service.SupprimerFidelio(fidelio);
                Console.WriteLine("Enregistrement Fidelio supprimé avec succès !");
            }
            else
            {
                Console.WriteLine("Aucun enregistrement Fidelio trouvé avec cet ID.");
            }
        }

        static void PrintAllFidelio()
        {
            Console.WriteLine("======================= Affichage de tous les enregistrements Fidelio ======================= \n");
            // Code pour afficher tous les enregistrements de Fidelio
            FidelioService service = new FidelioService();
            service.PrintAllFidelio();
        }

        static void PrintAllClientFidelio()
        {
            Console.WriteLine("======================= Affichage de tous les Client inscis à un programmes Fidelio ======================= \n");
            // Code pour afficher tous les enregistrements de Fidelio
            FidelioService service = new FidelioService();
            service.PrintAllClientFidelio();
        }

        // Méthode pour insérer une nouvelle entrée dans la table Client_Fidelio
        static void AffecterClientAFidelio()
        {
            PrintAllParticuliers();
            Console.WriteLine("\n");
            PrintAllFidelio();
            // Demander à l'utilisateur les ID du client particulier et du programme Fidelio
            Console.WriteLine("Entrez l'ID du client particulier : ");
            int idClient = int.Parse(Console.ReadLine());

            Console.WriteLine("Entrez l'ID du programme Fidelio : ");
            int idFidelio = int.Parse(Console.ReadLine());

            // Demander à l'utilisateur la date d'adhésion
            Console.WriteLine("Entrez la date d'adhésion au format YYYY-MM-DD : ");
            DateTime dateAdhesion = DateTime.Parse(Console.ReadLine());
            try
            {
                string _connectionString = "server=localhost;userid=root;password=;database=VeloMax";
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Client_Fidelio (id_client, id_fidelio, date_adhesion) VALUES (@IdClient, @IdFidelio, @DateAdhesion)";
                    
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdClient", idClient);
                    command.Parameters.AddWithValue("@IdFidelio", idFidelio);
                    command.Parameters.AddWithValue("@DateAdhesion", dateAdhesion);

                    command.ExecuteNonQuery();

                    Console.WriteLine("Client affecté au programme Fidelio avec succès !");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'affectation du client au programme Fidelio : " + ex.Message);
            }
        }   


        // Géstion des Assemblages et modèles
        static void AjouterAssemblage()
        {
            Console.WriteLine("===================== Ajout d'un assemblage =============== \n");

            Console.Write("Entrez le nom : ");
            string nom = Console.ReadLine();

            Console.Write("Entrez la grandeur : ");
            string grandeur = Console.ReadLine();

            Console.Write("Entrez le cadre : ");
            string cadre = Console.ReadLine();

            Console.Write("Entrez le guidon : ");
            string guidon = Console.ReadLine();

            Console.Write("Entrez les freins : ");
            string freins = Console.ReadLine();

            Console.Write("Entrez la selle : ");
            string selle = Console.ReadLine();

            Console.Write("Entrez le dérailleur avant : ");
            string derAvant = Console.ReadLine();

            Console.Write("Entrez le dérailleur arrière : ");
            string derArriere = Console.ReadLine();

            Console.Write("Entrez la roue avant : ");
            string roueAvant = Console.ReadLine();

            Console.Write("Entrez la roue arrière : ");
            string roueArriere = Console.ReadLine();

            Console.Write("Entrez les réflecteurs : ");
            string reflecteurs = Console.ReadLine();

            Console.Write("Entrez le pédalier : ");
            string pedalier = Console.ReadLine();

            Console.Write("Entrez l'ordinateur : ");
            string ordinateur = Console.ReadLine();

            Console.Write("Entrez le panier : ");
            string panier = Console.ReadLine();

            // Créez une instance de Assemblage avec les valeurs saisies
            Assemblage assemblage = new Assemblage(nom, grandeur, cadre, guidon, freins, selle, derAvant, derArriere, roueAvant, roueArriere, reflecteurs, pedalier, ordinateur, panier);

            // Ajoutez l'assemblage à la base de données
            AssemblageService service = new AssemblageService();
            service.AjouterAssemblage(assemblage);

            Console.WriteLine(" ======================= Assemblage ajouté avec succès ! ======================= \n");
        }

        static void ModifierAssemblage()
        {
            // Demandez ici l'identifiant de l'assemblage à modifier
            Console.WriteLine("Entrez l'ID de l'assemblage à modifier : ");
            int idAssemblage = int.Parse(Console.ReadLine());

            // Demandez ici les nouvelles valeurs pour l'assemblage
            Console.Write("Entrez le nouveau nom : ");
            string nom = Console.ReadLine();

            Console.Write("Entrez la nouvelle grandeur : ");
            string grandeur = Console.ReadLine();

            Console.Write("Entrez le nouveau cadre : ");
            string cadre = Console.ReadLine();

            Console.Write("Entrez le nouveau guidon : ");
            string guidon = Console.ReadLine();

            Console.Write("Entrez les nouveaux freins : ");
            string freins = Console.ReadLine();

            Console.Write("Entrez la nouvelle selle : ");
            string selle = Console.ReadLine();

            Console.Write("Entrez le nouveau dérailleur avant : ");
            string derAvant = Console.ReadLine();

            Console.Write("Entrez le nouveau dérailleur arrière : ");
            string derArriere = Console.ReadLine();

            Console.Write("Entrez la nouvelle roue avant : ");
            string roueAvant = Console.ReadLine();

            Console.Write("Entrez la nouvelle roue arrière : ");
            string roueArriere = Console.ReadLine();

            Console.Write("Entrez les nouveaux réflecteurs : ");
            string reflecteurs = Console.ReadLine();

            Console.Write("Entrez le nouveau pédalier : ");
            string pedalier = Console.ReadLine();

            Console.Write("Entrez le nouvel ordinateur : ");
            string ordinateur = Console.ReadLine();

            Console.Write("Entrez le nouveau panier : ");
            string panier = Console.ReadLine();

            // Créez une instance de Assemblage avec les nouvelles valeurs
            Assemblage assemblage = new Assemblage(idAssemblage, nom, grandeur, cadre, guidon, freins, selle, derAvant, derArriere, roueAvant, roueArriere, reflecteurs, pedalier, ordinateur, panier);

            // Modifiez l'assemblage dans la base de données
            AssemblageService service = new AssemblageService();
            service.ModifierAssemblage(assemblage);

            Console.WriteLine(" ======================= Assemblage modifié avec succès ! ======================= \n");
        }

        static void SupprimerAssemblage()
        {
            Console.WriteLine("======================= Suppression d'un assemblage ======================= \n");
            Console.Write("Entrez l'ID de l'assemblage à supprimer : ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Veuillez entrer un ID valide : ");
            }

            // Code pour supprimer un assemblage
            AssemblageService service = new AssemblageService();
            Assemblage assemblage = service.GetAssemblageById(id);
            if (assemblage != null)
            {
                service.SupprimerAssemblage(assemblage);
                Console.WriteLine("Assemblage supprimé avec succès !");
            }
            else
            {
                Console.WriteLine("Aucun assemblage trouvé avec cet ID.");
            }
        }

        static void PrintAllAssemblages()
        {
            // Affichez tous les assemblages
            AssemblageService service = new AssemblageService();
            service.PrintAllAssemblages();
        }

        // Gestion des commandes

        static void AjouterCommandeParticulier()
        {
            Console.WriteLine("===================== Ajout d'une commande particulier ======================= \n");

            // Demander les informations nécessaires pour la commande particulier
            Console.Write("Entrez l'ID du particulier : ");
            int idParticulier = int.Parse(Console.ReadLine());

            Console.Write("Entrez l'ID du vélo : ");
            int idVelo = int.Parse(Console.ReadLine());

            // La date de commande est automatiquement définie sur la date actuelle
            DateTime dateCommande = DateTime.Now;

            Console.Write("Entrez l'adresse de livraison : ");
            string adresseLivraison = Console.ReadLine();

            Console.Write("Entrez la date de livraison : ");
            DateTime dateLivraison = DateTime.Parse(Console.ReadLine());

            Console.Write("Entrez la quantité : ");
            int quantite = int.Parse(Console.ReadLine());

            // Créer une instance de CommandeParticulier avec les valeurs saisies
            CommandeParticulier commandeParticulier = new CommandeParticulier(idParticulier, idVelo, dateCommande, adresseLivraison, dateLivraison, quantite);

            // Ajouter la commande particulier à la base de données
            CommandeParticulierService service = new CommandeParticulierService();
            service.AjouterCommandeParticulier(commandeParticulier);

            Console.WriteLine(" ======================= Commande particulier ajoutée avec succès ! ======================= \n");
        }

        static void ModifierCommandeParticulier()
        {
            Console.WriteLine("======================= Modification d'une commande particulier ======================= \n");

            // Demander l'ID de la commande particulier à modifier
            Console.Write("Entrez l'ID de la commande particulier à modifier : ");
            int idCommandeParticulier = int.Parse(Console.ReadLine());

            // Demander les nouvelles valeurs pour la commande particulier
            Console.Write("Entrez l'ID du particulier : ");
            int idParticulier = int.Parse(Console.ReadLine());

            Console.Write("Entrez l'ID du vélo : ");
            int idVelo = int.Parse(Console.ReadLine());

            // La date de commande est automatiquement définie sur la date actuelle
            DateTime dateCommande = DateTime.Now;

            Console.Write("Entrez la date de livraison : ");
            DateTime dateLivraison = DateTime.Parse(Console.ReadLine());

            Console.Write("Entrez l'adresse de livraison : ");
            string adresseLivraison = Console.ReadLine();

            Console.Write("Entrez la quantité : ");
            int quantite = int.Parse(Console.ReadLine());

            // Créer une instance de CommandeParticulier avec les nouvelles valeurs
            CommandeParticulier commandeParticulier = new CommandeParticulier(idCommandeParticulier, idParticulier, idVelo, dateCommande, adresseLivraison, dateLivraison, quantite);

            // Modifier la commande particulier dans la base de données
            CommandeParticulierService service = new CommandeParticulierService();
            service.ModifierCommandeParticulier(commandeParticulier);

            Console.WriteLine(" ======================= Commande particulier modifiée avec succès ! ======================= \n");
        }

        static void SupprimerCommandeParticulier()
        {
            Console.WriteLine("======================= Suppression d'une commande particulier ======================= \n");
            Console.Write("Entrez l'ID de la commande particulier à supprimer : ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Veuillez entrer un ID valide : ");
            }

            // Code pour supprimer une commande particulier
            CommandeParticulierService service = new CommandeParticulierService();
            CommandeParticulier commandeParticulier = service.GetCommandeParticulierById(id);
            if (commandeParticulier != null)
            {
                service.SupprimerCommandeParticulier(commandeParticulier);
                Console.WriteLine("Commande particulier supprimée avec succès !");
            }
            else
            {
                Console.WriteLine("Aucune commande particulier trouvée avec cet ID.");
            }
        }


        static void PrintAllCommandesParticulier()
        {
            CommandeParticulierService service = new CommandeParticulierService();
            service.PrintAllCommandesParticuliers();
        }


    }
}
