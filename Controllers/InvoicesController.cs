using InvoiceManagementAPI.Models;
using InvoiceManagementAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly InvoiceService _service;

        public InvoicesController(InvoiceService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Invoice invoice)
        {
            var result = await _service.CreateInvoice(invoice);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var invoices = await _service.GetAllInvoices();
            return Ok(invoices);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var invoice = await _service.GetInvoiceById(id);
            if (invoice == null) return NotFound();
            return Ok(invoice);
        }

        [HttpPut("{id}")] // We add {id} to the URL path
        public async Task<IActionResult> Update(int id, Invoice invoice)
        {
            // Safety check: ensure the ID in URL matches the ID in the data body
            if (id != invoice.InvoiceId)
            {
                return BadRequest("ID mismatch");
            }

            var result = await _service.UpdateInvoice(invoice);
            return Ok(new { message = "Update successful", rowsAffected = result });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteInvoice(id);
            return Ok();
        }
    }
}