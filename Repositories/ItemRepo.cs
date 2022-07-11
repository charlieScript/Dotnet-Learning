using Catalog.Entities;

namespace Catalog.Repositories
{
  public class ItemRepo : IItemInterface
  {
    private readonly List<Item> items = new()
        {
            new Item { Id= Guid.NewGuid(), name = "charles", price = 50, CreatedDate = DateTimeOffset.Now },
            new Item { Id= Guid.NewGuid(), name = "chigozie", price = 90, CreatedDate = DateTimeOffset.Now },new Item { Id= Guid.NewGuid(), name = "chi", price = 50, CreatedDate = DateTimeOffset.Now }
        };

    public IEnumerable<Item> GetItems()
    {
      return items;
    }

    public Item? GetItem(Guid id)
    {
      return items.Where(item => item.Id == id).SingleOrDefault();
    }

    public void CreateItem(Item _item)
    {
      items.Add(_item);
    }

    public void UpdateItem(Item _item)
    {
      var index = items.Find(i => i.Id == _item.Id);
      int newIndex = Convert.ToInt32(index);
      items[newIndex] = _item;
    }
  }
}