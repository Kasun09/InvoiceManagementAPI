using Microsoft.Data.SqlClient;
using System.Data;

namespace InvoiceManagementAPI.Repositories
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            // Get Connection String from appsettings.json 
            _connectionString = _configuration.GetConnectionString("DefaultConnection")!;
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}