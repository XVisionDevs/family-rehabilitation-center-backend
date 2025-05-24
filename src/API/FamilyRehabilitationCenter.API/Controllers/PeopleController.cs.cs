using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FamilyRehabilitationCenter.API.Controllers;

[ApiController]
[Route("api/People")]
public class PeopleController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public object GetPerson()
    {
        return 10;
    }
}
