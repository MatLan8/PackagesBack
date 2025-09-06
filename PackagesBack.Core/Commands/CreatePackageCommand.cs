using MediatR;

namespace PackagesBack.Core.Commands;

public class CreatePackageCommand : IRequest<bool>
{
    
    public required string SenderName { get; set; }
    public required string SenderAddress { get; set; }
    public required string SenderPhone { get; set; }
    public required string ReceiverName { get; set; } 
    public required string ReceiverAddress { get; set; }
    public required string ReceiverPhone { get; set; }
}