using MediatR;
using Microsoft.EntityFrameworkCore;
using PackagesBack.Core.Queries;
using PackagesBack.Domain.Dtos;
using PackagesBack.Infrastructure;

namespace PackagesBack.Core.Handlers;


public class GetAllPackagesQueryHandler(PackagesBackDbContext dbContext) : IRequestHandler<GetAllPackagesQuery, List<PackageDto>>
{
    public async Task<List<PackageDto>> Handle(GetAllPackagesQuery request, CancellationToken cancellationToken)
    {
        //return await dbContext.Packages.Include(p => p.StatusHistory).ToListAsync(cancellationToken);
        
        return await dbContext.Packages
            .Include(p => p.StatusHistory)
            .Select(p => new PackageDto
            {
                Id = p.Id,
                SenderAddress = p.SenderAddress,
                SenderName = p.SenderName,
                SenderPhone = p.SenderPhone,
                ReceiverAddress = p.ReceiverAddress,
                ReceiverName = p.ReceiverName,
                ReceiverPhone = p.ReceiverPhone,
                StatusHistory = p.StatusHistory
                    .Select(s => new StatusDto
                    {
                        Date = s.Date,
                        StatusValue = s.StatusValue,
                    }).ToList()
            })
            .ToListAsync(cancellationToken);
    }
}