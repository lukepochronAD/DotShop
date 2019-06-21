using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dotshop.Core;
using Dotshop.Core.Interfaces;
using Dotshop.Core.Models;

namespace Dotshop.Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        private IConnectionFactory<SqlConnection> dbconnectionfactory { get; }
        public OrderRepository(IConnectionFactory<SqlConnection> dbConnectionFactory)
        {
            this.dbconnectionfactory = dbConnectionFactory;
        }


        public async Task<IEnumerable<Order>> GetAllOrders()
        {

            var allItems = new List<Order>();
            using (SqlConnection conn = this.dbconnectionfactory.Connection())
            {


                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Orders;", conn))
                {
                    conn.Open();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        int orderid = reader.GetInt32(0);
                        var datetime = reader.GetDateTime(1);
                        var orderpaid = reader.GetBoolean(2);

                        allItems.Add(new Order() { OrderId = orderid, OrderDate = datetime, OrderPaid = orderpaid });
                    }

                }
            }
            return allItems;
        }


        public Task<IEnumerable<Order>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}