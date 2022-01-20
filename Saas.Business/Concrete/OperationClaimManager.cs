using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constant;
using Core.Aspect.Autfac.Transaction;
using Core.Utilities.Results;
using Saas.DataAccess.EntityFrameWorkCore.IDal;
using Saas.Entities.Models.UserClaims;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        private ICompanyOperationClaimDal _rolesDal;

        public OperationClaimManager(ICompanyOperationClaimDal rolesDal)
        {
            _rolesDal = rolesDal;
        }

        public IResult Add(CompanyOperationClaim roles)
        {
            _rolesDal.Add(roles);
            return new DataResult<CompanyOperationClaim>(Messages.rolesAdded);
        }

        public IResult Delete(CompanyOperationClaim roles)
        {
            _rolesDal.Delete(roles);
            return new DataResult<CompanyOperationClaim>(Messages.rolesDeleted);

        }

        public IDataResult<CompanyOperationClaim> GetById(int rolesId)
        {
            return new DataResult<CompanyOperationClaim>(_rolesDal.Get(p => p.Id == rolesId),true);
        }

        public IDataResult<List<CompanyOperationClaim>> GetList()
        {
            return new DataResult<List<CompanyOperationClaim>>(_rolesDal.GetList(), true);
        }

        public IResult Update(CompanyOperationClaim roles)
        {
            _rolesDal.Update(roles);
            return new DataResult<CompanyOperationClaim>(message: Messages.rolesUpdated);
        }
    }
}
