using MediatR;
using PackagesBack.Domain.Types;

namespace PackagesBack.Core.Commands;

public class UpdatePackageStatusCommand : IRequest<bool>
{
    public required Guid PackageId { get; set; }
    public required StatusesEnum status { get; set; }
}