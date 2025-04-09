using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp2.Models;
using SQLite;

namespace MauiApp2.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;

        public async Task InitAsync() 
        { 
            if(_database != null) return;
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "bookstore.db3");
            Debug.WriteLine($"DB PATH: {dbPath}");

            _database = new SQLiteAsyncConnection(dbPath);
            await _database.CreateTableAsync<User>();
            await _database.CreateTableAsync<Book>();
        }

        public Task<List<User>> GetUsersAsync() => _database.Table<User>().ToListAsync();
        public Task <User> GetUserByCredentialAsync(string userbane, string password) => _database.Table<User>().FirstOrDefaultAsync(
            u => u.Username == userbane && u.Password == password);
        public Task<int> AddUserAsync (User user) => _database.InsertAsync(user);
        public Task<List<Book>> GetBooksAsync() => _database.Table<Book>().ToListAsync();
        public Task<int> AddBookAsync(Book book) => _database.InsertAsync(book);
    }
}
