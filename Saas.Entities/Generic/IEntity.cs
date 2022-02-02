namespace Saas.Entities.Generic;

public interface IEntity
{
   
    public bool Deleted { get; set; }
    string CreatedBy { get; set; }
    DateTime? CreatedOn { get; set; }
    string? UpdatedBy { get; set; }
    DateTime? UpdatedOn { get; set; }
}