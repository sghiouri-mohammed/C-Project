using System;
using MySql.Data.MySqlClient;

namespace VeloMax.Models
{
    public class Fidelio
    {
        public int Numero { get; set; }
        public string Description { get; set; }
        public decimal Cout { get; set; }
        public string Duree { get; set; }
        public decimal Rabais { get; set; }

        // Constructeur par défaut
        public Fidelio() { }

        // Constructeur avec paramètres
        public Fidelio(int numero, string description, decimal cout, string duree, decimal rabais)
        {
            Numero = numero;
            Description = description;
            Cout = cout;
            Duree = duree;
            Rabais = rabais;
        }

        public Fidelio( string description, decimal cout, string duree, decimal rabais)
        {
            Description = description;
            Cout = cout;
            Duree = duree;
            Rabais = rabais;
        }

        // Méthodes CRUD
        // Ajouter un nouveau programme Fidélio à la base de données
        public void AjouterFidelio(MySqlConnection connection)
        {
            string query = "INSERT INTO Fidelio(Numero, Description, Cout, Duree, Rabais) VALUES(@Numero, @Description, @Cout, @Duree, @Rabais)";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Numero", Numero);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@Cout", Cout);
            command.Parameters.AddWithValue("@Duree", Duree);
            command.Parameters.AddWithValue("@Rabais", Rabais);

            command.ExecuteNonQuery();
        }

        // Modifier un programme Fidélio existant dans la base de données
        public void ModifierFidelio(MySqlConnection connection)
        {
            string query = "UPDATE Fidelio SET Description = @Description, Cout = @Cout, Duree = @Duree, Rabais = @Rabais WHERE Numero = @Numero";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Numero", Numero);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@Cout", Cout);
            command.Parameters.AddWithValue("@Duree", Duree);
            command.Parameters.AddWithValue("@Rabais", Rabais);

            command.ExecuteNonQuery();
        }

        // Supprimer un programme Fidélio de la base de données
        public void SupprimerFidelio(MySqlConnection connection)
        {
            string query = "DELETE FROM Fidelio WHERE Numero = @Numero";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Numero", Numero);

            command.ExecuteNonQuery();
        }
    }
}
