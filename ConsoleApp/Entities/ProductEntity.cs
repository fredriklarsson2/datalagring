using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Entities;

internal class ProductEntity
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public decimal Price { get; set; }

    // [ForeignKey(nameof(CategoryEntity))]
    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;
}

