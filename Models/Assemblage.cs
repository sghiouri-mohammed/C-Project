using System;
using MySql.Data.MySqlClient;

namespace VeloMax.Models
{
    public class Assemblage
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Grandeur { get; set; }
        public string Cadre { get; set; }
        public string Guidon { get; set; }
        public string Freins { get; set; }
        public string Selle { get; set; }
        public string DerailleurAvant { get; set; }
        public string DerailleurArriere { get; set; }
        public string RoueAvant { get; set; }
        public string RoueArriere { get; set; }
        public string Reflecteurs { get; set; }
        public string Pedalier { get; set; }
        public string Ordinateur { get; set; }
        public string Panier { get; set; }

        // Constructeur par défaut
        public Assemblage() 
        { 

        }

        // Constructeur avec paramètres
        public Assemblage(string nom, string grandeur, string cadre, string guidon, string freins, string selle, string derailleurAvant, string derailleurArriere, string roueAvant, string roueArriere, string reflecteurs, string pedalier, string ordinateur, string panier)
        {
            Nom = nom;
            Grandeur = grandeur;
            Cadre = cadre;
            Guidon = guidon;
            Freins = freins;
            Selle = selle;
            DerailleurAvant = derailleurAvant;
            DerailleurArriere = derailleurArriere;
            RoueAvant = roueAvant;
            RoueArriere = roueArriere;
            Reflecteurs = reflecteurs;
            Pedalier = pedalier;
            Ordinateur = ordinateur;
            Panier = panier;
        }

        public Assemblage(int id, string nom, string grandeur, string cadre, string guidon, string freins, string selle, string derailleurAvant, string derailleurArriere, string roueAvant, string roueArriere, string reflecteurs, string pedalier, string ordinateur, string panier)
        {
            Id = id;
            Nom = nom;
            Grandeur = grandeur;
            Cadre = cadre;
            Guidon = guidon;
            Freins = freins;
            Selle = selle;
            DerailleurAvant = derailleurAvant;
            DerailleurArriere = derailleurArriere;
            RoueAvant = roueAvant;
            RoueArriere = roueArriere;
            Reflecteurs = reflecteurs;
            Pedalier = pedalier;
            Ordinateur = ordinateur;
            Panier = panier;
        }

        // Méthode pour ajouter un nouvel assemblage à la base de données
        public void AjouterAssemblage(MySqlConnection connection)
        {
            string query = "INSERT INTO Assemblage(Nom, Grandeur, Cadre, Guidon, Freins, Selle, Dérailleur_Avant, Dérailleur_Arrière, Roue_avant, Roue_arrière, Réflecteurs, Pédalier, Ordinateur, Panier) VALUES (@Nom, @Grandeur, @Cadre, @Guidon, @Freins, @Selle, @DerailleurAvant, @DerailleurArriere, @RoueAvant, @RoueArriere, @Reflecteurs, @Pedalier, @Ordinateur, @Panier)";

            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@Nom", Nom);
            command.Parameters.AddWithValue("@Grandeur", Grandeur);
            command.Parameters.AddWithValue("@Cadre", Cadre);
            command.Parameters.AddWithValue("@Guidon", Guidon);
            command.Parameters.AddWithValue("@Freins", Freins);
            command.Parameters.AddWithValue("@Selle", Selle);
            command.Parameters.AddWithValue("@DerailleurAvant", DerailleurAvant);
            command.Parameters.AddWithValue("@DerailleurArriere", DerailleurArriere);
            command.Parameters.AddWithValue("@RoueAvant", RoueAvant);
            command.Parameters.AddWithValue("@RoueArriere", RoueArriere);
            command.Parameters.AddWithValue("@Reflecteurs", Reflecteurs);
            command.Parameters.AddWithValue("@Pedalier", Pedalier);
            command.Parameters.AddWithValue("@Ordinateur", Ordinateur);
            command.Parameters.AddWithValue("@Panier", Panier);

            command.ExecuteNonQuery();
        }

        // Méthode pour modifier un assemblage existant dans la base de données
        public void ModifierAssemblage(MySqlConnection connection)
        {
            string query = "UPDATE Assemblage SET nom = @Nom, grandeur = @Grandeur, cadre = @Cadre, guidon = @Guidon, freins = @Freins, selle = @Selle, derailleur_avant = @DerailleurAvant, derailleur_arriere = @DerailleurArriere, roue_avant = @RoueAvant, roue_arriere = @RoueArriere, reflecteurs = @Reflecteurs, pedalier = @Pedalier, ordinateur = @Ordinateur, panier = @Panier WHERE id = @Id";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@Nom", Nom);
            command.Parameters.AddWithValue("@Grandeur", Grandeur);
            command.Parameters.AddWithValue("@Cadre", Cadre);
            command.Parameters.AddWithValue("@Guidon", Guidon);
            command.Parameters.AddWithValue("@Freins", Freins);
            command.Parameters.AddWithValue("@Selle", Selle);
            command.Parameters.AddWithValue("@DerailleurAvant", DerailleurAvant);
            command.Parameters.AddWithValue("@DerailleurArriere", DerailleurArriere);
            command.Parameters.AddWithValue("@RoueAvant", RoueAvant);
            command.Parameters.AddWithValue("@RoueArriere", RoueArriere);
            command.Parameters.AddWithValue("@Reflecteurs", Reflecteurs);
            command.Parameters.AddWithValue("@Pedalier", Pedalier);
            command.Parameters.AddWithValue("@Ordinateur", Ordinateur);
            command.Parameters.AddWithValue("@Panier", Panier);

            command.ExecuteNonQuery();
        }

        // Méthode pour supprimer un assemblage de la base de données
        public void SupprimerAssemblage(MySqlConnection connection)
        {
            string query = "DELETE FROM Assemblage WHERE id = @Id";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", Id);

            command.ExecuteNonQuery();
        }
    }
}
