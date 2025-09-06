namespace PackagesBack.Domain.Dtos;

public class PackageDto
{
    public Guid Id { get; set; }
    public string SenderAddress { get; set; }
    public string SenderName { get; set; }
    public string SenderPhone { get; set; }
    
    public string ReceiverAddress { get; set; }
    public string ReceiverName { get; set; }
    public string ReceiverPhone { get; set; }
    public DateTime CreationDate { get; set; }
    public List<StatusDto> StatusHistory { get; set; }
}