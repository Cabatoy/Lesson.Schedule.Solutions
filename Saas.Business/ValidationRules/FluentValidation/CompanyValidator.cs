using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constant;
using FluentValidation;
using Saas.Entities.Models;

namespace Business.ValidationRules.FluentValidation
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(p => p.TaxNumber).NotEmpty().WithMessage(Messages.TaxNumberValidationError);
            RuleFor(p => p.TaxNumber).Length(10, 11).WithMessage(Messages.TaxNumberLengtValidationError);
            RuleFor(p => p.Id).GreaterThanOrEqualTo(10).When(p => p.FullName == "");
            RuleFor(p => p.Id).GreaterThanOrEqualTo(10).When(p => p.FullName == "");
            #region örnek kullanımlar commentli
            //RuleFor(p => p.TaxNumber).Must(StarWithWithA); 
            #endregion
        }

        //private static bool StarWithWithA(string arg)
        //{
        //    return arg.StartsWith("A");
        //}
    }
}
