using MediatR;
using PackagesBack.Domain.Entities;

namespace PackagesBack.Core.Queries;

public class GetAllPackagesQuery : IRequest<List<Package>>;