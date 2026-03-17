namespace DeliverySystem.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal TotalAmount { get; set; }
    public string OrderType { get; set; }
    public int? TableId { get; set; }
    public string Status { get; set; }

    // --- NOVOS CAMPOS DO CLIENTE ---
    public string? CustomerName { get; set; }
    public string? CustomerPhone { get; set; }
    public string? CustomerAddress { get; set; }
    public string? OrderDetails { get; set; } // Vai guardar "2x Pizza, 1x Bolo"
}