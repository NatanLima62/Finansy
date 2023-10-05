namespace Finansy.Domain.Contracts;

public interface ISoftDelete
{
    public bool Ativo { get; set; }
}