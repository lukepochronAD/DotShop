using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dotshop.Core;
using Dotshop.Core.Interfaces;
using Dotshop.Core.Models;

namespace Dotshop.Infrastructure
{
    public class ItemRepository : IItemRepository
    {
        private IConnectionFactory<SqlConnection> dbconnectionfactory { get; }
        public ItemRepository(IConnectionFactory<SqlConnection> dbConnectionFactory)
        {
            this.dbconnectionfactory = dbConnectionFactory;
        }


        public async Task<IEnumerable<Item>> GetAllItems()
        {

            List<Item> allItems = new List<Item>();
            using (SqlConnection conn = this.dbconnectionfactory.Connection())
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


    }
}

