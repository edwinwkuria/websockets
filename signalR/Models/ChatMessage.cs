using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace signalR.Models
{
    public class ChatMessage
    {
        public int id { get; set; }
        public int senderId { get; set; }
        public string sender { get; set; }
        public int receiverId { get; set; }
        public string receiver { get; set; }
        public string message { get; set; }
        public DateTime? date { get; set; }
        public string JSONToString(ChatMessage chatMessage)
        {
            return JsonSerializer.Serialize(chatMessage);
        }
    }
}
