using Microsoft.AspNetCore.Mvc;
using Saas.Business.Abstract;
using Saas.Entities.Models;

namespace Saas.WebCoreApi.Controllers
{

    [ApiVersion("1.0")] //,Deprecated = true
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class CompanyBranchesController :ControllerBase
    {
        private readonly ICompanyBranchesService _companyBranchesService;

        public CompanyBranchesController(ICompanyBranchesService companyBranchesService)
        {
            _companyBranchesService = companyBranchesService;
        }
        [HttpGet(template: "Add")]
        [MapToApiVersion("1.0")]
        public IActionResult Add(CompanyBranch companybranch)
        {
            var result = _companyBranchesService.Add(companybranch );
            var cacheUpdate = GetList();
            if (result.Success)
                return Ok(result.Success);
            return BadRequest(result.Message);
        }
        [HttpGet(template: "Delete")]
        [MapToApiVersion("1.0")]
        public IActionResult Delete(CompanyBranch companybranch)
        {
           
            var result = _companyBranchesService.Update(PrepareForDelete(companybranch));
            var cacheUpdate = GetList();
            if (result.Success)
                return Ok(result.Success);
            return BadRequest(result.Message);
        }
        [HttpGet(template: "GetById")]
        [MapToApiVersion("1.0")]
        public IActionResult GetById(Int32 companybranchID)
        {
            var result = _companyBranchesService.CompanyBranchById(companybranchID);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }
        [HttpGet(template: "GetList")]
        [MapToApiVersion("1.0")]
        public IActionResult GetList()
        {
            var result = _companyBranchesService.CompanyBranchesList();
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }
        [HttpGet(template: "PrepareForDelete")]
        private CompanyBranch PrepareForDelete(CompanyBranch companybranch)
        {
            companybranch.Deleted = true;

            return companybranch;
        }
        [HttpGet(template: "Update")]
        [MapToApiVersion("1.0")]
        public IActionResult Update(CompanyBranch companybranch)
        {
            var result = _companyBranchesService.Update(companybranch);
            var cacheUpdate = GetList();
            if (result.Success)
                return Ok(result.Success);
            return BadRequest(result.Message);
        }
    }
}
