using Microsoft.Extensions.Configuration;

namespace Infrastructure.Utility
{
    public class SqlConnection
    {
        public IConfiguration _config;
        public string? ConStr = string.Empty;
        public SqlConnection(IConfiguration config) 
        {
            _config = config;
            ConStr = _config.GetConnectionString("ConnectionString");
        }  
    }
}
