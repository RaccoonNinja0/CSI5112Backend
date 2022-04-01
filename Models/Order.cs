namespace csi5112service.models;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


public class Order{
    // public string OrderId{get; set;}
    [BsonId][BsonRepresentation(BsonType.ObjectId)][JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("userId")]
    public string UserId{get; set;}

    [JsonPropertyName("orderDate")]
    public string OrderDate{get; set;}

    [JsonPropertyName("totalPrice")]

    public double TotalPrice{get; set;}

    [JsonPropertyName("orderAddress")]

    public string OrderAddress{get; set;}

    [JsonPropertyName("products")]

    public string Products{get; set;}

    [JsonPropertyName("unitPrice")]

    public string UnitPrice{get; set;}

    [JsonPropertyName("quantities")]

    public string Quantities{get; set;}

    public Order(string Id, string UserId, string OrderDate, double TotalPrice, string OrderAddress, string Products, string UnitPrice, string Quantities){
        this.Id = Id;
        this.UserId = UserId;
        this.OrderDate = OrderDate;
        this.TotalPrice = TotalPrice;
        this.OrderAddress = OrderAddress;
        this.Products = Products;
        this.UnitPrice = UnitPrice;
        this.Quantities = Quantities;
    }
}