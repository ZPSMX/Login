using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public class Database // Cambia 'class' a 'public class'
    {
        private readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

        public Task<int> SaveUserAsync(User user)
        {
            return _database.InsertAsync(user);
        }

        public Task<User> GetUserAsync(string username)
        {
            return _database.Table<User>().Where(u => u.Username == username).FirstOrDefaultAsync();
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return _database.DeleteAsync(user);
        }
    }
}
