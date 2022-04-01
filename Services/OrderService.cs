using csi5112service.models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace csi5112service.services;

public class OrderService{
    private readonly IMongoCollection<Order> _orders;

    public OrderService(IOptions<ShopDatabaseSettings> shopDatabaseSettings) {
        var settings = MongoClientSettings.FromConnectionString(shopDatabaseSettings.Value.ConnectionString);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
        var database = client.GetDatabase(shopDatabaseSettings.Value.DatabaseName);
        _orders = database.GetCollection<Order>(shopDatabaseSettings.Value.OrderCollectionName);
    }

    public async Task CreateAsync(Order newOrder){
        // orders.Add(newOrder);
        newOrder.Id = null; // will be set by Mongo
        await _orders.InsertOneAsync(newOrder);
    }

    public async Task<List<Order>> GetAsync(){
        // return orders;
        return await _orders.Find(_ => true).ToListAsync();
    }

    public async Task<Order> GetAsync(string Id){
        // return orders.Find(x => x.OrderId == OrderId);
        return await _orders.Find<Order>(order => order.Id == Id).FirstOrDefaultAsync(); 

    }

    public async Task<bool> UpdateAsync(String OrderId, Order UpdatedOrder){
        ReplaceOneResult r = await _orders.ReplaceOneAsync(order => order.Id == UpdatedOrder.Id, UpdatedOrder);
        return r.IsModifiedCountAvailable && r.ModifiedCount == 1;
    }

    public async Task<bool> DeleteAsync(string Id){
        DeleteResult r = await _orders.DeleteOneAsync(order => order.Id == Id);
        return r.DeletedCount == 1;
    }
}