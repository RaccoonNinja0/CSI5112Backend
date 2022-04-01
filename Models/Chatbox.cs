namespace csi5112service.models;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Chatbox{
    [BsonId][BsonRepresentation(BsonType.ObjectId)][JsonPropertyName("id")]
    public string? Id { get; set; }
    // public string PostId{get; set;}

    [JsonPropertyName("question")]
    public string Question{get; set;}

    [JsonPropertyName("reply")]
    public string Reply{get; set;}
    // public List<string> ListOfReplies = {get; set;}

    [JsonPropertyName("postDate")]
    public string PostDate{get; set;}
    public Chatbox(string Id, string Question, string Reply, string PostDate){
        this.Id = Id;
        this.Question = Question;
        this.Reply = Reply;
        this.PostDate = PostDate;
    }
}