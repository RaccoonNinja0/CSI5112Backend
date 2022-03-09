using csi5112service.models;
namespace csi5112service.services;

public class UserService{
   // Data placeholder
    private List<User> users = new List<User>(){
       new User("U001","1234","sarah","343666","181 King Street"),
       new User("U002","2345","Jack","613666","18 Queen Street"),
       new User("U003","4567","Sherry","613555","11 Edward Street")
   };

   public UserService(){
   }
   
   public async Task CreateAsync(User newUser){
       users.Add(newUser);
   }


   public async Task<List<User>>GetAsync(){
       return users;
   }
   
   public async Task<User> GetAsync(string UserId){
       return  users.Find(x => x.UserId == UserId);
   }

   public async Task<bool> UpdateAsync(string UserId, User updatedUser){ 
       bool result = false;
       int index = users.FindIndex(x => x.UserId == UserId);
       if (index != -1){
           users[index] = updatedUser;
           result = true;
       }
       return result;
   }


    public async Task<bool> DeleteAsync(string UserId){
        bool deleted = false;
        int index = users.FindIndex(x => x.UserId == UserId);
        if (index != -1){
            users.RemoveAt(index);
            deleted = true;
        }
        return deleted;
    }
}




