using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentEmail.Core;
using Saas.Core.Utilities.Results;

namespace Saas.Core.CrossCuttingConcerns.Mailing
{
    public interface IMailingManager
    {
        Task<IResult> SendSample();

       // Task<string> Send(Email mail);

    }
}
