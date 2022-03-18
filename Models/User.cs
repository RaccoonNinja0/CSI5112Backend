namespace csi5112service.models;
public class User{
public string  UserId {get; set;}
  public string  Password {get; set;}
  public string  UserName {get; set;}
  public string  PhoneNumber {get; set;}
  public string  Address {get; set;}
  
  public User(string UserId, string Password, string UserName, string PhoneNumber, string Address){
      this.UserId = UserId;
      this.Password = Password;
      this.UserName= UserName;
      this.PhoneNumber = PhoneNumber;
      this.Address = Address;
  }
}
 
 

  

 