using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Dotshop.Core;
using Dotshop.Core.Interfaces;
using Dotshop.Core.Models;

namespace Dotshop.Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        private IConnectionFactory<SqlConnection> DbConnectionFactory { get; }
        public OrderRepository(IConnectionFactory<SqlConnection> dbConnectionFactory)
        {
            this.DbConnectionFactory = dbConnectionFactory;
        }


        public async Task<IEnumerable<Order>> GetAllOrders()
        {

         

            using (SqlConnection conn = this.DbConnectionFactory.Connection())
            {

                var query = @"SELECT o.OrderId, o.OrderDate, o.OrderPaid, SUM(i.Price) AS 'TotalDue' FROM dbo.Orders o
                                LEFT JOIN dbo.OrderItems oi
                                ON oi.OrderId = o.OrderId
                                LEFT JOIN DBO.Items i
                                ON oi.ItemId = i.ItemId
                                GROUP BY
                                o.OrderId, o.OrderDate, o.OrderPaid; ";

                using (var connection = this.DbConnectionFactory.Connection())
                {
                    return await connection.QueryAsync<Order>(query);
                }

            }
        }

        public async Task<Order> GetById(int id)
        {

                var query = $@"SELECT o.OrderId, o.OrderDate, o.OrderPaid, SUM(i.Price) AS 'TotalDue' FROM dbo.Orders o
                            LEFT JOIN dbo.OrderItems oi
                            ON oi.OrderId = o.OrderId
                            LEFT JOIN DBO.Items i
                            ON  oi.ItemId = i.ItemId
                            WHERE o.OrderId = @id
                            GROUP BY
                            o.OrderId, o.OrderDate, o.OrderPaid; ";

            using (var connection = this.DbConnectionFactory.Connection())
            {
                return await connection.QueryFirstOrDefaultAsync<Order>(query, new {id });
            }


        }

        public async Task<Order> CreateNew(Order order)
        {

            var query = @"INSERT INTO dbo.Orders (OrderDate, OrderPaid)
                          VALUES(@OrderDate, @OrderPaid);
                          SELECT * from dbo.Orders
                          WHERE OrderId = SCOPE_IDENTITY();";


            using (var connection = this.DbConnectionFactory.Connection())
            {
                 return await connection.QueryFirstOrDefaultAsync<Order>(query, new {order.OrderDate, order.OrderPaid });
            }

        }
        
    }
}