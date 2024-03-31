using MySql.Data.MySqlClient;
using VeloMax.Models;

namespace VeloMax.Services
{
    public class FournisseurService
    {
        private readonly string _connectionString;

        public FournisseurService()
        {
            _connectionString = "server=localhost;userid=root;password=;database=VeloMax";
        }

        // Méthode pour ajouter un fournisseur
        public void AjouterFournisseur(Fournisseur fournisseur)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            fournisseur.AjouterFournisseur(connection);
        }

        // Méthode pour modifier un fournisseur
        public void ModifierFournisseur(Fournisseur fournisseur)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            fournisseur.ModifierFournisseur(connection);
        }

        // Méthode pour supprimer un fournisseur
        public void SupprimerFournisseur(Fournisseur fournisseur)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            fournisseur.SupprimerFournisseur(connection);
        }
        // Méthode pour récupérer un fournisseur par son numéro SIRET
        public Fournisseur GetFournisseurBySiret(int siret)
        {
            Fournisseur fournisseur = null;

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT * FROM Fournisseur WHERE siret = @Siret";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Siret", siret);

            using MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                fournisseur = new Fournisseur
                {
                    Siret = reader.GetInt32("siret"),
                    NomEntreprise = reader.GetString("nom_entreprise"),
                    Contact = reader.GetString("contact"),
                    Adresse = reader.GetString("adresse"),
                    Statut = reader.GetInt32("statut")
                };
            }

            return fournisseur;
        }

        // Méthode pour imprimer la liste des fournisseurs
        public void PrintAllFournisseurs()
        {
            List<Fournisseur> fournisseurs = new List<Fournisseur>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT * FROM Fournisseur";
            MySqlCommand command = new MySqlCommand(query, connection);

            using MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                fournisseurs.Add(new Fournisseur
                {
                    Siret = reader.GetInt32("siret"),
                    NomEntreprise = reader.GetString("nom_entreprise"),
                    Contact = reader.GetString("contact"),
                    Adresse = reader.GetString("adresse"),
                    Statut = reader.GetInt32("statut")
                });
            }

            Console.WriteLine("Liste des fournisseurs :");

            Console.WriteLine($" + ---------------------------------------------------------------------------------------- + ");
            Console.WriteLine($" | Siret || Nom de l'entreprise || Contact || Adresse || Statut || ");
            foreach (var fournisseur in fournisseurs)
            {
                Console.WriteLine($" + ---------------------------------------------------------------------------------------- + ");
                Console.WriteLine($" | {fournisseur.Siret} || {fournisseur.NomEntreprise} || {fournisseur.Contact} || {fournisseur.Adresse} || {fournisseur.Statut} || ");
            }
            
                Console.WriteLine($" + ---------------------------------------------------------------------------------------- + ");

        }
    }
}
