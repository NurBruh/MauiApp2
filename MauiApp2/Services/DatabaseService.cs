using MauiApp2.Models;
using Microsoft.EntityFrameworkCore;
using MauiApp2.Helpers;



namespace MauiApp2.Services
{
    public class DatabaseService
    {
        private readonly MySqlDbContext _context;

        public DatabaseService()
        {
            _context = new MySqlDbContext();
            _context.Database.Migrate();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByCredentialAsync(string username, string password)
        {
            var hashedPassword = PasswordHelper.HashPassword(password);
            return await _context.Users.FirstOrDefaultAsync(
                u => u.Username == username && u.Password == hashedPassword);
        }

        public async Task<int> AddUserAsync(User user)
        {
            user.Password = PasswordHelper.HashPassword(user.Password); // Хэшируем перед сохранением
            _context.Users.Add(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<int> AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            return await _context.SaveChangesAsync();
        }
    }
}
