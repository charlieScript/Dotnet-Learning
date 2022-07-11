using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
  public class CreateItemDto  {
    [Required]
    public string? name { get; init; }
    [Required]
    [Range(0, 100)]
    public decimal price { get; init; }
  }
}