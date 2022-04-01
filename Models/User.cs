namespace csi5112service.models;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class User{
// public string  UserId {get; set;}
  [BsonId][BsonRepresentation(BsonType.ObjectId)][JsonPropertyName("id")]
  public string? Id { get; set; } 

  [JsonPropertyName("password")]

  public string  Password {get; set;}

  [JsonPropertyName("userName")]
  public string  UserName {get; set;}

  [JsonPropertyName("phoneNumber")]
  public string  PhoneNumber {get; set;}

  [JsonPropertyName("address")]
  public string  Address {get; set;}
  
  public User(string Id, string Password, string UserName, string PhoneNumber, string Address){
      this.Id = Id;
      this.Password = Password;
      this.UserName= UserName;
      this.PhoneNumber = PhoneNumber;
      this.Address = Address;
  }
}
 
 

  

 