using Api.App.Common;
using Microsoft.AspNetCore.Mvc;

namespace Api.App.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class SchemaController : ControllerBase
{
    [HttpGet]
    public IActionResult Get(DocumentSchema schema) => Ok(schema.Representatives);
}
