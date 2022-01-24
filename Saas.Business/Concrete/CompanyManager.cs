using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Saas.Business.Abstract;
using Saas.Entities.Models;
using Saas.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Saas.Business.ValidationRules.FluentValidation;
using Saas.Core.Utilities.Business;
using Saas.Business.Constants;
using Saas.Core.Aspect.Autofac.Caching;
using Saas.Core.Aspect.Autofac.Logging;
using Saas.Core.Aspect.Autofac.Performance;
using Saas.Core.Aspect.Autofac.Validation;
using Saas.Core.Utilities.Results;
using Saas.DataAccess.EntityFrameWorkCore.IDal;

namespace Saas.Business.Concrete
{

    public class CompanyManager :ICompanyService
    {
        private readonly ICompanyDal _companyDal;


        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        [ValidationAspect(typeof(CompanyValidator),Priority = 1)] //add methoduna girmeden araya girip once kontrol saglar
        [LogAspect(typeof(DatabaseLogger))]
        public IResult Add(Company company)
        {
            // ValidationTool.Validate(new CompanyValidator(), company);
            IResult result = BusinessRules.Run( CheckCompanyTaxNumberExist(company.TaxNumber));
            if (result != null)
                return result;
            _companyDal.Add(company);
            return new DataResult<Company>(Messages.CompanyAdded);
        }

        private IResult CheckCompanyTaxNumberExist(string companyTaxNumber)
        {
            if (_companyDal.GetList(p => p.TaxNumber == companyTaxNumber).Count != 0)
            {
                return new ErrorResult(message: Messages.CompanyTaxNumberExistError);
            }
            return new SuccessResult();
        }

        [LogAspect(typeof(DatabaseLogger))]
        public IResult Delete(Company company)
        {
            _companyDal.Delete(company);

            return new DataResult<Company>(message: Messages.CompanyDeleted);
        }


        [LogAspect(typeof(DatabaseLogger))]
        public IResult Update(Company company)
        {
            _companyDal.Update(company);

            return new DataResult<Company>(Messages.CompanyUpdated);
        }

        [CacheAspect(duration: 10)]  //10 dakika boyunca cache te sonra db den tekrar cache e seklinde bir dongu
        [LogAspect(typeof(DatabaseLogger))]
        [PerformanceAspect(interval: 5)]
        public IDataResult<List<Company>> GetCompanyList()
        {
            return new DataResult<List<Company>>(_companyDal.GetList(),true);
        }
        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<Company> GetCompanyById(int companyId)
        {
            return new DataResult<Company>(_companyDal.Get(filter: p => p.Id == companyId),true);
        }
    }
}
