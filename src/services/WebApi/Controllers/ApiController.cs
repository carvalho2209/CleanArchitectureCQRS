using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

/// <summary>
/// Represents the base API controller.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public abstract class ApiController : ControllerBase
{
    private IMediator? _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>() ?? throw new ArgumentException("Unable to resolve IMediator instance. Application is misconfigured.");

}