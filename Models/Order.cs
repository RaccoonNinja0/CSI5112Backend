namespace csi5112service.models;

public class Order{
    public string OrderId{get; set;}

    public string UserId{get; set;}

    public string OrderDate{get; set;}

    public double TotalPrice{get; set;}

    public string OrderAddress{get; set;}

    public Order(string OrderId, string UserId, string OrderDate, double TotalPrice, string OrderAddress){
        this.OrderId = OrderId;
        this.UserId = UserId;
        this.OrderDate = OrderDate;
        this.TotalPrice = TotalPrice;
        this.OrderAddress = OrderAddress;
    }
}