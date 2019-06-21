using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Dotshop.Core;
using Dotshop.Core.Interfaces;
using Dotshop.Core.Models;

namespace Dotshop.Infrastructure
{
    public class ItemRepository : IItemRepository
    {
        private IConnectionFactory<SqlConnection> DbConnectionFactory { get; }
        public ItemRepository(IConnectionFactory<SqlConnection> dbConnectionFactory)
        {
            this.DbConnectionFactory = dbConnectionFactory;
        }

        public async Task<Item> CreateNew(Item item)
        {

            var query = @"INSERT INTO dbo.Items (ItemName, ItemDescription, Price)
                          VALUES(@ItemName, @ItemDescription, @Price);
                          SELECT * from dbo.Items
                          WHERE ItemId = SCOPE_IDENTITY();";


            using (var connection = this.DbConnectionFactory.Connection())
            {
                return await connection.QueryFirstOrDefaultAsync<Item>(query, new { item.ItemName, item.ItemDescription, Price = item.ItemPrice});
            }

        }

        public async Task<IEnumerable<Item>> GetAllItems()
        {

            List<Item> allItems = new List<Item>();
            using (SqlConnection conn = this.DbConnectionFactory.Connection())
            {


                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Items;", conn))
                {
                    conn.Open();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        int itemid = reader.GetInt32(0);
                        string itemname = reader.GetString(1);
                        string itemdescription = reader.GetString(2);
                        double itemprice = reader.GetDouble(3);

                        allItems.Add(new Item() { ItemId = itemid, ItemName = itemname, ItemDescription = itemdescription, ItemPrice = itemprice });

                    }
                }
            }
            return allItems;
        }

        public async Task<Item> GetById(int ItemId)
        {

            var query = $@"SELECT * FROM dbo.Items WHERE ItemId = @ItemId ";

            using (var connection = this.DbConnectionFactory.Connection())
            {
                return await connection.QueryFirstOrDefaultAsync<Item>(query, new { ItemId});
            }


        }

        public async Task<bool> EditItem(Item item)
        {
            if (item == null)
            {
                return false;
            }


            var query = @"UPDATE dbo.Items
                          SET ItemName = @ItemName, ItemDescription = @ItemDescription, Price = @ItemPrice
                          WHERE ItemId = @ItemId;";


            using (var connection = this.DbConnectionFactory.Connection())
            {
                var rowsReturned = (await connection.ExecuteAsync(query, new { item.ItemId, item.ItemName, item.ItemDescription, item.ItemPrice }));
                return (rowsReturned > 0);
            }


        }


        public async Task<bool> Delete(int ItemId)
        {

            var deleteItems = @"DELETE FROM dbo.Items
                                 WHERE ItemId = @ItemId;";


            using (var connection = this.DbConnectionFactory.Connection())
            {
                var result = (await connection.ExecuteAsync(deleteItems, new { ItemId }));
                return (result > 0);
            }


        }


    }
}

