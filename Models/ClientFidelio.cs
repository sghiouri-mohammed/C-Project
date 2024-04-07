using System;
using System;
using MySql.Data.MySqlClient;

namespace VeloMax.Models
{
    public class ClientFidelio
    {
        // Attributs
        public int IdClient { get; set; }
        public int IdFidelio { get; set; }
        public DateTime DateAdhesion { get; set; }

        // Constructeur par défaut
        public ClientFidelio() { }

        // Constructeur avec paramètres
        public ClientFidelio(int idClient, int idFidelio, DateTime dateAdhesion)
        {
            IdClient = idClient;
            IdFidelio = idFidelio;
            DateAdhesion = dateAdhesion;
        }
    }
}
