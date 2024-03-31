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
    }
}

