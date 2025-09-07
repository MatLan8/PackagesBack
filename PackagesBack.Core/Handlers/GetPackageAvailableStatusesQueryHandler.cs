using MediatR;
using Microsoft.EntityFrameworkCore;
using PackagesBack.Core.Queries;
using PackagesBack.Domain.Dtos;
using PackagesBack.Domain.Entities;
using PackagesBack.Domain.Types;
using PackagesBack.Infrastructure;

namespace PackagesBack.Core.Handlers;

public class GetPackageAvailableStatusesQueryHandler(PackagesBackDbContext dbContext) : IRequestHandler<GetPackageAvailableStatusesQuery, List<StatusesEnum>>
{
    public async Task<List<StatusesEnum>> Handle(GetPackageAvailableStatusesQuery request, CancellationToken cancellationToken)
    {
        var package = await dbContext.Packages
            .Include(p => p.StatusHistory)
            .FirstOrDefaultAsync(p => p.Id == request.PackageId, cancellationToken);
        if (package == null)
        {
            throw new Exception("Package not found");
        }
        var currentStatus = package.StatusHistory.OrderByDescending(h => h.Date).FirstOrDefault()?.StatusValue;

        if (currentStatus == null)
        {
            throw new Exception("Package has no status");
        }

        return currentStatus switch
        {
            StatusesEnum.Created => new List<StatusesEnum> { StatusesEnum.Sent, StatusesEnum.Canceled },
            StatusesEnum.Sent => new List<StatusesEnum>
                { StatusesEnum.Accepted, StatusesEnum.Returned, StatusesEnum.Canceled },
            StatusesEnum.Returned => new List<StatusesEnum> { StatusesEnum.Sent, StatusesEnum.Canceled },
            StatusesEnum.Accepted => new List<StatusesEnum>(),
            StatusesEnum.Canceled => new List<StatusesEnum>(),
            _ => new List<StatusesEnum>()
        };
    }
}