namespace Finansy.Domain.Contracts;

public interface ITracking
{
    public int CreatedBy { get; set; }
    public DateTime CreatedIn { get; set; }
    public bool CreatedByAdmin { get; set; }
    
    public int UpdatedBy { get; set; }
    public int UpdatedIn { get; set; }
    public bool UpdatedByAdmin { get; set; }
}