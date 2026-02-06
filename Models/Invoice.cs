namespace InvoiceManagementAPI.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Status { get; set; } = "Draft"; // Draft / Paid / Cancelled
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}