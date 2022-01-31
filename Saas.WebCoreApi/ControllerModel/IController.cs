using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Saas.Entities.Generic;
using Saas.Entities.Models;

namespace Saas.WebCoreApi.ControllerModel
{
    internal interface IControllerModel

    {

        IActionResult GetList();
        IActionResult GetById(int companyId);
        IActionResult Add(IEntity entity);
        IActionResult Update(IEntity company);
        IActionResult Delete(IEntity company);
        IEntity PrepareForDelete(IEntity entity);

    }
}
