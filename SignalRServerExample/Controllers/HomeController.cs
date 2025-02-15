using Microsoft.AspNetCore.Mvc;
using SignalRServerExample.Business;

namespace SignalRServerExample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : ControllerBase
{
    readonly MyBusiness _myBusiness;
    public HomeController(MyBusiness myBusiness)
    {
        _myBusiness = myBusiness;
    }
    
    [HttpGet("{message}")]
    public async Task<IActionResult> Index(string message)
    {
        await _myBusiness.SendMessageAsync(message);
        return Ok();
    }
}