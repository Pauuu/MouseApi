using Data.MouseApiContext;
using Microsoft.AspNetCore.Mvc;
using MouseApi.Models;

namespace MouseApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MouseController : ControllerBase
{
    private readonly MouseDbContext _MouseDbContext;

    public MouseController(MouseDbContext mouseDbContext)
    {
        _MouseDbContext = mouseDbContext;
    }

    [HttpGet(Name = "GetMouses")]
    public IEnumerable<MouseItem> Get()
    {
        return _MouseDbContext.MouseItems.ToArray();
    }
}
