using MySql.Data.MySqlClient;

using VeloMax.Models;

namespace VeloMax.Services
{
    public class VeloService
    {
        private readonly string _connectionString ;

        public VeloService()
        {
            _connectionString = "server=localhost;userid=root;password=;database=VeloMax";
        }

        // Méthode pour ajouter un vélo
        public void AjouterVelo(Velo velo)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            velo.AjouterVelo(connection);
        }

        // Méthode pour modifier un vélo
        public void ModifierVelo(Velo velo)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            velo.ModifierVelo(connection);
        }

        // Méthode pour supprimer un vélo
        public void SupprimerVelo(Velo velo)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            velo.SupprimerVelo(connection);
        }

        // Méthode pour récupérer un particulier par son ID
        public Velo GetVeloById(int numero)
        {
            Velo velo = null;

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT * FROM Velo WHERE id = @Numero";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Numero", numero);

            using MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                velo = new Velo
                {
                    Numero = reader.GetInt32("numero"),
                    Nom = reader.GetString("model_ref"),
                    Grandeur = reader.GetString("grandeur"),
                    PrixUnitaire = reader.GetInt32("prix_unitaire"),
                    LigneProduit = reader.GetString("ligne_produit"),
                    DateIntroduction = reader.GetDateTime("date_intro"),
                    DateDiscontinuation = reader.GetDateTime("date_disc"),
                    
                };
            }

            return velo;
            
        }
    }
}

