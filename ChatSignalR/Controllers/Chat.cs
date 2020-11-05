using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatSignalR.Interfaces;
using ChatSignalR.Model;
using ChatSignalR.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChatSignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Chat : Controller
    {
        private IHubContext<ChatHub, IChatHub> _hubContext;

        public Chat(IHubContext<ChatHub, IChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public string Post([FromBody] Message msg)
        {
            string retMessage = string.Empty;
            try
            {
                var x= _hubContext.Clients.All.SendNotification(msg.type, msg.message);
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }
            return retMessage;
        }
    }
}
