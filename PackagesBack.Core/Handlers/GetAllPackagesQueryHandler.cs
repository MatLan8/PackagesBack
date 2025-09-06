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
                CreationDate = p.CreatedAt,
                SenderName = p.SenderName,
                SenderAddress = p.SenderAddress,
                SenderPhone = p.SenderPhone,
                ReceiverName = p.ReceiverName,
                ReceiverAddress = p.ReceiverAddress,
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