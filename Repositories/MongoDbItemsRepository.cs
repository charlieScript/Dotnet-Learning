
using Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Repositories
{
  public class MongoDbItemsRepository : IItemInterface
  { 
    private const string databaseName = "catalog";
    private const string collectionName = "items";
    private readonly IMongoCollection<Item> itemsCollection;
    private readonly FilterDefinitionBuilder<Item> filterBulider = Builders<Item>.Filter;
    public MongoDbItemsRepository(IMongoClient mongoClient)
    {
      IMongoDatabase database = mongoClient.GetDatabase(databaseName);
      itemsCollection = database.GetCollection<Item>(collectionName);
    }
    public void CreateItem(Item _item)
    { 
      itemsCollection.InsertOne(_item);
    }

    public void DeleteItem(Guid id)
    { 
      itemsCollection.DeleteOne(x => x.Id == id);
    }

    public Item GetItem(Guid id)
    { 
      var filter = filterBulider.Eq(item => item.Id, id);
      return itemsCollection.Find(x => x.Id == id).FirstOrDefault();
      throw new NotImplementedException();
    }

    public IEnumerable<Item> GetItems()
    {  
      return itemsCollection.Find(new BsonDocument()).ToList();
      throw new NotImplementedException();
    }

    public void UpdateItem(Item _item)
    { 
      itemsCollection.FindOneAndReplace(x => x.Id == _item.Id, _item);
    }
  }
}