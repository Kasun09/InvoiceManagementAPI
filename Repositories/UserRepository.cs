using Dapper;
using InvoiceManagementAPI.Models;
using System.Data;

namespace InvoiceManagementAPI.Repositories
{
    public class UserRepository
    {
        private readonly DapperContext _context;

        public UserRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateUser(User user)
        {
            var query = "INSERT INTO Users (Name, Email, PasswordHash, Role, CreatedAt) VALUES (@Name, @Email, @PasswordHash, @Role, @CreatedAt)";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, user);
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var query = "SELECT * FROM Users WHERE Email = @Email";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<User>(query, new { Email = email });
            }
        }
    }
}