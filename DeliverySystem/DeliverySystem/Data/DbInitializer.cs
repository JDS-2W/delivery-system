using DeliverySystem.Models;

namespace DeliverySystem.Data;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.Categories.Any()) return;
        var categorias = new Category[]
        {
    new Category { Name = "Pizzas 🍕", DisplayOrder = 1 },
    new Category { Name = "Lanches & Hambúrgueres 🍔", DisplayOrder = 2 },
    new Category { Name = "Porções & Pratos 🍟", DisplayOrder = 3 },
    new Category { Name = "Confeitaria & Doces 🎂", DisplayOrder = 4 },
    new Category { Name = "Bebidas & Drinks 🍹", DisplayOrder = 5 }
        };

        context.Categories.AddRange(categorias);
        context.SaveChanges();

        var produtos = new Product[]
        {
            new Product { Name = "Bolo de Pote Morango", Price = 12.00m, IsAvailable = true, CategoryId = categorias[0].Id },
            new Product { Name = "Torta Holandesa", Price = 15.00m, IsAvailable = true, CategoryId = categorias[1].Id }
        };

        context.Products.AddRange(produtos);
        context.SaveChanges();
    }
}