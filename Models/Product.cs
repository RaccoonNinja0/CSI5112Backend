
namespace csi5112service.models;

public class Product{
    public string ProductId{get; set;}
    public string ProductName{get; set;}
    public string Category{get; set;}
    public double Price{get; set;}
    public int Inventory{get; set;}
    public int Quantity{get; set;}
    public string Description{get; set;}
    public string Image{get; set;}
    public Product(string ProductId, string ProductName, string Category, double Price, int Inventory,  string Description, string Image, int Quantity = 1){
        this.ProductId = ProductId;
        this.ProductName = ProductName;
        this.Category = Category;
        this.Price = Price;
        this.Inventory = Inventory;
        this.Description = Description;
        this.Image = Image;
        this.Quantity = Quantity;
    }
}