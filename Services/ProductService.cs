using csi5112service.models;

namespace csi5112service.services;
public class ProductService{
    private List<Product> products = new List<Product>(){

        new Product("p0001", "Orange", "Fruit", 0.99, 1, "An orange is a fruit of various citrus species in the family Rutaceae; it primarily refers to Citrus × sinensis, which is also called sweet orange, to distinguish it from the related Citrus × aurantium, referred to as bitter orange.", 
                    "https://cdn.pixabay.com/photo/2017/01/20/15/06/oranges-1995056__340.jpg"),
        new Product("p0002", "Coca-Cola", "Beverage", 1.99, 1, "Coca-Cola, a sweetened carbonated beverage that is a cultural institution in the United States and a global symbol of American tastes.", 
                    "https://cdn.pixabay.com/photo/2015/01/08/04/18/box-592367__480.jpg"),
        new Product("p0003", "Ginger", "Vegetable", 2.49, 1, "The ginger plant has a thick, branched rhizome (underground stem) with a brown outer layer and yellow centre that has a spicy, citrusy aroma.", 
                    "https://cdn.pixabay.com/photo/2016/10/13/15/50/ginger-1738098__340.jpg"),
        new Product("p0004", "Strawberry", "Fruit", 0.79, 1, "A strawberry is both a low-growing, flowering plant and also the name of the fruit that it produces. Strawberries are soft, sweet, bright red berries.", 
                    "https://cdn.pixabay.com/photo/2018/04/29/11/54/strawberries-3359755_1280.jpg"),
        new Product("p0005", "Broccoli", "Vegetable", 3.29, 1, "Broccoli has large flower heads, usually dark green, arranged in a tree-like structure branching out from a thick stalk which is usually light green.", 
                    "https://cdn.pixabay.com/photo/2016/03/05/22/00/broccoli-1239149_1280.jpg"),
        new Product("p0006", "Potato", "Vegetable", 2.29, 1, "The potato is one of some 150 tuber-bearing species of the genus Solanum (a tuber is the swollen end of an underground stem). ", 
                    "https://cdn.pixabay.com/photo/2016/08/11/08/43/potatoes-1585060_1280.jpg"),
        new Product("p0007", "Pear", "Fruit", 0.59, 1, "A pear is a sweet, juicy fruit which is narrow near its stalk, and wider and rounded at the bottom.", 
                    "https://cdn.pixabay.com/photo/2014/08/18/23/11/bell-peppers-421087_1280.jpg"),
        new Product("p0008", "Pepper", "Vegetable", 2.19, 1, "The pepper is a vegetable with variable shape, size and colour. It can be green, red, yellow, orange and even black.", 
                    "https://cdn.pixabay.com/photo/2016/07/22/09/59/fruits-1534494_1280.jpg"),
        new Product("p0009", "Apple", "Fruit", 1.29, 1, "The apple is a pome (fleshy) fruit, in which the ripened ovary and surrounding tissue both become fleshy and edible.", 
                    "https://cdn.pixabay.com/photo/2017/09/26/13/42/apple-2788662_1280.jpg"),
        new Product("p0010", "Blueberry", "Fruit", 4.49, 1, "Blueberries are small round berries about 0.2 to 0.6 inches across. Their color can range from blue to purple.", 
                    "https://cdn.pixabay.com/photo/2018/06/07/16/38/blueberries-3460423_1280.jpg"),
        new Product("p0011", "Starbucks Coffee", "Beverage", 7.49, 1, "Coffees with high acidity are described as bright, tangy and crisp with a clean finish. Coffees with low acidity feel smooth in your mouth and tend to remain longer.", 
                    "https://cdn.pixabay.com/photo/2017/05/26/15/02/starbucks-2346226_1280.jpg"),
        new Product("p0012", "Pepsi Coke", "Beverage", 1.49, 1, "Pepsi is also characterized by a citrusy flavor burst, unlike the more raisiny-vanilla taste of Coke.", 
                    "https://cdn.pixabay.com/photo/2020/09/18/23/17/pepsi-5583105_1280.jpg"),
        new Product("p0013", "Lemonade", "Beverage", 3.19, 1, "Lemonade is a sweetened lemon-flavored beverage. There are varieties of lemonade found throughout the world.", 
                    "https://cdn.pixabay.com/photo/2018/02/23/09/43/juice-3175117_1280.jpg"),
        new Product("p0014", "Beer", "Beverage", 7.29, 1,"Beer is an alcoholic beverage produced by extracting raw materials with water, boiling (usually with hops), and fermenting.", 
                    "https://cdn.pixabay.com/photo/2014/08/10/18/06/beers-414914_1280.jpg"),
        new Product("p0015", "Carrot", "Vegetable", 3.29, 1, "Carrot, (Daucus carota), herbaceous, generally biennial plant of the Apiaceae family that produces an edible taproot.", 
                    "https://cdn.pixabay.com/photo/2017/06/09/16/39/carrots-2387394_1280.jpg"),
        new Product("p0016", "Avocado", "Fruit", 5.59, 1, "Avocado fruits have greenish or yellowish flesh with a buttery consistency and a rich, nutty flavour. They are often eaten in salads, and in many parts of the world they are eaten as a dessert.", 
                    "https://cdn.pixabay.com/photo/2015/08/10/12/02/avocados-882635_1280.jpg")
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
    
    public async Task<bool> DeleteByCategoryAsync(string[] productIds) {
        bool deleted = false;
        // int index = products.FindIndex(x => x.ProductId == ProductId);
        foreach(string i in productIds){
            int index = products.FindIndex(x => x.ProductId == i);
            if (index != -1) {
                products.RemoveAt(index);
                deleted = true;
            }else{
                return deleted;
            }
        }
        return deleted;
    }
}