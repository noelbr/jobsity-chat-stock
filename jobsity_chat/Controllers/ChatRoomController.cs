using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jobsity_chat.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace jobsity_chat.Controllers
{
    public class ChatRoomController : Controller
    {
        [Route("ChatRoom/{RoomName}")]
        public IActionResult Index(string RoomName)
        {
            var model = new Room
            {
                Name = RoomName
            };


            return View(model);
        }
    }
}
