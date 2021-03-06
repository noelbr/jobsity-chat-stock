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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace jobsity_chat.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public static IHubContext<ChatHub> _hubContext;
        public static DBChatContext _context;
 
        private readonly SignInManager<IdentityUser> _signInManager;

   
        public HomeController(ILogger<HomeController> logger,
                            IHubContext<ChatHub> hubContext,
                            DBChatContext context,
                             SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _hubContext = hubContext;
            _context = context;
            _signInManager = signInManager;
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

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

    }
}
