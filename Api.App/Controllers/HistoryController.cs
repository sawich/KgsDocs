using Api.App.Helpers;
using Api.Domain.Responses.Histories;
using Api.Infrastructure.Persistent;
using Api.Infrastructure.Persistent.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.App.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class HistoryController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<IEnumerable<HistoryResponse>>(200)]
    public IActionResult Get(int document, PersistentContext persistence, IMapper mapper, int limit = 100, int offset = 0)
    {
        ControllerHelper.NormalizeLimitAndOffset(ref limit, ref offset);

        return Ok(persistence.Histories
            .Include(e => e.Author)
            .Include(e => e.Document)
            .Where(e => e.Document.Id == document)
            .Select(e => mapper.Map<HistoryModel, HistoryResponse>(e))
            .Skip(offset)
            .Take(limit));
    }
}
