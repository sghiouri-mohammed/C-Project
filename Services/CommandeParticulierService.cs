using MySql.Data.MySqlClient;
using VeloMax.Models;

namespace VeloMax.Services
{
    public class CommandeParticulierService
    {
        private readonly string _connectionString;

        public CommandeParticulierService()
        {
            _connectionString = "server=localhost;userid=root;password=;database=VeloMax";
        }

        public void AjouterCommandeParticulier(CommandeParticulier commandeParticulier)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            commandeParticulier.AjouterCommandeParticulier(connection);
        }

        public void ModifierCommandeParticulier(CommandeParticulier commandeParticulier)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            commandeParticulier.ModifierCommandeParticulier(connection);
        }

        public void SupprimerCommandeParticulier(CommandeParticulier commandeParticulier)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            commandeParticulier.SupprimerCommandeParticulier(connection);
        }
        public CommandeParticulier GetCommandeParticulierById(int id)
        {
            CommandeParticulier commandeParticulier = null;

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT * FROM Commande_Particuliers WHERE id_commande = @Id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            using MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                commandeParticulier = new CommandeParticulier
                {
                    IdCommande = reader.GetInt32("id_commande"),
                    IdParticulier = reader.GetInt32("id_particulier"),
                    IdVelo = reader.GetInt32("id_velo"),
                    DateCommande = reader.GetDateTime("date_commande"),
                    AdresseLivraison = reader.GetString("adresse_livraison"),
                    DateLivraison = reader.GetDateTime("date_livraison"),
                    Quantite = reader.GetInt32("quantite")
                };
            }

            return commandeParticulier;
        }

        public void PrintAllCommandesParticuliers()
        {
            List<CommandeParticulier> commandesParticuliers = new List<CommandeParticulier>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT * FROM Commande_Particuliers";
            MySqlCommand command = new MySqlCommand(query, connection);

            using MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                CommandeParticulier commandeParticulier = new CommandeParticulier
                {
                    IdCommande = reader.GetInt32("id_commande"),
                    IdParticulier = reader.GetInt32("id_particulier"),
                    IdVelo = reader.GetInt32("id_velo"),
                    DateCommande = reader.GetDateTime("date_commande"),
                    AdresseLivraison = reader.GetString("adresse_livraison"),
                    DateLivraison = reader.GetDateTime("date_livraison"),
                    Quantite = reader.GetInt32("quantite")
                };
                commandesParticuliers.Add(commandeParticulier);
            }

            Console.WriteLine("Liste des commandes particuliers :");

            Console.WriteLine($" + ----------------------------------------------------------------------------------------------------------------------------------- + ");
            Console.WriteLine($" | ID Commande || ID Particulier || ID Vélo || Date Commande || Adresse Livraison || Date Livraison || Quantité || ");
            Console.WriteLine($" + ___________________________________________________________________________________________________________________________________ + ");

            foreach (var commandeParticulier in commandesParticuliers)
            {
                Console.WriteLine($" + ----------------------------------------------------------------------------------------------------------------------------------- + ");
                Console.WriteLine($" | {commandeParticulier.IdCommande} || {commandeParticulier.IdParticulier} || {commandeParticulier.IdVelo} || {commandeParticulier.DateCommande} || {commandeParticulier.AdresseLivraison} || {commandeParticulier.DateLivraison} || {commandeParticulier.Quantite} || ");
            }
            Console.WriteLine($" + ----------------------------------------------------------------------------------------------------------------------------------- + ");
        }

    }
}
