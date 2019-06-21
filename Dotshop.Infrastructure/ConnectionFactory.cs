using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Dotshop.Core;
using Dotshop.Core.Interfaces;

namespace Dotshop.Infrastructure

{
   class ConnectionFactory : IConnectionFactory
   {
        
    //    private ConnectionFactory ()
    //        {
                
    //        }


        SqlConnection IConnectionFactory.Connection()
        {
            var hardwiredConnectionString = "Server = ANS-A352\\MSSQLSERVER01; Database = DotShop; Trusted_Connection = True";
            return new SqlConnection(hardwiredConnectionString);
        }
    }
}