using Infrastructure.Persistence.Data.Config;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Infrastructure.Persistence.Data
{
    public class DapperDbContext : IPMSConfiguration
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DbConnection")!;
        }
        public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);

        public IConfigurationSection GetConfigurationSection(string Key)
        {
            return _configuration.GetSection(Key);
        }
       
    }
}
