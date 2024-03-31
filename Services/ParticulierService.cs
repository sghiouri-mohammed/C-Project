using MySql.Data.MySqlClient;
using VeloMax.Models;

namespace VeloMax.Services
{
    public class ParticulierService
    {
        private readonly string _connectionString;

        public ParticulierService()
        {
            _connectionString = "server=localhost;userid=root;password=;database=VeloMax";
        }

        // Méthode pour ajouter un particulier
        public void AjouterParticulier(Particulier particulier)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            particulier.AjouterParticulier(connection);
        }

        // Méthode pour modifier un particulier
        public void ModifierParticulier(Particulier particulier)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            particulier.ModifierParticulier(connection, particulier.Id);
        }

        // Méthode pour supprimer un particulier
        public void SupprimerParticulier(Particulier particulier)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            particulier.SupprimerParticulier(connection, particulier.Id);
        }

        // Méthode pour récupérer un particulier par son ID
        public Particulier GetParticulierById(int id)
        {
            Particulier particulier = null;

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT * FROM Particulier WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            using MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                particulier = new Particulier
                {
                    Id = reader.GetInt32("id"),
                    Nom = reader.GetString("nom"),
                    Prenom = reader.GetString("prenom"),
                    Rue = reader.GetString("rue"),
                    Ville = reader.GetString("ville"),
                    CodePostal = reader.GetInt32("code_postal"),
                    Province = reader.GetString("province"),
                    Tel = reader.GetString("tel"),
                    Courriel = reader.GetString("courriel")
                };
            }

            return particulier;
        }


        // Méthode pour imprimer la liste des particuliers
        public void PrintAllParticuliers()
        {
            List<Particulier> particuliers = new List<Particulier>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT * FROM Particulier";
            MySqlCommand command = new MySqlCommand(query, connection);

            using MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                particuliers.Add(new Particulier
                {
                    Id = reader.GetInt32("id"),
                    Nom = reader.GetString("nom"),
                    Prenom = reader.GetString("prenom"),
                    Rue = reader.GetString("rue"),
                    Ville = reader.GetString("ville"),
                    CodePostal = reader.GetInt32("code_postal"),
                    Province = reader.GetString("province"),
                    Tel = reader.GetString("tel"),
                    Courriel = reader.GetString("courriel")
                });
            }

            Console.WriteLine("Liste des particuliers :");

            Console.WriteLine($" + -------------------------------------------------------------- + ");
            Console.WriteLine($" | ID|| Nom || Prénom || Ville || Province || Courriel || ");
            foreach (var particulier in particuliers)
            {
                Console.WriteLine($" + -------------------------------------------------------------- + ");
                Console.WriteLine($" | {particulier.Id} || {particulier.Nom} || {particulier.Prenom} || {particulier.Ville} || {particulier.Tel} || {particulier.Courriel} || ");
            }
            
                Console.WriteLine($" + -------------------------------------------------------------- + ");

        }
    }
}
