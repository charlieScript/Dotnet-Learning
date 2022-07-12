using Catalog.Entities;

namespace Catalog.Repositories
{
  public class ItemRepo : IItemInterface
  {
    private readonly List<Item> items = new()
        {
            new Item { Id= Guid.NewGuid(), name = "charles", price = 50 },
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
      Console.WriteLine(items[3]);
    }

    public void UpdateItem(Item _item)
    {
      var index = items.Find(i => i.Id == _item.Id);
      int newIndex = Convert.ToInt32(index);
      items[newIndex] = _item;
    }

    public void DeleteItem(Guid id)
    {
      var index = items.FindIndex(existingItem => existingItem.Id == id);
      items.RemoveAt(index);
    }
  }
}