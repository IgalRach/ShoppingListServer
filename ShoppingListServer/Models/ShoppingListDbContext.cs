using Microsoft.EntityFrameworkCore;

public class ShoppingListDbContext :DbContext
{
    public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options) : base(options) { }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; } 
    public DbSet<ShoppingList> ShoppingLists { get; set; }
}
