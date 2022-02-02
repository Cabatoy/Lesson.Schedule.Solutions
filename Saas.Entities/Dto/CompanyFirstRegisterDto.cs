using Saas.Entities.Generic;

namespace Saas.Entities.Dto
{
    public class CompanyFirstRegisterDto :IDto, IEntity
    {
        public int CompanyId { get; set; }
        public List<int> UserBranchesList { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public string Adress { get; set; }
        public bool IsStudent { get; set; }
        public bool SysAdmin { get; set; }
        public bool BranchAdmin { get; set; }

        public CompanyFirstRegisterDto()
        {
            CompanyId = 0;
            UserBranchesList = new List<int>();
        }

        public bool Deleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
