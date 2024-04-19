using System;
using MySql.Data.MySqlClient;

namespace VeloMax.Models
{
    public class CommandeParticulier
    {
        public int IdCommande { get; set; }
        public int IdParticulier { get; set; }
        public int IdVelo { get; set; }
        public DateTime DateCommande { get; set; }
        public string AdresseLivraison { get; set; }
        public DateTime DateLivraison { get; set; }
        public int Quantite { get; set; }

        public CommandeParticulier() 
        { 

        }

        public CommandeParticulier(int idParticulier, int idVelo, DateTime dateCommande, string adresseLivraison, DateTime dateLivraison, int quantite)
        {
            IdParticulier = idParticulier;
            IdVelo = idVelo;
            DateCommande = dateCommande;
            AdresseLivraison = adresseLivraison;
            DateLivraison = dateLivraison;
            Quantite = quantite;
        }

        public CommandeParticulier(int idCommande, int idParticulier, int idVelo, DateTime dateCommande, string adresseLivraison, DateTime dateLivraison, int quantite)
        {
            IdCommande = idCommande;
            IdParticulier = idParticulier;
            IdVelo = idVelo;
            DateCommande = dateCommande;
            AdresseLivraison = adresseLivraison;
            DateLivraison = dateLivraison;
            Quantite = quantite;
        }

        public void AjouterCommandeParticulier(MySqlConnection connection)
        {
            DateTime dateCommande = DateTime.Now;
            
            string query = "INSERT INTO Commande_Particuliers (id_particulier, id_velo, date_commande, adresse_livraison, date_livraison, quantite) " +
                           "VALUES (@IdParticulier, @IdVelo, @DateCommande, @AdresseLivraison, @DateLivraison, @Quantite)";

            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@IdParticulier", IdParticulier);
            command.Parameters.AddWithValue("@IdVelo", IdVelo);
            command.Parameters.AddWithValue("@DateCommande", DateCommande);
            command.Parameters.AddWithValue("@AdresseLivraison", AdresseLivraison);
            command.Parameters.AddWithValue("@DateLivraison", DateLivraison);
            command.Parameters.AddWithValue("@Quantite", Quantite);

            command.ExecuteNonQuery();
        }

        public void ModifierCommandeParticulier(MySqlConnection connection)
        {
            string query = "UPDATE Commande_Particuliers SET id_particulier = @IdParticulier, id_velo = @IdVelo, date_commande = @DateCommande, " +
                           "adresse_livraison = @AdresseLivraison, date_livraison = @DateLivraison, quantite = @Quantite " +
                           "WHERE id_commande = @IdCommande";

            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@IdParticulier", IdParticulier);
            command.Parameters.AddWithValue("@IdVelo", IdVelo);
            command.Parameters.AddWithValue("@DateCommande", DateCommande);
            command.Parameters.AddWithValue("@AdresseLivraison", AdresseLivraison);
            command.Parameters.AddWithValue("@DateLivraison", DateLivraison);
            command.Parameters.AddWithValue("@Quantite", Quantite);
            command.Parameters.AddWithValue("@IdCommande", IdCommande);

            command.ExecuteNonQuery();
        }

        public void SupprimerCommandeParticulier(MySqlConnection connection)
        {
            string query = "DELETE FROM Commande_Particuliers WHERE id_commande = @IdCommande";

            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@IdCommande", IdCommande);

            command.ExecuteNonQuery();
        }


    }
}
