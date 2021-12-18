using System.Data;
using System.Threading.Tasks;
using Npgsql;

namespace RtaAssignment.Infrastructure.Persistence
{
    public static class ConnectionFactory
    {
        public static string ConnectionString { get; set; }

        public static async Task<IDbConnection> DbConnection()
        {
            var con = new NpgsqlConnection(ConnectionString);
            await con.OpenAsync();
            return con;
        }
    }
}