using Microsoft.AspNetCore.Mvc;
using MouseApi.Models;

namespace MouseApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MouseController : ControllerBase
{
    [HttpGet(Name = "GetMouses")]
    public IEnumerable<MouseItem> Get()
    {
       return [
           new() {
                Id = 0,
                Name = "Roberta",
                IsComplete = true 
           } 
       ];
    }
}
