using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constant;
using Core.Utilities.Messages;
using FluentValidation;
using Saas.Entities.Dto;

namespace Business.ValidationRules.FluentValidation
{
    public class AuthValidator : AbstractValidator<UserForRegisterDto>
    {
        public AuthValidator()
        {
            RuleFor(p => p.TaxNumber).NotEmpty().WithMessage(Messages.TaxNumberValidationError);
            RuleFor(p => p.TaxNumber).Length(10, 11).WithMessage(Messages.TaxNumberLengtValidationError);
            RuleFor(p => p.Email).NotEmpty().WithMessage(Messages.EmailCanNotBlank);
        }
    }
}
