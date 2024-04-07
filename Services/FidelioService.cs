using MySql.Data.MySqlClient;
using VeloMax.Models;

namespace VeloMax.Services
{
    public class FidelioService
    {
        private readonly string _connectionString;

        public FidelioService()
        {
            _connectionString = "server=localhost;userid=root;password=;database=VeloMax";
        }

        // Méthode pour ajouter un programme Fidélio
        public void AjouterFidelio(Fidelio fidelio)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            fidelio.AjouterFidelio(connection);
        }

        // Méthode pour modifier un programme Fidélio
        public void ModifierFidelio(Fidelio fidelio)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            fidelio.ModifierFidelio(connection);
        }

        // Méthode pour supprimer un programme Fidélio
        public void SupprimerFidelio(Fidelio fidelio)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            fidelio.SupprimerFidelio(connection);
        }

        // Méthode pour imprimer la liste des programmes Fidélio
        public void PrintAllFidelio()
        {
            List<Fidelio> fidelios = new List<Fidelio>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT * FROM Fidelio";
            MySqlCommand command = new MySqlCommand(query, connection);

            using MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                fidelios.Add(new Fidelio
                {
                    Numero = reader.GetInt32("Numero"),
                    Description = reader.GetString("Description"),
                    Cout = reader.GetDecimal("Cout"),
                    Duree = reader.GetString("Duree"),
                    Rabais = reader.GetDecimal("Rabais")
                });
            }

            Console.WriteLine("Liste des programmes Fidélio :");

            Console.WriteLine($" + -------------------------------------------------------------- + ");
            Console.WriteLine($" | Numéro || Description || Coût || Durée || Rabais (%) || ");
            foreach (var fidelio in fidelios)
            {
                Console.WriteLine($" + -------------------------------------------------------------- + ");
                Console.WriteLine($" | {fidelio.Numero} || {fidelio.Description} || {fidelio.Cout} || {fidelio.Duree} || {fidelio.Rabais} || ");
            }
            
            Console.WriteLine($" + -------------------------------------------------------------- + ");
        }

        public void PrintAllClientFidelio()
        {
            List<ClientFidelio> clientFidelios = new List<ClientFidelio>();

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT * FROM Client_Fidelio";
            MySqlCommand command = new MySqlCommand(query, connection);

            using MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                clientFidelios.Add(new ClientFidelio
                {
                    IdClient = reader.GetInt32("id_client"),
                    IdFidelio = reader.GetInt32("id_fidelio"),
                    DateAdhesion = reader.GetDateTime("date_adhesion")
                });
            }

            Console.WriteLine("Liste des clients affectés aux programmes Fidélio :");

            Console.WriteLine($" + -------------------------------------------------------------- + ");
            Console.WriteLine($" | ID Client || ID Fidelio || Date d'adhésion || ");
            foreach (var clientFidelio in clientFidelios)
            {
                Console.WriteLine($" + -------------------------------------------------------------- + ");
                Console.WriteLine($" | {clientFidelio.IdClient} || {clientFidelio.IdFidelio} || {clientFidelio.DateAdhesion} || ");
            }
            
            Console.WriteLine($" + -------------------------------------------------------------- + ");
        }


        public Fidelio GetFidelioById(int id)
        {
            Fidelio fidelio = null;

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT * FROM Fidelio WHERE id = @Id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            using MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                fidelio = new Fidelio
                {
                    Numero = reader.GetInt32("numero"),
                    Description = reader.GetString("Description"),
                    Cout = reader.GetDecimal("Cout"),
                    Duree = reader.GetString("Duree"),
                    Rabais = reader.GetDecimal("Rabais")
                };
            }

            return fidelio;
        }
    }
}
