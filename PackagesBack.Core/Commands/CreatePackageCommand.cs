using MediatR;

namespace PackagesBack.Core.Commands;

public class CreatePackageCommand : IRequest<bool>
{
    public string SenderAddress { get; set; }
    public string SenderName { get; set; }
    public string SenderPhone { get; set; }
    
    public string ReceiverAddress { get; set; }
    public string ReceiverName { get; set; }
    public string ReceiverPhone { get; set; }
}