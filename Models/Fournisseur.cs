using MySql.Data.MySqlClient;

namespace VeloMax.Models
{
    public class Fournisseur
    {
        public int Siret { get; set; }
        public string NomEntreprise { get; set; }
        public string Contact { get; set; }
        public string Adresse { get; set; }
        public int Statut { get; set; }

        // Constructeur par défaut
        public Fournisseur() { }

        // Constructeur avec paramètres
        public Fournisseur(int siret, string nomEntreprise, string contact, string adresse, int statut)
        {
            Siret = siret;
            NomEntreprise = nomEntreprise;
            Contact = contact;
            Adresse = adresse;
            Statut = statut;
        }

        // Méthodes CRUD
        // Ajouter un nouveau fournisseur à la base de données
        public void AjouterFournisseur(MySqlConnection connection)
        {
            string query = "INSERT INTO Fournisseur(siret, nom_entreprise, contact, adresse, statut) VALUES(@Siret, @NomEntreprise, @Contact, @Adresse, @Statut)";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Siret", Siret);
            command.Parameters.AddWithValue("@NomEntreprise", NomEntreprise);
            command.Parameters.AddWithValue("@Contact", Contact);
            command.Parameters.AddWithValue("@Adresse", Adresse);
            command.Parameters.AddWithValue("@Statut", Statut);

            command.ExecuteNonQuery();
        }

        // Modifier un fournisseur existant dans la base de données
        public void ModifierFournisseur(MySqlConnection connection)
        {
            string query = "UPDATE Fournisseur SET nom_entreprise = @NomEntreprise, contact = @Contact, adresse = @Adresse, statut = @Statut WHERE siret = @Siret";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Siret", Siret);
            command.Parameters.AddWithValue("@NomEntreprise", NomEntreprise);
            command.Parameters.AddWithValue("@Contact", Contact);
            command.Parameters.AddWithValue("@Adresse", Adresse);
            command.Parameters.AddWithValue("@Statut", Statut);

            command.ExecuteNonQuery();
        }

        // Supprimer un fournisseur de la base de données
        public void SupprimerFournisseur(MySqlConnection connection)
        {
            string query = "DELETE FROM Fournisseur WHERE siret = @Siret";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Siret", Siret);

            command.ExecuteNonQuery();
        }
    }
}
