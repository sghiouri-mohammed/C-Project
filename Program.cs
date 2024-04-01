using System;
using Org.BouncyCastle.Math.EC.Rfc7748;
using VeloMax.Models;
using VeloMax.Services;

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
                Console.WriteLine("Bonjour Monsieur  Legrand !");
                Console.WriteLine("Que souhaitez-vous faire ? ");
                Console.WriteLine("1. Gérer Les Clients Particulier ");
                Console.WriteLine("2. Gérer Les Boutiques ");
                Console.WriteLine("3. Gérer Les Fournisseurs ");
                Console.WriteLine("4. Voir les Statistiques du Magasin ");

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
                    Console.WriteLine("Que souhaitez-vous faire ? ");
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

                    Console.WriteLine("Que souhaitez-vous savoir ? ");
                    Console.WriteLine("1. Stock par Magasin ");
                    Console.WriteLine("2. Stock par Pièce ");
                    Console.WriteLine("3. Stock par Fournisseur ");
                    Console.WriteLine("4. Stock par vélo ");
                    Console.WriteLine("5. Quantité vendues pour chaque Item ");
                    Console.WriteLine("6. La liste des membres pour chaque programme d’adhésion ");
                    Console.WriteLine("7. Affichez également la date d’expiration des adhésions ");
                    Console.WriteLine("8. Moyenne des montants des commandes ");
                    Console.WriteLine("9. Moyenne du nombre de pièces par commande ");
                    Console.WriteLine("10. Moyenne du nombre de vélos par commande ");
                    Console.WriteLine("11. Calcul des bonus des salariés en fonction de la satisfaction client  ");
                    Console.WriteLine("12. Calcul du bonus moyen ");
                    Console.WriteLine("13. Liste des produits ayant une quantité en stock <= 2 ");
                    
                    Console.Write("Votre choix : ");
                    string choix_fournisseur = Console.ReadLine();
                    
                }else
                {
                    Console.WriteLine("Choix invalide !");
                }

                Console.WriteLine("Pour arrêter le programme tapez STOP sinon vous tapez Entrer pour recommencer !");
                x = Console.ReadLine();

            }
            
        }

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
    }
}
