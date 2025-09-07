using MediatR;
using Microsoft.EntityFrameworkCore;
using PackagesBack.Core.Commands;
using PackagesBack.Domain.Entities;
using PackagesBack.Domain.Types;
using PackagesBack.Infrastructure;

namespace PackagesBack.Core.Handlers;

public class UpdatePackageStatusCommandHandler(PackagesBackDbContext dbContext) : IRequestHandler<UpdatePackageStatusCommand,bool>
{
    public async Task<bool> Handle(UpdatePackageStatusCommand request, CancellationToken cancellationToken)
    {
        var package = await dbContext.Packages
            .Include(p => p.StatusHistory)
            .FirstOrDefaultAsync(p => p.Id == request.PackageId, cancellationToken);
        
        if (package == null)
        {
            throw new Exception("Package not found");
        }
        
        var newStatus = new Status {Date = DateTime.Now, StatusValue = request.status };
        
        dbContext.Statuses.Add(newStatus);
        package.StatusHistory.Add(newStatus);
        
        await dbContext.SaveChangesAsync(cancellationToken);

        return true;
    } 
}