using MediatR;
using PackagesBack.Domain.Dtos;
using PackagesBack.Domain.Types;

namespace PackagesBack.Core.Queries;

public class GetPackageAvailableStatusesQuery : IRequest<List<StatusesEnum>>
{
    public required Guid PackageId { get; set; }
}