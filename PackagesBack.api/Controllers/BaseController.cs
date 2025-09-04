﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PackagesBack.api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class BaseController : ControllerBase
{
    private IMediator? _mediator;

    protected IMediator Mediator
        => (_mediator ??= HttpContext.RequestServices.GetService<IMediator>()) ?? throw new ArgumentNullException(nameof(_mediator));
}