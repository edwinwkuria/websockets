using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using signalR.Models;

namespace signalR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public async Task<IActionResult> OpenConn(string name)
        {
            //var webSocket = await this.HttpContext.WebSockets.AcceptWebSocketAsync();

                DateTime date1 = new DateTime(2010, 8, 18, 13, 0, 15);
                DateTime date2 = new DateTime(2010, 8, 18, 13, 30, 30);

                // Calculate the interval between the two dates.
                TimeSpan interval = date2 - date1;
                //using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                //var type = webSocket.State;
                var encoded = Encoding.UTF8.GetBytes(name);
                var buffer2 = new ArraySegment<Byte>(encoded, 0, encoded.Length);
                    var buffer = new byte[1024 * 4];
                //await webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                Stream stream = new MemoryStream(buffer);
                WebSocket webSocket = WebSocket.CreateFromStream(stream,true, null , interval);
                await webSocket.SendAsync(buffer2, WebSocketMessageType.Text, true, CancellationToken.None);
            return RedirectToAction("Index");
        }
    }
}
