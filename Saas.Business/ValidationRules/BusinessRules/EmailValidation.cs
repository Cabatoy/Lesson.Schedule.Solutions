using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Saas.Business.Constants;
using Saas.Core.Utilities.Results;

namespace Saas.Business.ValidationRules.BusinessRules;

public static class EmailValidation
{
    public static IResult Run(string mail)
    {
        Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-
         9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            RegexOptions.CultureInvariant | RegexOptions.Singleline);
        Console.WriteLine($"The email is {mail}");
        bool isValidEmail = regex.IsMatch(mail);
        if (!isValidEmail)
            return new ErrorResult(message: Messages.MailValidationError);
        return new SuccessResult();
    }
}
