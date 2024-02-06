using System.Data;
using System.Data.SqlClient;

namespace BugAnfFix_Dapper_Generic_Repository.Infrastructure.DataBase;

public class ApplicationDapperDbContext
{
    private readonly IConfiguration _configuration;

    public ApplicationDapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection(string connectionString = "DefaultConnection")
    {
        string? connection = _configuration.GetConnectionString(connectionString);
        return new SqlConnection(connection);
    }
}
