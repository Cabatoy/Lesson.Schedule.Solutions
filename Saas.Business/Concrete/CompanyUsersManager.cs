using System.Collections.Generic;
using Saas.Business.Abstract;
using Saas.Business.Constants;
using Saas.Core.Aspect.Autofac.Caching;
using Saas.Core.Aspect.Autofac.Logging;
using Saas.Core.Aspect.Autofac.Performance;
using Saas.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Saas.Core.Utilities.Results;
using Saas.DataAccess.EntityFrameWorkCore.IDal;
using Saas.Entities.Models;
using Saas.Entities.Models.UserClaims;

namespace Saas.Business.Concrete
{
    public class CompanyUsersManager :ICompanyUserService
    {
        private readonly ICompanyUserDal _userDal;

        public CompanyUsersManager(ICompanyUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(CompanyUser user)
        {
            _userDal.Add(user);
            return new DataResult<CompanyUser>(Messages.UsersAdded);
        }

        public IResult Delete(CompanyUser user)
        {
            _userDal.Delete(user);
            return new DataResult<CompanyUser>(Messages.UsersDeleted);
        }

        public IDataResult<CompanyUser> GetUserById(int userId)
        {
            return new DataResult<CompanyUser>(_userDal.Get(p => p.Id == userId),true);
        }

        public CompanyUser GetByMail(string mail)
        {
            return _userDal.Get(p => p.Email == mail);
        }
        [CacheAspect(duration: 10)]  //10 dakika boyunca cache te sonra db den tekrar cache e seklinde bir dongu
        [LogAspect(typeof(DatabaseLogger))]
       
        public List<CompanyOperationClaim> GetClaims(CompanyUser user)
        {
            return _userDal.GetClaims(user);
        }
        [CacheAspect(duration: 10)]  //10 dakika boyunca cache te sonra db den tekrar cache e seklinde bir dongu
        [LogAspect(typeof(DatabaseLogger))]
     
        public IDataResult<List<CompanyUser>> GetUserList()
        {
            return new DataResult<List<CompanyUser>>(_userDal.GetList(),true);
        }

        public IResult Update(CompanyUser user)
        {
            _userDal.Update(user);
            return new DataResult<CompanyUser>(Messages.UsersUpdated);
        }
    }
}
