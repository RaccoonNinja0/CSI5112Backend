using csi5112service.models;

namespace csi5112service.services;
public class ProductService{
    private List<Product> products = new List<Product>(){
        new Product("U00001", "Coca-Cola", "Beverages", 3, 100),
        new Product("U00002", "Orange Juice", "Beverages", 5, 100),
        new Product("U00003", "Lemonade", "Beverages", 5, 100)
    };

    public ProductService(){

    }

    public async Task CreateAsync(Product product){
        products.Add(product);
    }

    public async Task<List<Product>> GetAsync(){
        return products;
    }

    public async Task<Product> GetAsync(string ProductId){
       return products.Find(x => x.ProductId == ProductId);
    }

    public async Task<bool> UpdateAsync(string ProductId, Product updatedProduct) {
        bool result = false;
        int index = products.FindIndex(x => x.ProductId == ProductId);
        if (index != -1) {
            updatedProduct.ProductId = ProductId;
            products[index] = updatedProduct;
            result = true;
        }
        return result;
    }

        public async Task<bool> DeleteAsync(string ProductId) {
        bool deleted = false;
        int index = products.FindIndex(x => x.ProductId == ProductId);
        if (index != -1) {
            products.RemoveAt(index);
            deleted = true;
        }
        return deleted;
    }
}