using csi5112service.models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace csi5112service.services;

public class ProductService{
    private readonly IMongoCollection<Product> _products;
    // public ProductService(){}

    public ProductService(IOptions<ShopDatabaseSettings> shopDatabaseSettings) {
        var settings = MongoClientSettings.FromConnectionString(shopDatabaseSettings.Value.ConnectionString);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
        var database = client.GetDatabase(shopDatabaseSettings.Value.DatabaseName);
        _products = database.GetCollection<Product>(shopDatabaseSettings.Value.ProductCollectionName);
    }

    public async Task CreateAsync(Product product){
        // int .Equals..
        // products.Add(product);
        product.Id = null;
        await _products.InsertOneAsync(product);
    }

    public async Task<List<Product>> GetAsync(){
        // return products;
        return await _products.Find(_ => true).ToListAsync();
    }

    public async Task<Product> GetAsync(string Id){
    //    return products.Find(x => x.ProductId == ProductId);
        return await _products.Find<Product>(product => product.Id == Id).FirstOrDefaultAsync(); 

    }

    public async Task<bool> UpdateAsync(Product updatedProduct) {
        ReplaceOneResult r = await _products.ReplaceOneAsync(product => product.Id == updatedProduct.Id, updatedProduct);
        return r.IsModifiedCountAvailable && r.ModifiedCount == 1;
    }

        public async Task<bool> DeleteAsync(string Id) {
        DeleteResult r = await _products.DeleteOneAsync(product => product.Id == Id);
        return r.DeletedCount == 1;
    }
    
}