using GestStock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySqlConnector;

namespace GestStock.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items = new List<Item>();
        readonly List<Item> borrowedItems = new List<Item>();


        private static string server = "192.168.1.2";
        private static string port = "3306";
        private static string user = "stock_user";
        private static string password = "stock_password";
        private static string database = "bd_stock";

        public static string ConnectionString = "server=" + server + ";port=" + port + ";user=" + user + ";password=" + password + ";database=" + database + ";";
        public MockDataStore()
        {

        }

        public async Task<bool> GetDbBorrowedItems()
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM v_art_borrow";
            using (MySqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    borrowedItems.Add(new Item { Id = rd.GetInt32(0).ToString(), Text = rd.GetString(2), Description = rd.GetString(4), Borrowed = true });
                }
            }

            return await Task.FromResult(true);
        }
        public async Task<bool> GetDbItems()
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM t_products";
            using (MySqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    items.Add(new Item { Id = rd.GetInt32(0).ToString(), Text = rd.GetString(1), Description = rd.GetString(2), Borrowed = false });
                }
            }

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
        public async Task<IEnumerable<Item>> GetBorrowedItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(borrowedItems);
        }
    }
}