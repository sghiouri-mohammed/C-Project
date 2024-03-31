using MySql.Data.MySqlClient;
using VeloMax.Models;

namespace VeloMax.Services
{
    public class BoutiqueService
    {
        private readonly string _connectionString;

        public BoutiqueService()
        {
            _connectionString = "server=localhost;userid=root;password=;database=VeloMax";
        }

        // Méthode pour ajouter une boutique
        public void AjouterBoutique(Boutique boutique)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            boutique.AjouterBoutique(connection);
        }

        // Méthode pour modifier une boutique
        public void ModifierBoutique(Boutique boutique)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            boutique.ModifierBoutique(connection);
        }

        // Méthode pour supprimer une boutique
        public void SupprimerBoutique(Boutique boutique)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            boutique.SupprimerBoutique(connection);
        }

        // Méthode pour récupérer une boutique par son ID
        public Boutique GetBoutiqueById(int id)
        {
            Boutique boutique = null;

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT * FROM Boutique WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            using MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                boutique = new Boutique
                {
                    Id = reader.GetInt32("id"),
                    Nom = reader.GetString("nom"),
                    Rue = reader.GetString("rue"),
                    Ville = reader.GetString("ville"),
                    CodePostal = reader.GetInt32("code_postal"),
                    Province = reader.GetString("province"),
                    Tel = reader.GetString("tel"),
                    Courriel = reader.GetString("courriel"),
                    PersonneContact = reader.GetString("personne_contact")
                };
            }

            return boutique;
        }

        public void PrintAllBoutiques()
        {
            List<Boutique> boutiques = new List<Boutique>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT * FROM Boutique";
            MySqlCommand command = new MySqlCommand(query, connection);

            using MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                boutiques.Add(new Boutique
                {
                    Id = reader.GetInt32("id"),
                    Nom = reader.GetString("nom"),
                    Rue = reader.GetString("rue"),
                    Ville = reader.GetString("ville"),
                    CodePostal = reader.GetInt32("code_postal"),
                    Province = reader.GetString("province"),
                    Tel = reader.GetString("tel"),
                    Courriel = reader.GetString("courriel"),
                    PersonneContact = reader.GetString("personne_contact")
                });
            }

            Console.WriteLine("Liste des boutiques :");

            Console.WriteLine($" + ----------------------------------------------------------------------------------------------------------------------------------- + ");
            Console.WriteLine($" | ID || Nom || Rue || Ville || Code Postal || Province || Tel || Courriel || Personne de contact || ");
            Console.WriteLine($" + ___________________________________________________________________________________________________________________________________ + ");

            foreach (var boutique in boutiques)
            {
                Console.WriteLine($" + ----------------------------------------------------------------------------------------------------------------------------------- + ");
                Console.WriteLine($" | {boutique.Id} || {boutique.Nom} || {boutique.Rue} || {boutique.Ville} || {boutique.CodePostal} || {boutique.Province} || {boutique.Tel} || {boutique.Courriel} || {boutique.PersonneContact} || ");
            }
            Console.WriteLine($" + ----------------------------------------------------------------------------------------------------------------------------------- + ");
        
        }

    }
}
