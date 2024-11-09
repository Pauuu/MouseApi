using Data.MouseApiContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MouseApi.Models;

namespace MouseApi.Controllers;

// Probar con los métodos async. Poner algún sleep para probarlo o algo
[ApiController]
[Route("[controller]/[route]")]
public class MouseController(MouseDbContext mouseDbContext) : ControllerBase
{
    // Constructor primario
    private readonly MouseDbContext _MouseDbContext = mouseDbContext;

    [HttpGet(Name = "GetMouses")]
    public async Task<IEnumerable<MouseItem>> GetMouses()
    {
        // TODO: revisar qeu hace esto exactamente. Evita un null reference?
        return await _MouseDbContext.MouseItems.ToListAsync();
    }

    [HttpPost(Name = "AddMousee")]
    public async Task<ActionResult<MouseItem>> AddMouse(MouseItem mouseItem)
    {
        _MouseDbContext.MouseItems.Add(mouseItem);

        await _MouseDbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(AddMouse), new { id = mouseItem.Id }, mouseItem);

        // return CreatedAtAction(nameof(GetMouses), new { id = 23 }, null);
    }
}
