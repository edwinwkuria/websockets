using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using signalR.Models;

namespace signalR.Controllers
{
    public class ChatController : Controller
    {
        private static ConcurrentDictionary<int, WebSocket> _sockets = new ConcurrentDictionary<int, WebSocket>();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("/edmschat")]
        public async Task Connection()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                var buffer = new byte[4];
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                var msg = Int32.Parse(Encoding.UTF8.GetString(buffer));
                this.AddSocket(msg, webSocket);
                while (webSocket.State == WebSocketState.Open)
                {
                    buffer = new byte[1024 * 4];
                    result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    var message = JsonConvert.DeserializeObject<ChatMessage>(Encoding.UTF8.GetString(buffer));
                    message.sender = this.FindUserById(message.senderId).name;
                    message.receiver= this.FindUserById(message.receiverId).name;
                    await this.BackToSender(message);
                    await this.SendMessageOnline(message);
                }
                await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        public void AddSocket(int senderId, WebSocket socket)
        {
            _sockets.TryAdd(senderId, socket);
        }
        [HttpPost("/edmschat")]
        public async Task SendMessage(ChatMessage chatMessage)
        {
            var userSocket = this.GetSocket(chatMessage.receiverId);
            var serverMsg = Encoding.UTF8.GetBytes(chatMessage.JSONToString(chatMessage));
            if (userSocket != null)
            {
                await userSocket.SendAsync(new ArraySegment<byte>(serverMsg, 0, serverMsg.Length), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
        public WebSocket GetSocket(int receiverId)
        {
            return _sockets.FirstOrDefault(p => p.Key == receiverId).Value;
        }
        public async Task ReceiveMessage(WebSocket socket)
        {
            var memorybuffer = new byte[1024 * 4];
            var receiveresult = await socket.ReceiveAsync(new ArraySegment<byte>(memorybuffer), CancellationToken.None);
            var message = JsonConvert.DeserializeObject<ChatMessage>(Encoding.UTF8.GetString(memorybuffer));
            await this.SendMessageOnline(message);
        }
        public async Task SendMessageOnline(ChatMessage chatMessage)
        {
            var userSocket = this.GetSocket(chatMessage.receiverId);
            var serverMsg = Encoding.UTF8.GetBytes(chatMessage.JSONToString(chatMessage));
            if (userSocket != null)
            {
                await userSocket.SendAsync(new ArraySegment<byte>(serverMsg, 0, serverMsg.Length), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }

        public async Task BackToSender(ChatMessage chatMessage)
        {
            var userSocket = this.GetSocket(chatMessage.senderId);
            var serverMsg = Encoding.UTF8.GetBytes(chatMessage.JSONToString(chatMessage));
            if (userSocket != null)
            {
                await userSocket.SendAsync(new ArraySegment<byte>(serverMsg, 0, serverMsg.Length), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
        public User FindUserById(int userId)
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com/users/"+userId);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var response = client.Execute<User>(request);
            Console.WriteLine(response.Content);

            return response.Data;
        }



    }
}
