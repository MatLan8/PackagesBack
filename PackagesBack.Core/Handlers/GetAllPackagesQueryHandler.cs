using MediatR;
using Microsoft.EntityFrameworkCore;
using PackagesBack.Core.Queries;
using PackagesBack.Infrastructure;

namespace PackagesBack.Core.Handlers;


public class GetAllPackagesQueryHandler(PackagesBackDbContext dbContext) : IRequestHandler<GetAllPackagesQuery, List<Domain.Entities.Package>>
{
    public async Task<List<Domain.Entities.Package>> Handle(GetAllPackagesQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.Packages.Include(p => p.StatusHistory).ToListAsync(cancellationToken);
    }
}