using PackagesBack.Domain.Types;

namespace PackagesBack.Domain.Entities;

public class Status : Entity
{
    public DateTime Date { get; set; }
    public StatusesEnum StatusValue { get; set; }
}