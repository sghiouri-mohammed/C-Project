using System;
using MySql.Data.MySqlClient;

namespace VeloMax.Models
{
    public class Velo
    {
        public int Numero { get; set; }
        public string Nom { get; set; }
        public string Grandeur { get; set; }
        public decimal PrixUnitaire { get; set; }
        public string LigneProduit { get; set; }
        public DateTime DateIntroduction { get; set; }
        public DateTime DateDiscontinuation { get; set; }
        // Constructeur par défaut
        public Velo() { }

        // Constructeur avec paramètres
        public Velo(string nom, string grandeur, decimal prixUnitaire, string ligneProduit, DateTime dateIntroduction, DateTime dateDiscontinuation, string piece)
        {
            Nom = nom;
            Grandeur = grandeur;
            PrixUnitaire = prixUnitaire;
            LigneProduit = ligneProduit;
            DateIntroduction = dateIntroduction;
            DateDiscontinuation = dateDiscontinuation;
        }

        // Méthodes CRUD
        // Ajouter un nouveau vélo à la base de données
        public void AjouterVelo(MySqlConnection connection)
        {
            string query = "INSERT INTO Velo(nom, grandeur, prix_unitaire, ligne_produit, date_intro, date_disc, piece) VALUES(@Nom, @Grandeur, @PrixUnitaire, @LigneProduit, @DateIntroduction, @DateDiscontinuation, @Piece)";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Nom", Nom);
            command.Parameters.AddWithValue("@Grandeur", Grandeur);
            command.Parameters.AddWithValue("@PrixUnitaire", PrixUnitaire);
            command.Parameters.AddWithValue("@LigneProduit", LigneProduit);
            command.Parameters.AddWithValue("@DateIntroduction", DateIntroduction);
            command.Parameters.AddWithValue("@DateDiscontinuation", DateDiscontinuation);

            command.ExecuteNonQuery();
        }

        // Modifier un vélo existant dans la base de données
        public void ModifierVelo(MySqlConnection connection)
        {
            string query = "UPDATE Velo SET nom = @Nom, grandeur = @Grandeur, prix_unitaire = @PrixUnitaire, ligne_produit = @LigneProduit, date_intro = @DateIntroduction, date_disc = @DateDiscontinuation, piece = @Piece WHERE numero = @Numero";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Numero", Numero);
            command.Parameters.AddWithValue("@Nom", Nom);
            command.Parameters.AddWithValue("@Grandeur", Grandeur);
            command.Parameters.AddWithValue("@PrixUnitaire", PrixUnitaire);
            command.Parameters.AddWithValue("@LigneProduit", LigneProduit);
            command.Parameters.AddWithValue("@DateIntroduction", DateIntroduction);
            command.Parameters.AddWithValue("@DateDiscontinuation", DateDiscontinuation);

            command.ExecuteNonQuery();
        }

        // Supprimer un vélo de la base de données
        public void SupprimerVelo(MySqlConnection connection)
        {
            string query = "DELETE FROM Velo WHERE numero = @Numero";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Numero", Numero);

            command.ExecuteNonQuery();
        }
    }
}
