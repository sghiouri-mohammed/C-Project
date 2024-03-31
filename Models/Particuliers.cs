using System;
using MySql.Data.MySqlClient;

namespace VeloMax.Models
{
    public class Particulier
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Rue { get; set; }
        public string Ville { get; set; }
        public int CodePostal { get; set; }
        public string Province { get; set; }
        public string Tel { get; set; }
        public string Courriel { get; set; }

        // Constructeur par défaut
        public Particulier() { }

        // Constructeur avec paramètres
        public Particulier(string nom, string prenom, string rue, string ville, int codePostal, string province, string tel, string courriel)
        {
            Nom = nom;
            Prenom = prenom;
            Rue = rue;
            Ville = ville;
            CodePostal = codePostal;
            Province = province;
            Tel = tel;
            Courriel = courriel;
        }
        

        // Constructeur avec paramètres
        public Particulier(int id, string nom, string prenom, string rue, string ville, int codePostal, string province, string tel, string courriel)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Rue = rue;
            Ville = ville;
            CodePostal = codePostal;
            Province = province;
            Tel = tel;
            Courriel = courriel;
        }

        // Méthodes CRUD
        // Ajouter un nouveau particulier à la base de données
        public void AjouterParticulier(MySqlConnection connection)
        {
            string query = "INSERT INTO Particulier(nom, prenom, rue, ville, code_postal, province, tel, courriel) VALUES(@Nom, @Prenom, @Rue, @Ville, @CodePostal, @Province, @Tel, @Courriel)";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Nom", Nom);
            command.Parameters.AddWithValue("@Prenom", Prenom);
            command.Parameters.AddWithValue("@Rue", Rue);
            command.Parameters.AddWithValue("@Ville", Ville);
            command.Parameters.AddWithValue("@CodePostal", CodePostal);
            command.Parameters.AddWithValue("@Province", Province);
            command.Parameters.AddWithValue("@Tel", Tel);
            command.Parameters.AddWithValue("@Courriel", Courriel);

            command.ExecuteNonQuery();
        }

        // Modifier un particulier existant dans la base de données
        public void ModifierParticulier(MySqlConnection connection, int id)
        {
            string query = $"UPDATE Particulier SET nom = @Nom, prenom = @Prenom, rue = @Rue, ville = @Ville, code_postal = @CodePostal, province = @Province, tel = @Tel, courriel = @Courriel WHERE id = {id}";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Nom", Nom);
            command.Parameters.AddWithValue("@Prenom", Prenom);
            command.Parameters.AddWithValue("@Rue", Rue);
            command.Parameters.AddWithValue("@Ville", Ville);
            command.Parameters.AddWithValue("@CodePostal", CodePostal);
            command.Parameters.AddWithValue("@Province", Province);
            command.Parameters.AddWithValue("@Tel", Tel);
            command.Parameters.AddWithValue("@Courriel", Courriel);

            command.ExecuteNonQuery();
        }

        // Supprimer un particulier de la base de données
        public void SupprimerParticulier(MySqlConnection connection, int id)
        {
            string query = $"DELETE FROM Particulier WHERE id = {id}";

            MySqlCommand command = new MySqlCommand(query, connection);

            command.ExecuteNonQuery();
        }





    }
}
