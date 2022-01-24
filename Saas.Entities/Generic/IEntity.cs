namespace Saas.Entities.Generic;

public interface IEntity
{
    string CreatedBy { get; set; }
    DateTime? CreatedOn { get; set; }
    string UpdatedBy { get; set; }
    DateTime? UpdatedOn { get; set; }
}