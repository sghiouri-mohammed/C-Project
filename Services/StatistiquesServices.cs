using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace VeloMax.Services
{
    public class StatistiqueService
    {
        private readonly string _connectionString;

        public StatistiqueService()
        {
            _connectionString =  _connectionString = "server=localhost;userid=root;password=;database=VeloMax";;
        }

        // Méthode pour obtenir le stock par Velo
        public void StockParVelo()
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT v.numero, v.modele_ref, SUM(s.en_stock) AS stock " +
                           "FROM Velo v " +
                           "LEFT JOIN Stock s ON v.numero = s.id_velo " +
                           "GROUP BY v.numero, v.modele_ref";

            MySqlCommand command = new MySqlCommand(query, connection);
            Console.WriteLine($" + ------------------------------------------------------------------------------------------------- + ");


            using MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int numero = reader.GetInt32("numero");
                int modele = reader.GetInt32("modele_ref");
                int stock = reader.GetInt32("stock");
                Console.WriteLine($"Velo {numero} ({modele}) : Stock = {stock}");
            }
            Console.WriteLine($" + ------------------------------------------------------------------------------------------------- + ");
        }

        // Méthode pour obtenir le nombre de fournisseurs
        public void NombreFournisseurs()
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT COUNT(*) AS nombre_fournisseurs FROM Fournisseur";

            MySqlCommand command = new MySqlCommand(query, connection);
            object result = command.ExecuteScalar();
            int nombreFournisseurs = Convert.ToInt32(result);
            Console.WriteLine($" + ------------------------------------------------------------------------------------------------- + ");

            Console.WriteLine($"Nombre de fournisseurs : {nombreFournisseurs}");
            Console.WriteLine($" + ------------------------------------------------------------------------------------------------- + ");
        }

        // Méthode pour obtenir le nombre de vélos
        public void NombreVelos()
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT COUNT(*) AS nombre_velos FROM Velo";

            MySqlCommand command = new MySqlCommand(query, connection);
            object result = command.ExecuteScalar();
            int nombreVelos = Convert.ToInt32(result);
            Console.WriteLine($" + ------------------------------------------------------------------------------------------------- + ");

            Console.WriteLine($"Nombre de vélos : {nombreVelos}");
            Console.WriteLine($" + ------------------------------------------------------------------------------------------------- + ");

        }

        // Méthode pour obtenir la quantité vendue pour chaque vélo
        public void QuantiteVendueParVelo()
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT c.id_velo, v.modele_ref, SUM(c.quantite) AS quantite_vendue " +
                           "FROM Commande_Particuliers c " +
                           "INNER JOIN Velo v ON c.id_velo = v.numero " +
                           "GROUP BY c.id_velo, v.modele_ref";

            MySqlCommand command = new MySqlCommand(query, connection);
            Console.WriteLine($" + ------------------------------------------------------------------------------------------------- + ");


            using MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int idVelo = reader.GetInt32("id_velo");
                int modele = reader.GetInt32("modele_ref");
                int quantiteVendue = reader.GetInt32("quantite_vendue");
                Console.WriteLine($"Velo {idVelo} ({modele}) : Quantité vendue = {quantiteVendue}");
            }
            Console.WriteLine($" + ------------------------------------------------------------------------------------------------- + ");

        }

        // Méthode pour obtenir le meilleur client particulier
        public void MeilleurClientParticulier()
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT id_particulier, SUM(quantite) AS total_ventes " +
                           "FROM Commande_Particuliers " +
                           "GROUP BY id_particulier " +
                           "ORDER BY total_ventes DESC " +
                           "LIMIT 1";

            MySqlCommand command = new MySqlCommand(query, connection);
            
            Console.WriteLine($" + ------------------------------------------------------------------------------------------------- + ");

            using MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int idParticulier = reader.GetInt32("id_particulier");
                int totalVentes = reader.GetInt32("total_ventes");
                Console.WriteLine($"Meilleur client particulier (ID) : {idParticulier}, Total achats : {totalVentes}");
            }
            Console.WriteLine($" + ------------------------------------------------------------------------------------------------- + ");

        }

        // Méthode pour obtenir la liste des membres pour chaque programme fidélité
        public void MembresParProgrammeFidelite()
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT f.Description, COUNT(*) AS nombre_membres " +
                           "FROM Particulier p " +
                           "INNER JOIN Fidelio f ON p.id = f.Numero " +
                           "GROUP BY f.description";

            MySqlCommand command = new MySqlCommand(query, connection);

            Console.WriteLine($" + ------------------------------------------------------------------------------------------------- + ");
            using MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string nomProgramme = reader.GetString("description");
                int nombreMembres = reader.GetInt32("nombre_membres");
                Console.WriteLine($"Programme fidélité : {nomProgramme}, Nombre de membres : {nombreMembres}");
            }
            Console.WriteLine($" + ------------------------------------------------------------------------------------------------- + ");
        }

        // Méthode pour obtenir la moyenne des montants des commandes
        public void MoyenneMontantsCommandes()
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT AVG(montant) AS moyenne_montants_commandes FROM Commande_Particuliers";

            Console.WriteLine($" + ------------------------------------------------------------------------------------------------- + ");
            MySqlCommand command = new MySqlCommand(query, connection);
            object result = command.ExecuteScalar();
            double moyenneMontantsCommandes = Convert.ToDouble(result);
            Console.WriteLine($"Moyenne des montants des commandes : {moyenneMontantsCommandes:F2}");
            Console.WriteLine($" + ------------------------------------------------------------------------------------------------- + ");
        }

        // Méthode pour obtenir la liste des produits ayant une quantité en stock <= 2
        public void ProduitsQuantiteStockFaible()
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT * FROM Stock WHERE en_stock <= 2";

            Console.WriteLine($" + ------------------------------------------------------------------------------------------------- + ");
            MySqlCommand command = new MySqlCommand(query, connection);

            using MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int idVelo = reader.GetInt32("id_velo");
                int quantite = reader.GetInt32("en_stock");
                Console.WriteLine($"Velo {idVelo} : Quantité en stock = {quantite} \n");
            }
            Console.WriteLine($" + ------------------------------------------------------------------------------------------------- + ");
        }

        // Méthode pour obtenir le nombre de commandes par client particulier
        public void NombreCommandesParClientParticulier()
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT id_particulier, COUNT(*) AS nombre_commandes " +
                           "FROM Commande_Particuliers " +
                           "GROUP BY id_particulier";

            MySqlCommand command = new MySqlCommand(query, connection);

            using MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int idParticulier = reader.GetInt32("id_particulier");
                int nombreCommandes = reader.GetInt32("nombre_commandes");
                Console.WriteLine($"Client particulier (ID) : {idParticulier}, Nombre de commandes : {nombreCommandes}");
            }
        }
    }
}
