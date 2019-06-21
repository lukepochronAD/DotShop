using System.Data.Common;
using System.Data.SqlClient;

namespace Dotshop.Core
{
    public interface IConnectionFactory
    {
        SqlConnection Connection();
    }
}
