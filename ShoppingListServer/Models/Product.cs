using System.ComponentModel.DataAnnotations;

public class Product
{
    public Guid Id { get; set; }
    [Required]
    public required string Name {  get; set; }
    [Required]
    public Guid CategoryId { get; set; }
    [Required]
    public Category Category { get; set; }
}
