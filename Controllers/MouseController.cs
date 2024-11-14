using Data.MouseApiContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MouseApi.Models;

namespace MouseApi.Controllers;

// Probar con los métodos async. Poner algún sleep para probarlo o algo
[ApiController]
[Route("[controller]/[action]")]
public class MouseController(MouseDbContext mouseDbContext) : ControllerBase
{
    // Constructor primario
    private readonly MouseDbContext _MouseDbContext = mouseDbContext;

    [HttpGet(Name = "GetMouses")]
    public async Task<IEnumerable<MouseItem>> GetMouses()
    {
        // TODO: revisar qeu hace esto exactamente, el toListAsync. Evita un null reference?
        return await _MouseDbContext.MouseItems.ToListAsync();
    }

    [HttpPost(Name = "AddMouse")]
    public async Task<ActionResult<MouseItem>> AddMouseAloneFile(string name, IFormFile file)
    {
        using (var memoryStream = new MemoryStream())
        {
            // Copia el contendifo del archivo a un target
            file.CopyTo(memoryStream);

            // Creamos el objeto MouseFile
            MouseAloneFile mouseAloneFile = new()
            {
                FileName = name,
                MimeType = file.ContentType,
                Content = memoryStream.ToArray()
            };

            // He tenido que crear un nuevo modelo en Data -> MouseApiContext manualmente
            // Mirar si hay alguna manera para hacelo de manera más automática
            await _MouseDbContext.MouseAloneFile.AddAsync(mouseAloneFile);
        }

        await _MouseDbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(AddMouseAloneFile), new { name }, name);
    }
}
