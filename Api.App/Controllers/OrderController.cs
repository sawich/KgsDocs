using Api.Domain.Requests.Reports;
using Api.Infrastructure.Persistent;
using IronXL;
using Microsoft.AspNetCore.Mvc;

namespace Api.App.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class OrderController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<byte[]>(200)]
    public IActionResult Get([FromQuery] ReportRequest request, PersistentContext persistence)
    {
        var book = WorkBook.Create(ExcelFileFormat.XLSX);
        var sheet = book.CreateWorkSheet("Лист 1");
        
        // generate

        return Ok(book.ToStream());
    }
}
