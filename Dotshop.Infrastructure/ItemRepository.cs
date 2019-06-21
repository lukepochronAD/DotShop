using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using Dotshop.Core;
using Dotshop.Core.Interfaces;
using Dotshop.Core.Models;

namespace Dotshop.Infrastructure
{
    class ItemRepository : IItemRepository
    {
        private SqlConnection dbconnection;

        public ItemRepository(IConnectionFactory _dbconnection)
        {
            this.dbconnection = _dbconnection.Connection();

        }

        public IEnumerable<Item> GetAllItems()
        {

            List<Item> allItems = new List<Item>();

            dbconnection.Open();
            using(SqlCommand query = new SqlCommand("SELECT * FROM dbo.Items;", this.dbconnection))
            {
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    int itemid = reader.GetInt32(0);
                    string itemname = reader.GetString(1);
                    string itemdescription = reader.GetString(2);
                    float itemprice = reader.GetFloat(3);

                    allItems.Add(new Item() { ItemId = itemid, ItemName = itemname, ItemDescription = itemdescription, ItemPrice = itemprice});

                }
            }
            return allItems;

        }
    }
}
