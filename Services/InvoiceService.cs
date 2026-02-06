using InvoiceManagementAPI.Models;
using InvoiceManagementAPI.Repositories;

namespace InvoiceManagementAPI.Services
{
    public class InvoiceService
    {
        private readonly InvoiceRepository _repository;

        public InvoiceService(InvoiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateInvoice(Invoice invoice)
        {
            // Business logic can be added here (e.g. validating amount)
            return await _repository.CreateInvoice(invoice);
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoices()
        {
            return await _repository.GetAllInvoices();
        }
        public async Task<Invoice> GetInvoiceById(int id) => await _repository.GetInvoiceById(id);

        public async Task<int> UpdateInvoice(Invoice invoice)
        {
            var result = await _repository.UpdateInvoice(invoice);

            // Check if the status is "Paid" and update was successful
            if (result > 0 && invoice.Status == "Paid")
            {
                // Trigger background task without waiting (Fire and forget)
                _ = Task.Run(async () =>
                {
                    await Task.Delay(2000); // Simulate some work (2 seconds)
                    Console.WriteLine($"[LOG]: Payment confirmed for Invoice Number: {invoice.InvoiceNumber} at {DateTime.Now}");
                });
            }

            return result;
        }

        public async Task<int> DeleteInvoice(int id) => await _repository.DeleteInvoice(id);

    }
}