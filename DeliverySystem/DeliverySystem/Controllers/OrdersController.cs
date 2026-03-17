using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeliverySystem.Data;
using DeliverySystem.Models;

namespace DeliverySystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrdersController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Lista todos os pedidos (Para o painel Admin)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
        return await _context.Orders.OrderByDescending(o => o.CreatedAt).ToListAsync();
    }

    // POST: Salva um novo pedido no banco
    [HttpPost]
    public async Task<ActionResult<Order>> PostOrder(Order order)
    {
        order.CreatedAt = DateTime.Now;
        order.Status = "Pendente"; // Todo pedido nasce como pendente

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return Ok(order);
    }

    // PATCH: Muda o status (Ex: Pendente -> Finalizado)
    [HttpPatch("{id}/status")]
    public async Task<IActionResult> UpdateStatus(int id, [FromBody] string novoStatus)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null) return NotFound();

        order.Status = novoStatus;
        await _context.SaveChangesAsync();
        return NoContent();
    }
}