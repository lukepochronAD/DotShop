using System.Data.SqlClient;
using Dotshop.Core;

namespace Dotshop.Infrastructure
{
    public class SQLConnectionFactory : IConnectionFactory <SqlConnection>
   {
        public SqlConnection Connection()
        {
            var hardwiredConnectionString = "Server = ANS-A352\\MSSQLSERVER01; Database = DotShop; Trusted_Connection = True";
            return new SqlConnection(hardwiredConnectionString);
        }
    }
}   