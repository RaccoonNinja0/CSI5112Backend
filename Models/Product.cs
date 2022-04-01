using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace csi5112service.models;
public class Product {
    [BsonId][BsonRepresentation(BsonType.ObjectId)][JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("productName")]
    public string ProductName{get; set;}

    [JsonPropertyName("category")]
    public string Category{get; set;}

    [JsonPropertyName("price")]
    public double Price{get; set;}

    [JsonPropertyName("inventory")]
    public int Inventory{get; set;}

    [JsonPropertyName("quantity")]

    public int Quantity{get; set;}

    [JsonPropertyName("description")]
    public string Description{get; set;}

    [JsonPropertyName("image")]
    public string Image{get; set;}
    public Product(string Id, string ProductName, string Category, double Price, int Inventory,  string Description, string Image, int Quantity = 1){
        this.Id = Id;
        this.ProductName = ProductName;
        this.Category = Category;
        this.Price = Price;
        this.Inventory = Inventory;
        this.Description = Description;
        this.Image = Image;
        this.Quantity = Quantity;
    }
}