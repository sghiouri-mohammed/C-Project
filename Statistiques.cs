using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace VotreNamespace
{
    public class Statistiques
    {
        private readonly string _connectionString;

        public Statistiques(string connectionString)
        {
            _connectionString = "server=localhost;userid=root;password=;database=VeloMax";
        }

        // Nombre de clients
        public int GetNombreClients()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Client;";
                MySqlCommand command = new MySqlCommand(query, connection);
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        // Noms des clients avec le cumul de toutes ses commandes en euros
        public Dictionary<string, decimal> GetCumulCommandesClients()
        {
            Dictionary<string, decimal> result = new Dictionary<string, decimal>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT Client.nom AS NomClient, SUM(Commande.total) AS TotalCommandes FROM Commande JOIN Client ON Commande.id_client = Client.id GROUP BY Client.nom;";
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString("NomClient"), reader.GetDecimal("TotalCommandes"));
                    }
                }
            }
            return result;
        }

        // Liste des produits ayant une quantité en stock <= 2
        public List<string> GetProduitsFaibleStock()
        {
            List<string> result = new List<string>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT nom FROM Produit WHERE quantite <= 2;";
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString("nom"));
                    }
                }
            }
            return result;
        }

        // Nombres de pièces et/ou vélos fournis par fournisseur
        public Dictionary<string, int> GetNombrePiecesVehiculesFournisseur()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT Fournisseur.nom_entreprise, COUNT(Fourniture.id_piece) AS NombrePieces FROM Fournisseur JOIN Fourniture ON Fournisseur.siret = Fourniture.siret_fournisseur GROUP BY Fournisseur.nom_entreprise;";
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString("nom_entreprise"), reader.GetInt32("NombrePieces"));
                    }
                }
            }
            return result;
        }

        // Le chiffre d’affaires par magasin et les ventes générées par vendeur
        public void GetChiffreAffairesParMagasinEtVendeur(out Dictionary<string, decimal> chiffreAffairesMagasin, out Dictionary<string, decimal> chiffreAffairesVendeur)
        {
            chiffreAffairesMagasin = new Dictionary<string, decimal>();
            chiffreAffairesVendeur = new Dictionary<string, decimal>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT Magasin.nom AS NomMagasin, SUM(Commande.total) AS TotalCommandes FROM Commande JOIN Magasin ON Commande.id_magasin = Magasin.id GROUP BY Magasin.nom;";
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        chiffreAffairesMagasin.Add(reader.GetString("NomMagasin"), reader.GetDecimal("TotalCommandes"));
                    }
                }

                query = "SELECT Vendeur.nom AS NomVendeur, SUM(Commande.total) AS TotalVentes FROM Commande JOIN Vendeur ON Commande.id_vendeur = Vendeur.id GROUP BY Vendeur.nom;";
                command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        chiffreAffairesVendeur.Add(reader.GetString("NomVendeur"), reader.GetDecimal("TotalVentes"));
                    }
                }
            }
        }
    }
}
