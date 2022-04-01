using csi5112service.models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace csi5112service.services;
public class ChatboxService {
    private readonly IMongoCollection<Chatbox> _chatboxes;

	// public ChatboxService(){}
    public ChatboxService(IOptions<ShopDatabaseSettings> shopDatabaseSettings) {
        var settings = MongoClientSettings.FromConnectionString(shopDatabaseSettings.Value.ConnectionString);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
        var database = client.GetDatabase(shopDatabaseSettings.Value.DatabaseName);
        _chatboxes = database.GetCollection<Chatbox>(shopDatabaseSettings.Value.ChatboxCollectionName);
    }

	public async Task CreateAsync(Chatbox post) {
		// Chatbox.Add(post);
        post.Id = null; // will be set by Mongo
        await _chatboxes.InsertOneAsync(post);
	}

	public async Task<List<Chatbox>> GetAsync(){
		// return Chatbox;
        return await _chatboxes.Find(_ => true).ToListAsync();
	}

	public async Task<Chatbox> GetAsync(string Id){
    //    return Chatbox.Find(x => x.PostId == PostId);
        return await _chatboxes.Find<Chatbox>(chatbox => chatbox.Id == Id).FirstOrDefaultAsync(); 
    }

	public async Task<bool> UpdateAsync(Chatbox updatedChatbox) { 
        ReplaceOneResult r = await _chatboxes.ReplaceOneAsync(chatbox => chatbox.Id == updatedChatbox.Id, updatedChatbox);
        return r.IsModifiedCountAvailable && r.ModifiedCount == 1;
    }

	public async Task<bool> DeleteAsync(string Id) {
        DeleteResult r = await _chatboxes.DeleteOneAsync(chatbox => chatbox.Id == Id);
        return r.DeletedCount == 1;
    }
}