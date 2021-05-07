using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace signalR.Models
{
    public class Message
    {
        public int id { get; set; }
        public string message { get; set; }
        public string sender { get; set; }
        public DateTime date { get; set; }

        public string JSONToString(Message message)
        {
            return JsonSerializer.Serialize(message);
        }
    }
}
