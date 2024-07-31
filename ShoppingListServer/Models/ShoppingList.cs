using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

[PrimaryKey("Id")]
public class ShoppingList
{
    [Key]
    public Guid Id { get; set; }
    public List<Product> Products { get; set; }
}