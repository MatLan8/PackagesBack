using MediatR;
using Microsoft.EntityFrameworkCore;
using PackagesBack.Core.Queries;
using PackagesBack.Domain.Dtos;
using PackagesBack.Domain.Entities;
using PackagesBack.Infrastructure;

namespace PackagesBack.Core.Handlers;

public class GetByIdPackageQueryHandler(PackagesBackDbContext dbContext) : IRequestHandler<GetByIdPackageQuery, PackageDto>
{
    public async Task<PackageDto> Handle(GetByIdPackageQuery request, CancellationToken cancellationToken)
    {
        var package = await dbContext.Packages.Include(p => p.StatusHistory)
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
            .FirstOrDefaultAsync(p => p.Id == request.PackageId, cancellationToken);
        
        
        
        return package ?? throw new NullReferenceException("Package not found");
    }
}