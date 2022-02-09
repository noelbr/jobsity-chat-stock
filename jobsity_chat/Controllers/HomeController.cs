using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using jobsity_chat.Models;
using Microsoft.AspNetCore.SignalR;
using jobsity_chat.Hubs;
using jobsity_chat.Context;

namespace jobsity_chat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public static IHubContext<ChatHub> _hubContext;
        public static DBChatContext _context;



        public HomeController(ILogger<HomeController> logger, IHubContext<ChatHub> hubContext, DBChatContext context)
        {
            _logger = logger;
            _hubContext = hubContext;
            _context = context;
        }

        public IActionResult Index()
        {
            var rooms = _context.Rooms.ToList();
            return View(rooms);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(Room req)
        {
            _context.Rooms.Add(new Room
            {
                Name = req.Name
            });

            _context.SaveChanges();

            return Redirect("/");
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
    }
}
