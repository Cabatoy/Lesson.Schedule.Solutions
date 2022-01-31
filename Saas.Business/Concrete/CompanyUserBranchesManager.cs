using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saas.Business.Abstract;
using Saas.Business.Constants;
using Saas.Core.Aspect.Autofac.Caching;
using Saas.Core.Aspect.Autofac.Logging;
using Saas.Core.Aspect.Autofac.Performance;
using Saas.Core.CrossCuttingConcerns.Caching;
using Saas.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Saas.Core.Utilities.Results;
using Saas.DataAccess.EntityFrameWorkCore.IDal;
using Saas.Entities.Generic;
using Saas.Entities.Models;

namespace Saas.Business.Concrete
{
    public class CompanyUserBranchesManager :ICompanyUserBranchesService
    {
        private readonly ICompanyUserBranchesDal _companyUserBranches;


        public CompanyUserBranchesManager(ICompanyUserBranchesDal companyUserBranchesDal,ICacheManager cacheManager)
        {
            _companyUserBranches = companyUserBranchesDal;
        }

        [LogAspect(typeof(DatabaseLogger))]
        public Task<IResult> Add(CompanyUserBranches userBranch)
        {
            _companyUserBranches.Add(userBranch);
            return Task.FromResult<IResult>(new DataResult<CompanyUserBranches>(""));
        }


        [LogAspect(typeof(DatabaseLogger))]
        public Task<IResult> Delete(CompanyUserBranches userBranch)
        {

            _companyUserBranches.Delete(userBranch);
            return Task.FromResult<IResult>(new DataResult<CompanyUserBranches>(""));
        }

        [PerformanceAspect(interval: 5)]
        public Task<IDataResult<CompanyUserBranches>> GetCompanyUserBranchesById(Int32 brancheId)
        {
            return Task.FromResult<IDataResult<CompanyUserBranches>>(new DataResult<CompanyUserBranches>(_companyUserBranches.Get(filter: p => p.Id == brancheId),true));
        }

        [CacheAspect(duration: 10)]  //10 dakika boyunca cache te sonra db den tekrar cache e seklinde bir dongu
        [LogAspect(typeof(DatabaseLogger))]
      
        public Task<IDataResult<List<CompanyUserBranches>>> GetCompanyUserBranchesList()
        {
            return Task.FromResult<IDataResult<List<CompanyUserBranches>>>(new DataResult<List<CompanyUserBranches>>(_companyUserBranches.GetList(),true));
        }

        public IDataResult<IDto> SqlHelper(String query)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(CompanyUserBranches userBranch)
        {
            _companyUserBranches.Update(userBranch);
            return Task.FromResult<IResult>(new DataResult<CompanyUserBranches>(""));
        }
    }
}
