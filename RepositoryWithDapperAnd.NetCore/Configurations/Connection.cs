
using Microsoft.Data.SqlClient; 

namespace RepositoryWithDapperAnd.NetCore.Configuration
{
    public class Connection
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection("");
        }
    }
}
