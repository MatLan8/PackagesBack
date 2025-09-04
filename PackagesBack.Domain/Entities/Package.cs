using PackagesBack.Domain.Types;

namespace PackagesBack.Domain.Entities;

public class Package :Entity
{
    public string SenderAddress { get; set; }
    public string SenderName { get; set; }
    public string SenderPhone { get; set; }
    
    public string ReceiverAddress { get; set; }
    public string ReceiverName { get; set; }
    public string ReceiverPhone { get; set; }
    
    public List<Status> StatusHistory { get; set; }
}