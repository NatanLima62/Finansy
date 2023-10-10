namespace Finansy.Domain.Contracts;

public interface ITracking
{
    public int? CriadoPor { get; set; }
    public DateTime CriadoEm { get; set; }
    public bool CriadoPorAdmin { get; set; }
    public int? AtualizadoPor { get; set; }
    public DateTime AtualizadoEm { get; set; }
    public bool AtualizadoPorAdmin { get; set; }
}