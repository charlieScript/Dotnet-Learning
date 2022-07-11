using Catalog.Entities;

namespace Catalog.Dtos 
{
  public class ItemDto
  {
    public Guid Id { get; init; }

    public string? name { get; init; }

    public decimal price { get; init; }

    public DateTimeOffset CreatedDate { get; init; }

    public ItemDto() { }
    public ItemDto(Item todoItem) =>
    (Id, name, price, CreatedDate) = (todoItem.Id, todoItem.name, todoItem.price, todoItem.CreatedDate);

    public static ItemDto AsDto(Item _item) {
      return new ItemDto{
        Id = _item.Id,
        name = _item.name,
        price= _item.price
      };
    }
  }
}