using Catalog.Entities;

namespace Catalog.Repositories
{
  public interface IItemInterface
  {
    Item GetItem(Guid id);
    IEnumerable<Item> GetItems();
    void CreateItem(Item _item);
    void UpdateItem(Item _item);
    void DeleteItem(Guid id);

  }
}