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

            var allOrders = new List<Order>();

            using (SqlConnection conn = this.dbconnectionfactory.Connection())
            {

                var query = @"SELECT o.OrderId, o.OrderDate, o.OrderPaid, SUM(i.Price) AS 'TotalDue' FROM dbo.Orders o
                                JOIN dbo.OrderItems oi
                                ON oi.OrderId = o.OrderId
                                join DBO.Items i
                                ON oi.ItemId = i.ItemId
                                GROUP BY
                                o.OrderId, o.OrderDate, o.OrderPaid; ";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        int orderid = reader.GetInt32(0);
                        var datetime = reader.GetDateTime(1);
                        var orderpaid = reader.GetBoolean(2);
                        double totaldue = reader.GetDouble(3);

                        allOrders.Add(new Order() { OrderId = orderid, OrderDate = datetime, OrderPaid = orderpaid, TotalDue = totaldue });
                    }
                }


                return allOrders;
            }
        }


        public Task<IEnumerable<Order>> GetAll()
        {
            throw new System.NotImplementedException();
        }



        public async Task<Order> GetById(int id)
        {

            using (SqlConnection conn = this.dbconnectionfactory.Connection())
            {

                var query = $@"SELECT o.OrderId, o.OrderDate, o.OrderPaid, SUM(i.Price) AS 'TotalDue' FROM dbo.Orders o
                            JOIN dbo.OrderItems oi
                            ON oi.OrderId = o.OrderId
                            join DBO.Items i
                            ON  oi.ItemId = i.ItemId
                            WHERE o.OrderId = {id}
                            GROUP BY
                            o.OrderId, o.OrderDate, o.OrderPaid; ";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        int orderid = reader.GetInt32(0);
                        var datetime = reader.GetDateTime(1);
                        var orderpaid = reader.GetBoolean(2);
                        double totaldue = reader.GetDouble(3);

                        allOrders.Add(new Order() { OrderId = orderid, OrderDate = datetime, OrderPaid = orderpaid, TotalDue = totaldue });
                    }
                }


                return allOrders;

            }
    }
    }