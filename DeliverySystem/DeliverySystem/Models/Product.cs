using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DeliverySystem.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }

    public int CategoryId { get; set; }

    // --- O ESCUDO MÁGICO ESTÁ AQUI ---
    // Ele manda o C# parar de exigir a Categoria inteira na hora de salvar
    [ValidateNever]
    public Category? Category { get; set; }

    [Column(TypeName = "nvarchar(max)")]
    public string? PhotoUrl { get; set; }

    public decimal CostPrice { get; set; }
    public int StockQuantity { get; set; }
}