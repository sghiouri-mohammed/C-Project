using MySql.Data.MySqlClient;
using VeloMax.Models;

namespace VeloMax.Services
{
    public class StatistiquesSeervices
    {
        private readonly string _connectionString;

        public StatistiquesSeervices()
        {
            _connectionString = "server=localhost;userid=root;password=;database=VeloMax";
        }

        
        
    }
}
