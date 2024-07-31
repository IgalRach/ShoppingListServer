using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ShoppingListController : ControllerBase
{
    private readonly ShoppingListDbContext _context;
    public ShoppingListController(ShoppingListDbContext context)
    {
        _context = context;
    }

    [HttpGet("categories")]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
    {
        return await _context.Categories.ToListAsync();
    }

    [HttpGet("categories/{name}")]
    public async Task<ActionResult<Category>> GetShoppingListById(string name)
    {
        var categories = await _context.Categories
            .Include(c => c.Name)
            .FirstOrDefaultAsync(sl => sl.Name.Equals(name));

        if (categories == null)
        {
            return NotFound();
        }

        return categories;
    }

    [HttpPost]
    public async Task<ActionResult<ShoppingList>> CreateShoppingList([FromBody] ShoppingList shoppingList)
    {
        if (shoppingList == null)
        {
            return BadRequest("Invalid shopping list data.");
        }

        _context.ShoppingLists.Add(shoppingList);
        _context.Products.AddRange(shoppingList.Products);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetShoppingListById), new { id = shoppingList.Id }, shoppingList);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ShoppingList>> GetShoppingListById(Guid id)
    {
        var shoppingList = await _context.ShoppingLists
            .Include(sl => sl.Products)
            .FirstOrDefaultAsync(sl => sl.Id == id);

        if (shoppingList == null)
        {
            return NotFound();
        }

        return shoppingList;
    }
}