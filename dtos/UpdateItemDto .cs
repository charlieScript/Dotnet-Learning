using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
  public class UpdateItemDto  {
    [Required]
    public string? name { get; init; }
    [Required]
    [Range(0, 100)]
    public decimal price { get; init; }
  }
}