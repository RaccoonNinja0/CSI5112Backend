using csi5112service.models;

namespace csi5112service.services;
public class OrderDetailsService {
	private List<OrderDetails> orderDetailsList = new List<OrderDetails>(){
		new OrderDetails("1", "P011", 12.2, 20),
		new OrderDetails("1", "P021", 15.8, 10),
		new OrderDetails("2", "P092", 13.9, 40),
		new OrderDetails("2", "P032", 20.9, 40),
	};

	public OrderDetailsService(){}

	public async Task CreateAsync(OrderDetails od) {
		orderDetailsList.Add(od);
	}

	public async Task<List<OrderDetails>> GetAsync(){
		return orderDetailsList;
	}

	public async Task<OrderDetails> GetAsync(string OrderId){
       return orderDetailsList.Find(x => x.OrderId == OrderId);
    }

	public async Task<bool> UpdateAsync(string OrderId, OrderDetails updatedOrderDetails) {
        bool result = false;
        int index = orderDetailsList.FindIndex(x => x.OrderId == OrderId);
        if (index != -1) {
            updatedOrderDetails.OrderId = OrderId;
            orderDetailsList[index] = updatedOrderDetails;
            result = true;
        }
        return result;
    }

	public async Task<bool> DeleteAsync(string OrderId) {
        bool deleted = false;
        int index = orderDetailsList.FindIndex(x => x.OrderId == OrderId);
        if (index != -1) {
            orderDetailsList.RemoveAt(index);
            deleted = true;
        }
        return deleted;
    }
}