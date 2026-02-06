using Dapper;
using InvoiceManagementAPI.Models;
using System.Data;

namespace InvoiceManagementAPI.Repositories
{
    public class InvoiceRepository
    {
        private readonly DapperContext _context;

        public InvoiceRepository(DapperContext context)
        {
            _context = context;
        }

        // 1. Create Invoice (Database ekata danna)
        public async Task<int> CreateInvoice(Invoice invoice)
        {
            var query = "INSERT INTO Invoices (InvoiceNumber, CustomerName, Amount, Status, CreatedDate) VALUES (@InvoiceNumber, @CustomerName, @Amount, @Status, @CreatedDate)";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, invoice);
            }
        }

        // 2. Get All Invoices (Okkoma ganna)
        public async Task<IEnumerable<Invoice>> GetAllInvoices()
        {
            var query = "SELECT * FROM Invoices";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Invoice>(query);
            }
        }
        // 3. Get Invoice by ID
        public async Task<Invoice> GetInvoiceById(int id)
        {
            var query = "SELECT * FROM Invoices WHERE InvoiceId = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Invoice>(query, new { Id = id });
            }
        }

        // 4. Update Invoice
        public async Task<int> UpdateInvoice(Invoice invoice)
        {
            var query = @"UPDATE Invoices 
                  SET InvoiceNumber = @InvoiceNumber, 
                      CustomerName = @CustomerName, 
                      Amount = @Amount, 
                      Status = @Status 
                  WHERE InvoiceId = @InvoiceId";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, invoice);
            }
        }

        // 5. Delete Invoice
        public async Task<int> DeleteInvoice(int id)
        {
            var query = "DELETE FROM Invoices WHERE InvoiceId = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}