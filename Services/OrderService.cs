using csi5112service.models;

namespace csi5112service.services;

public class OrderServcie{
    //Data placeholder
    private List<Order> orders = new List<Order>(){
        new Order("o001", "u001", "01-Jan-2022", 34.99, "33-186 Stewart Street"),
        new Order("o002", "u002", "02-Feb-2022", 25.49, "1207-169 Lees Ave"),
        new Order("o003", "u003", "03-Mar-2022", 88.79, "1212-171 Lees Ave")
    };

    public OrderServcie(){
    }

    public async Task CreateAsync(Order newOrder){
        orders.Add(newOrder);
    }

    public async Task<List<Order>> GetAsync(){
        return orders;
    }

    public async Task<Order> GetAsync(string OrderId){
        return orders.Find(x => x.OrderId == OrderId);
    }

    public async Task<bool> UpdateAsync(String OrderId, Order UpdatedOrder){
        bool result = false;
        int index = orders.FindIndex(x => x.OrderId == OrderId);
        if (index != -1){
            UpdatedOrder.OrderId = OrderId;
            orders[index] = UpdatedOrder;
            result = true;
        }
        return result;
    }

    public async Task<bool> DeleteAsync(string OrderId){
        bool deleted = false;
        int index = orders.FindIndex(x => x.OrderId == OrderId);
        if (index != -1){
            orders.RemoveAt(index);
            deleted = true;
        }
        return deleted;
    }
}