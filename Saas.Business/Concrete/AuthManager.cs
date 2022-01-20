using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autfac.Transaction;
using Core.Aspect.Autfac.Validation;
using Core.Aspect.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Identity;
using Saas.Business.Abstract;
using Saas.Core.Security.Security.Hashing;
using Saas.Core.Security.Security.Security.Jwt;
using Saas.DataAccess.EntityFrameWorkCore.IDal;
using Saas.Entities.Dto;
using Saas.Entities.Models;

namespace Saas.Business.Concrete
{
    public class AuthManager :IAuthService
    {
        private readonly ICompanyUserService _userService;
        private readonly ICompanyService _companyService;
        private readonly ITokenHelper _tokenHelper;
        private readonly ICompanyBranchDal _branchDal;
        private readonly ICompanyDal _companyDal;

        public AuthManager(ICompanyUserService usersService,ITokenHelper tokenHelper,ICompanyBranchDal branchDal,ICompanyDal companyDal)
        {
            _userService = usersService;
            _tokenHelper = tokenHelper;
            _branchDal = branchDal;
            _companyDal = companyDal;
        }

        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<CompanyUser> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new DataResult<CompanyUser>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,userToCheck.PassWordHash,userToCheck.PassWordSalt))
            {
                return new DataResult<CompanyUser>(Messages.PasswordError);
            }

            return new DataResult<CompanyUser>(userToCheck,true,Messages.SuccessfullLogin);


        }

        public IResult UserExist(string Email)
        {
            if (_userService.GetByMail(Email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }

            return new SuccessResult();
        }

        [LogAspect(typeof(DatabaseLogger))]
        [TransactionScopeAspect]
        public IDataResult<CompanyUser> Register(UserForRegisterDto userForRegisterDto)
        {
            //byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password,out byte[] passwordHash,out byte[] passwordSalt);
            var usr = new CompanyUser
            {
                CompanyId = userForRegisterDto.CompanyId,
                //branc = userForRegisterDto.LocalId,
                Email = userForRegisterDto.Email,
                FullName = userForRegisterDto.FullName,
                PassWordHash = passwordHash,
                PassWordSalt = passwordSalt,
                Deleted = false
            };
            _userService.Add(usr);
            return new DataResult<CompanyUser>(usr,true,Messages.UsersAdded);
        }

        public IDataResult<AccessToken> CreateAccessToken(CompanyUser user)
        {
            var claims = _userService.GetClaims(user);
            var accesstoken = _tokenHelper.CreateToken(user,claims);
            return new DataResult<AccessToken>(accesstoken,true,Messages.AccessTokenCreated);
        }

        [ValidationAspect(typeof(AuthValidator),Priority = 1)]
        [LogAspect(typeof(DatabaseLogger))]
        //    [TransactionScopeAspect]
        public IResult RegisterForCompany(UserForRegisterDto dt)
        {
            IResult result = BusinessRules.Run(CheckCompanyTaxNumberExist(dt.TaxNumber));
            if (result != null)
                return result;
            Company company = new Company
            {
                TaxNumber = dt.TaxNumber,
                Adress = dt.Adress,
                FullName = dt.CompanyName,
            };

            _companyDal.Add(company);

            //CompanyLocal loc = new CompanyLocal
            //{
            //    CompanyId = company.Id,
            //    FullName = "Merkez",
            //    Deleted = false

            //};
            //_localDal.Add(loc);

            //dt.CompanyId = company.Id;
            //dt.LocalId = loc.Id;
            //if (string.IsNullOrWhiteSpace(dt.Password) || string.IsNullOrEmpty(dt.Password))
            //    dt.Password = GenerateRandomPassword(new PasswordOptions()
            //    {
            //        RequireDigit = true,
            //        RequireUppercase = true,
            //        RequiredLength = 5
            //    });
            //Register(dt);

            //Login(new UserForLoginDto()
            //{
            //    Email = dt.Email,
            //    Password = dt.Password
            //});
            return new DataResult<UserForRegisterDto>(message: Messages.CompanyAdded);
        }

        /// <summary>
        /// Generates a Random Password
        /// respecting the given strength requirements.
        /// </summary>
        /// <param name="opts">A valid PasswordOptions object
        /// containing the password strength requirements.</param>
        /// <returns>A random password</returns>
        public static string GenerateRandomPassword(PasswordOptions opts = null)
        {
            if (opts == null)
                opts = new PasswordOptions()
                {
                    RequiredLength = 8,
                    RequiredUniqueChars = 4,
                    RequireDigit = true,
                    RequireLowercase = true,
                    RequireNonAlphanumeric = true,
                    RequireUppercase = true
                };

            string[] randomChars = new[] {
            "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
            "abcdefghijkmnopqrstuvwxyz",    // lowercase
            "0123456789",                   // digits
            "!@$?_-"                        // non-alphanumeric
        };

            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            if (opts.RequireUppercase)
                chars.Insert(rand.Next(0,chars.Count),
                    randomChars[0][rand.Next(0,randomChars[0].Length)]);

            if (opts.RequireLowercase)
                chars.Insert(rand.Next(0,chars.Count),
                    randomChars[1][rand.Next(0,randomChars[1].Length)]);

            if (opts.RequireDigit)
                chars.Insert(rand.Next(0,chars.Count),
                    randomChars[2][rand.Next(0,randomChars[2].Length)]);

            if (opts.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0,chars.Count),
                    randomChars[3][rand.Next(0,randomChars[3].Length)]);

            for (int i = chars.Count; i < opts.RequiredLength
                || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0,randomChars.Length)];
                chars.Insert(rand.Next(0,chars.Count),
                    rcs[rand.Next(0,rcs.Length)]);
            }

            return new string(chars.ToArray());
        }
        private IResult CheckCompanyTaxNumberExist(string companyTaxNumber)
        {
            // var data = _companyDal.GetCompanyList();
            if (_companyDal.GetList(p => p.TaxNumber.Equals(companyTaxNumber)).Count != 0)
            {
                return new ErrorResult(message: Messages.CompanyTaxNumberExistError);
            }
            return new SuccessResult();
        }


    }
}
