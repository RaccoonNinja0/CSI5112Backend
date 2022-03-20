namespace csi5112service.models;

public class Chatbox{
    public string PostId{get; set;}
    public string Question{get; set;}
    public string Reply{get; set;}
    // public List<string> ListOfReplies = {get; set;}
    public string PostDate{get; set;}
    public Chatbox(string PostId, string Question, string Reply, string PostDate){
        this.PostId = PostId;
        this.Question = Question;
        this.Reply = Reply;
        this.PostDate = PostDate;
    }
}
