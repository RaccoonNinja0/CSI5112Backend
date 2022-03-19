namespace csi5112service.models;

public class Chatbox{
    public string PostId{get; set;}
    public string Question{get; set;}
    public string ListOfReplies{get; set;}
    // public List<string> ListOfReplies = {get; set;}
    public string PostDate{get; set;}
    public Chatbox(string PostId, string Question, string ListOfReplies, string PostDate){
        this.PostId = PostId;
        this.Question = Question;
        this.ListOfReplies = ListOfReplies;
        this.PostDate = PostDate;
    }
}