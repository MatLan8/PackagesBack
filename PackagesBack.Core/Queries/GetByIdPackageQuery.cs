using MediatR;
using PackagesBack.Domain.Entities;

namespace PackagesBack.Core.Queries;

public class GetByIdPackageQuery : IRequest<Package>
{
    public required Guid PackageId { get; set; }
}