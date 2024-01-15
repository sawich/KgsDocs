using Api.Domain.Enums;
using Api.Domain.Responses.Lists;
using Microsoft.AspNetCore.Mvc;

namespace Api.App.Controllers;

[ApiController]
[Route("[controller]")]
public class MailTypeController : ControllerBase
{
    private static readonly ICollection<MailTypeResponse> _response = new MailTypeResponse[]
        {
            new (MailType.Inbox, "Направляется генеральному директору на назначение"),
            new (MailType.FromPrivateCourtExecutor, "Направляется на исполнение главному бухгалтеру")
        };

    [HttpGet]
    [ProducesResponseType<IEnumerable<MailTypeResponse>>(200)]
    public IActionResult Get() => Ok(_response);
}
