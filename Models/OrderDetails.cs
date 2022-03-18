namespace csi5112service.models;
public class OrderDetails{
	public string OrderId { get; set; }
	public string ProductId { get; set; }
	public double UnitPrice { get; set; }
	public int Quantity { get; set; }

	public OrderDetails (string OrderId, string ProductId, double UnitPrice, int Quantity){
		this.OrderId = OrderId;
		this.ProductId = ProductId;
		this.UnitPrice = UnitPrice;
		this.Quantity = Quantity;
	}
}