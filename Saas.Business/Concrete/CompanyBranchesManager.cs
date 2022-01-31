using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Saas.Business.Abstract;
using Saas.Core.Aspect.Autofac.Caching;
using Saas.Core.Aspect.Autofac.Logging;
using Saas.Core.Aspect.Autofac.Performance;
using Saas.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Saas.Core.Utilities.Results;
using Saas.DataAccess.EntityFrameWorkCore.IDal;
using Saas.Entities.Dto;
using Saas.Entities.Generic;
using Saas.Entities.Models;

namespace Saas.Business.Concrete
{
    public class CompanyBranchesManager :ICompanyBranchesService
    {
        private readonly ICompanyBranchDal _branchDal;
        private IEnumerable<CompanyBranch> _companyBranches;

        public CompanyBranchesManager(ICompanyBranchDal branchDal)
        {
            _branchDal = branchDal;
        }
        [LogAspect(typeof(DatabaseLogger))]
        public IResult Add(CompanyBranch companyBranch)
        {
            _branchDal.Add(companyBranch);
            return new DataResult<CompanyUser>("");
        }
        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<CompanyBranch> CompanyBranchById(Int32 branchId)
        {
            _companyBranches = _branchDal.GetList().Where(x => x.Id == branchId);
            return new DataResult<CompanyBranch>("");
        }
        [CacheAspect(duration: 10)]  //10 dakika boyunca cache te sonra db den tekrar cache e seklinde bir dongu
        [LogAspect(typeof(DatabaseLogger))]

        public IDataResult<List<CompanyBranch>> CompanyBranchesList()
        {
            _branchDal.GetList();
            return new DataResult<List<CompanyBranch>>("");
        }
        [LogAspect(typeof(DatabaseLogger))]
        public IResult Delete(CompanyBranch companyBranch)
        {
            _branchDal.Delete(companyBranch);
            return new DataResult<CompanyUser>("");
        }

        [LogAspect(typeof(DatabaseLogger))]
        public IResult Update(CompanyBranch companyBranch)
        {
            _branchDal.Update(companyBranch);
            return new DataResult<CompanyUser>("");
        }

        //sample data
        public IDataResult<IDto> SqlHelper(string query)
        {
            List<CompanyBranch> usersInDb = _branchDal.FromSqlQuery<CompanyBranch>(
                    query,
                    x => new CompanyBranch
                    {
                        Description = (string)x[0],
                        DescriptionThree = (string)x[1]
                    },
                    new SqlParameter("@paramName","")
                )
                .ToList();
            List<CompanyBranch> userssInDb = _branchDal.FromSqlQuery<CompanyBranch>
                (
                    query,
                    new SqlParameter("@paramName","user.Name")
                )
                .ToList();
            return new DataResult<UserForLoginDto>("");
        }
    }
}
