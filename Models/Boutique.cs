using System;
using MySql.Data.MySqlClient;

namespace VeloMax.Models
{
    public class Boutique
    {
    
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Rue { get; set; }
        public string Ville { get; set; }
        public int CodePostal { get; set; }
        public string Province { get; set; }
        public string Tel { get; set; }
        public string Courriel { get; set; }
        public string PersonneContact { get; set; }

        // Constructeur par défaut
        public Boutique() 
        { 

        }

        // Constructeur avec paramètres
        // 8 parametres
        public Boutique(string nom, string rue, string ville, int codePostal, string province, string tel, string courriel, string personneContact)
        {
            Nom = nom;
            Rue = rue;
            Ville = ville;
            CodePostal = codePostal;
            Province = province;
            Tel = tel;
            Courriel = courriel;
            PersonneContact = personneContact;
        }

        // 9 parametres
        public Boutique(int id, string nom, string rue, string ville, int codePostal, string province, string tel, string courriel, string personneContact)
        {
            Id = id;
            Nom = nom;
            Rue = rue;
            Ville = ville;
            CodePostal = codePostal;
            Province = province;
            Tel = tel;
            Courriel = courriel;
            PersonneContact = personneContact;
        }

        // Méthode pour ajouter une nouvelle boutique à la base de données
        public void AjouterBoutique(MySqlConnection connection)
        {
            string query = "INSERT INTO Boutique(nom, rue, ville, code_postal, province, tel, courriel, personne_contact) VALUES (@Nom, @Rue, @Ville, @CodePostal, @Province, @Tel, @Courriel, @PersonneContact)";

            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@Nom", Nom);
            command.Parameters.AddWithValue("@Rue", Rue);
            command.Parameters.AddWithValue("@Ville", Ville);
            command.Parameters.AddWithValue("@CodePostal", CodePostal);
            command.Parameters.AddWithValue("@Province", Province);
            command.Parameters.AddWithValue("@Tel", Tel);
            command.Parameters.AddWithValue("@Courriel", Courriel);
            command.Parameters.AddWithValue("@PersonneContact", PersonneContact);

            command.ExecuteNonQuery();
        }

        // Méthode pour modifier une boutique existante dans la base de données
        public void ModifierBoutique(MySqlConnection connection)
        {
            string query = "UPDATE Boutique SET nom = @Nom, rue = @Rue, ville = @Ville, code_postal = @CodePostal, province = @Province, tel = @Tel, courriel = @Courriel, personne_contact = @PersonneContact WHERE id = @Id";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@Nom", Nom);
            command.Parameters.AddWithValue("@Rue", Rue);
            command.Parameters.AddWithValue("@Ville", Ville);
            command.Parameters.AddWithValue("@CodePostal", CodePostal);
            command.Parameters.AddWithValue("@Province", Province);
            command.Parameters.AddWithValue("@Tel", Tel);
            command.Parameters.AddWithValue("@Courriel", Courriel);
            command.Parameters.AddWithValue("@PersonneContact", PersonneContact);

            command.ExecuteNonQuery();
        }

        // Méthode pour supprimer une boutique de la base de données
        public void SupprimerBoutique(MySqlConnection connection)
        {
            string query = "DELETE FROM Boutique WHERE id = @Id";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", Id);

            command.ExecuteNonQuery();
        }
    }
}
