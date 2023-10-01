namespace Finansy.Domain.Contracts;

public interface ISoftDelete
{
    public bool Active { get; set; }
}