using MediatR;
using PackagesBack.Domain.Dtos;
using PackagesBack.Domain.Entities;

namespace PackagesBack.Core.Queries;

public class GetByIdPackageQuery : IRequest<PackageDto>
{
    public required Guid PackageId { get; set; }
}