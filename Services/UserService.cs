using csi5112service.models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace csi5112service.services;


public class UserService{

    private readonly IMongoCollection<User> _users;

    public UserService(IOptions<ShopDatabaseSettings> shopDatabaseSettings) {
        var settings = MongoClientSettings.FromConnectionString(shopDatabaseSettings.Value.ConnectionString);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
        var database = client.GetDatabase(shopDatabaseSettings.Value.DatabaseName);
        _users = database.GetCollection<User>(shopDatabaseSettings.Value.UserCollectionName);
    }
   
   public async Task CreateAsync(User newUser){
    //    users.Add(newUser);
    newUser.Id = null; // will be set by Mongo
    await _users.InsertOneAsync(newUser);
   }


   public async Task<List<User>>GetAsync(){
    //    return users;
    return await _users.Find(_ => true).ToListAsync();
   }
   
   public async Task<User> GetAsync(string Id){
    //    return  users.Find(x => x.UserId == UserId);
    return await _users.Find<User>(user => user.Id == Id).FirstOrDefaultAsync(); 

   }

   public async Task<bool> UpdateAsync(string UserId, User updatedUser){ 
    ReplaceOneResult r = await _users.ReplaceOneAsync(user => user.Id == updatedUser.Id, updatedUser);
    return r.IsModifiedCountAvailable && r.ModifiedCount == 1;
   }


    public async Task<bool> DeleteAsync(string Id){
        DeleteResult r = await _users.DeleteOneAsync(user => user.Id == Id);
        return r.DeletedCount == 1;
    }
}




