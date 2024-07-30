using Microsoft.EntityFrameworkCore;
using System.Text.Json;

public static class DbInitializer
{
    public static void Initialize(ShoppingListDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.Categories.Any())
        {
            return;
        }

        var categories = new List<Category>
        {
            new Category { Id = Guid.NewGuid(), Name = "מוצרי ניקיון" },
            new Category { Id = Guid.NewGuid(), Name = "גבינות" },
            new Category { Id = Guid.NewGuid(), Name = "ירקות ופירות" },
            new Category { Id = Guid.NewGuid(), Name = "בשר ודגים" },
            new Category { Id = Guid.NewGuid(), Name = "מאפים" }
        };

        context.Categories.AddRange(categories);
        context.SaveChanges();
    }
}