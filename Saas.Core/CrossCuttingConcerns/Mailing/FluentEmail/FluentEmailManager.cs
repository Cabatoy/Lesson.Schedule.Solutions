using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentEmail.Core;
using FluentEmail.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Saas.Core.Utilities.IoC;
using Saas.Core.Utilities.Results;

namespace Saas.Core.CrossCuttingConcerns.Mailing.FluentEmail
{
    public class FluentEmailManager :IMailingManager
    {
        public FluentEmailManager() : this(ServiceTool.ServiceProvider.GetService<IMailingManager>())
        {

        }

        private readonly IMailingManager _mailingManager;
        public FluentEmailManager(IMailingManager mailingManager)
        {
            _mailingManager = mailingManager;
        }

        public async Task<IResult> SendSample()
        {
            var email = await Email
                .From("bill.gates@microsoft.com")
                .To("luke.lowrey@example.com","Luke")
                .Subject("Hi Luke!")
                .Body("Fluent email looks great!")
                .SendAsync();
            string error = "";
            email.ErrorMessages.ForEach(x => error += x);
            return email.Successful ? new SuccessResult() : new ErrorResult(error);
        }


    }
}
