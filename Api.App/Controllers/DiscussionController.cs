using Api.App.Helpers;
using Api.App.Requests;
using Api.Infrastructure.Mapper;
using Api.Infrastructure.Persistent;
using Api.Infrastructure.Persistent.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.App.Controllers;


[ApiController]
[Route("[controller]")]
public sealed class DiscussionController : ControllerBase
{
    [HttpGet]
    [Authorize]
    [ProducesResponseType(401)]
    [ProducesResponseType<IEnumerable<DiscussionResponse>>(200)]
    public IActionResult Get([FromQuery] GetDiscussionRequest request, PersistentContext persistence, IMapper mapper)
    {
        var limit = request.Limit;
        var offset = request.Offset;

        ControllerHelper.NormalizeLimitAndOffset(ref limit, ref offset);

        return Ok(persistence.Discussions
            .Include(e => e.Author)
            .Include(e => e.Document)
            .Where(e => e.Document.Id == request.Document)
            .Select(e => mapper.Map<DiscussionModel, DiscussionResponse>(e))
            .Skip(offset)
            .Take(limit));
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType(401)]
    [ProducesResponseType<IEnumerable<DiscussionResponse>>(200)]
    public async Task<IActionResult> Post([FromBody] PostDiscussionRequest request, PersistentContext persistence, CancellationToken ct)
    {
        if (request.Content.Length <= 0) return BadRequest();

        var model = await persistence.Documents.FirstOrDefaultAsync(e => e.Id == request.Document, ct);
        if (model is null) return NotFound();

        //persistence.Discussions.AddAsync(new()
        //{
        //    Author = 
        //    Text = request.Content,
        //    Document = model
        //});

        await persistence.SaveChangesAsync(ct);


        return Ok();
    }
}
