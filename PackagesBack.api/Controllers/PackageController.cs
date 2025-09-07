using Microsoft.AspNetCore.Mvc;
using PackagesBack.Core.Commands;
using PackagesBack.Core.Queries;

namespace PackagesBack.api.Controllers;

public class PackageController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreatePackageCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }
    
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] GetAllPackagesQuery query)
    {
        var result = await Mediator.Send(query);
        return Ok(result);
    }
    
    
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdPackageQuery query)
    {
        var result = await Mediator.Send(query);
        return Ok(result);
    }
    
    [HttpGet("GetAvailableStatuses")]
    public async Task<IActionResult> GetAvailableStatuses([FromQuery] GetPackageAvailableStatusesQuery query)
    {
        var result = await Mediator.Send(query);
        return Ok(result);
    }
    
    [HttpPatch("UpdateStatus")]
    public async Task<IActionResult> Update(UpdatePackageStatusCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }
    
}