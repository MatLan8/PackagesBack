using MediatR;
using PackagesBack.Core.Commands;
using PackagesBack.Domain.Entities;
using PackagesBack.Domain.Types;
using PackagesBack.Infrastructure;

namespace PackagesBack.Core.Handlers;

public class CreatePackageCommandHandler(PackagesBackDbContext dbContext) : IRequestHandler<CreatePackageCommand,bool>
{
   public async Task<bool> Handle(CreatePackageCommand request, CancellationToken cancellationToken)
   {
      var package = new Package
      {
         SenderAddress = request.SenderAddress,
         SenderName = request.SenderName,
         SenderPhone = request.SenderPhone,
         
         ReceiverAddress = request.ReceiverAddress,
         ReceiverName = request.ReceiverName,
         ReceiverPhone = request.ReceiverPhone,
         StatusHistory = new List<Status>{new Status { Date = DateTime.Now, StatusValue = StatusesEnum.Created}}
      };
      
      await dbContext.Packages.AddAsync(package, cancellationToken);
      await dbContext.SaveChangesAsync(cancellationToken);

      return true;
   } 
}