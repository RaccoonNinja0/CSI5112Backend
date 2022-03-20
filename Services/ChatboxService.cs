using csi5112service.models;

namespace csi5112service.services;
public class ChatboxService {
	private List<Chatbox> Chatbox = new List<Chatbox>(){
		new Chatbox("post001", "How can I track my order?", "You can track with your order number.", "01-Jan-2022"),
		new Chatbox("post002", "What is the phone number of customer service?", "", "02-March-2022"),
		new Chatbox("post003", "How long does the express mail usually arrive?", "It usually takes 5-7 business days.", "18-Feb-2022"),
		new Chatbox("post004", "Can I return or exchange this item?", "Please call 800-000-1234.", "23-Feb-2022"),
	};

	public ChatboxService(){}

	public async Task CreateAsync(Chatbox post) {
		Chatbox.Add(post);
	}

	public async Task<List<Chatbox>> GetAsync(){
		return Chatbox;
	}

	public async Task<Chatbox> GetAsync(string PostId){
       return Chatbox.Find(x => x.PostId == PostId);
    }

	public async Task<bool> UpdateAsync(string PostId, Chatbox updatedChatbox) {
        bool result = false;
        int index = Chatbox.FindIndex(x => x.PostId == PostId);
        if (index != -1) {
            updatedChatbox.PostId = PostId;
            Chatbox[index] = updatedChatbox;
            result = true;
        }
        return result;
    }

	public async Task<bool> DeleteAsync(string PostId) {
        bool deleted = false;
        int index = Chatbox.FindIndex(x => x.PostId == PostId);
        if (index != -1) {
            Chatbox.RemoveAt(index);
            deleted = true;
        }
        return deleted;
    }
}