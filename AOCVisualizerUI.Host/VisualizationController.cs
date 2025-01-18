using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AOCVisualizerUI.Host;

[ApiController]
[Route("[controller]")]
public class VisualizerController(IHubContext<MessageHub> hubContext) : ControllerBase
{
    [HttpGet("start")]
    public async Task<IActionResult> TestCommand(string message)
    {
        await hubContext.Clients.All.SendAsync("ReceiveMessage", "Origin: UI.Host", message);

        return Accepted();
    }
}