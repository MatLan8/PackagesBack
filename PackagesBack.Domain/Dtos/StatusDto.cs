using PackagesBack.Domain.Types;

namespace PackagesBack.Domain.Dtos;

public class StatusDto
{
    public DateTime Date { get; set; }
    public StatusesEnum StatusValue { get; set; }
}