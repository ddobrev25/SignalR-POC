using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SignalR_POC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<MessageHub> _hubContext;

        public ChatController(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }
        //path looks like this: https://localhost:44379/api/chat/send
        [HttpPost]
        public IActionResult SendRequest(Message msg)
        {
            _hubContext.Clients.All.SendAsync("ReceiveOne", msg.Types, msg.Information);
            return Ok();
        }
    }
}
