using Api.Domain.Responses.Tasks;
using Api.Infrastructure.Persistent;
using Api.Infrastructure.Persistent.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.App.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class TaskController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<IEnumerable<TaskResponse>>(200)]
    public IActionResult Get(PersistentContext persistence, IMapper mapper) => Ok(persistence.Tasks
        .Include(e => e.Author)
        .Select(e => mapper.Map<TaskModel, TaskResponse>(e)));
}

public record PostDocumentRequest();

[ApiController]
[Route("[controller]")]
public sealed class DocumentController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<IEnumerable<TaskResponse>>(200)]
    public IActionResult Get(PersistentContext persistence, IMapper mapper) => Ok(persistence.Tasks
        .Include(e => e.Author)
        .Select(e => mapper.Map<TaskModel, TaskResponse>(e)));
}
