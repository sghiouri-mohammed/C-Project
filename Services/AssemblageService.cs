using MySql.Data.MySqlClient;
using VeloMax.Models;
using System;
using System.Collections.Generic;

namespace VeloMax.Services
{
    public class AssemblageService
    {
        private readonly string _connectionString;

        public AssemblageService()
        {
            _connectionString = "server=localhost;userid=root;password=;database=VeloMax";
        }

        // Méthode pour ajouter un assemblage
        public void AjouterAssemblage(Assemblage assemblage)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            assemblage.AjouterAssemblage(connection);
        }

        // Méthode pour modifier un assemblage
        public void ModifierAssemblage(Assemblage assemblage)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            assemblage.ModifierAssemblage(connection);
        }

        // Méthode pour supprimer un assemblage
        public void SupprimerAssemblage(Assemblage assemblage)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            assemblage.SupprimerAssemblage(connection);
        }

        // Méthode pour récupérer un assemblage par son ID
        public Assemblage GetAssemblageById(int id)
        {
            Assemblage assemblage = null;

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT * FROM Assemblage WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            using MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                assemblage = new Assemblage
                {
                    Id = reader.GetInt32("id"),
                    Nom = reader.GetString("Nom"),
                    Grandeur = reader.GetString("Grandeur"),
                    Cadre = reader.GetString("Cadre"),
                    Guidon = reader.GetString("Guidon"),
                    Freins = reader.GetString("Freins"),
                    Selle = reader.GetString("Selle"),
                    DerailleurAvant = reader.GetString("Dérailleur_Avant"),
                    DerailleurArriere = reader.GetString("Dérailleur_Arrière"),
                    RoueAvant = reader.GetString("Roue_avant"),
                    RoueArriere = reader.GetString("Roue_arrière"),
                    Reflecteurs = reader.GetString("Réflecteurs"),
                    Pedalier = reader.GetString("Pédalier"),
                    Ordinateur = reader.GetString("Ordinateur"),
                    Panier = reader.GetString("Panier")
                };
            }

            return assemblage;
        }

        // Méthode pour imprimer la liste des assemblages
        public void PrintAllAssemblages()
        {
            List<Assemblage> assemblages = new List<Assemblage>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT * FROM Assemblage";
            MySqlCommand command = new MySqlCommand(query, connection);

            using MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                assemblages.Add(new Assemblage
                {
                    Id = reader.GetInt32("id"),
                    Nom = reader.GetString("Nom"),
                    Grandeur = reader.GetString("Grandeur"),
                    Cadre = reader.GetString("Cadre"),
                    Guidon = reader.GetString("Guidon"),
                    Freins = reader.GetString("Freins"),
                    Selle = reader.GetString("Selle"),
                    DerailleurAvant = reader.GetString("Dérailleur_Avant"),
                    DerailleurArriere = reader.GetString("Dérailleur_Arrière"),
                    RoueAvant = reader.GetString("Roue_avant"),
                    RoueArriere = reader.GetString("Roue_arrière"),
                    Reflecteurs = reader.GetString("Réflecteurs"),
                    Pedalier = reader.GetString("Pédalier"),
                    Ordinateur = reader.GetString("Ordinateur"),
                    Panier = reader.GetString("Panier")
                });
            }

            Console.WriteLine("Liste des assemblages :");

            Console.WriteLine($" + ---------------------------------------------------------------------------------------------------------------------------- + ");
            Console.WriteLine($" | ID || Nom || Grandeur || Cadre || Guidon || Freins || Selle || Dérailleur Avant || Dérailleur Arrière || Roue Avant || Roue Arrière || Réflecteurs || Pédalier || Ordinateur || Panier || ");
            foreach (var assemblage in assemblages)
            {
                Console.WriteLine($" + ---------------------------------------------------------------------------------------------------------------------------- + ");
                Console.WriteLine($" | {assemblage.Id} || {assemblage.Nom} || {assemblage.Grandeur} || {assemblage.Cadre} || {assemblage.Guidon} || {assemblage.Freins} || {assemblage.Selle} || {assemblage.DerailleurAvant} || {assemblage.DerailleurArriere} || {assemblage.RoueAvant} || {assemblage.RoueArriere} || {assemblage.Reflecteurs} || {assemblage.Pedalier} || {assemblage.Ordinateur} || {assemblage.Panier} || ");
            }
            
                Console.WriteLine($" + ---------------------------------------------------------------------------------------------------------------------------- + ");

        }
    }
}
