using Api.App.Requests;
using Api.Infrastructure.Persistent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.App.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class FileController(ILogger<FileController> logger) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<IEnumerable<byte>>(200)]
    public async Task<IActionResult> Get(int id, PersistentContext persistence, CancellationToken ct)
    {
        var file = await persistence.Files.FirstOrDefaultAsync(e => e.Id == id && e.Path != string.Empty, ct);
        if (file is null || System.IO.File.Exists(file.Path) is false) return NotFound();

        return Ok(System.IO.File.OpenRead(file.Path));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] PostFileRequest request, PersistentContext persistence, CancellationToken ct)
    {
        var file = await persistence.Files.FirstOrDefaultAsync(e => e.Id == request.Id && e.Path == string.Empty, ct);
        if (file is null || System.IO.File.Exists(file.Path) is true) return BadRequest();
        
        return Ok();
    }
}
