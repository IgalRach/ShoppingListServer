using System.ComponentModel.DataAnnotations;

public class Product
{
    public Guid Id { get; set; }
    [Required]
    public required string Name {  get; set; }
    public  int Quantity { get; set; }
    [Required]
    public string Category { get; set; }
}
