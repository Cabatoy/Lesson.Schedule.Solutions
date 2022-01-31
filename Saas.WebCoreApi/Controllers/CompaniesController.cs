using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saas.Business.Abstract;
using Saas.Entities.Generic;
using Saas.Entities.Models;
using Saas.WebCoreApi.ControllerModel;

namespace Saas.WebCoreApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>

    [ApiVersion("1.0")] //,Deprecated = true
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class CompaniesController :ControllerBase

    {
        private readonly ICompanyService _companyService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyService"></param>
        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }


        /// <summary>
        /// Get All Companies..
        /// </summary>
        /// <returns></returns>
        [HttpGet(template: "GetList")]
        [MapToApiVersion("1.0")]
        //[Authorize()]
        //[Authorize(Roles = "Company.List,asdas,asdasda,")]
        public IActionResult GetList()
        {
            var result = _companyService.GetCompanyList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpGet(template: "GetById/{companyId:int}")]
        [MapToApiVersion("1.0")]
        // [Route("GetById/{companyId:int}")]
        public IActionResult GetById(int companyId)
        {
            var result = _companyService.GetCompanyById(companyId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }

        /// <summary>
        /// Cache Guncellenir,insert yapilir
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>

        [HttpPost("Add")]
        [MapToApiVersion("1.0")]
        public IActionResult Add(Company company)
        {
            var result = _companyService.Add(company);
            var cacheUpdate = GetList();
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }


        /// <summary>
        /// Cache Guncellenir, Guncelleme icin kullanilir.
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        //[HttpPost(template: "update")]
        [HttpPut(template: "Update")]
        [MapToApiVersion("1.0")]
        public IActionResult Update(Company company)
        {
            var result = _companyService.Update(company);
            var CacheUpdate = GetList();
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }

        /// <summary>
        /// Cache Guncellenir,Silme işlemi ilgili kolona 
        /// update şeklinde olur.
        /// </summary>
        /// <param name="company">firma ID</param>
        /// <returns></returns>
        [HttpPost(template: "Delete")]
        [MapToApiVersion("1.0")]
        //  [Route("Delete")]
        public IActionResult Delete(Company company)
        {

            var result = _companyService.Update(PrepareForDelete(company));
            var CacheUpdate = GetList();
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }
        [HttpGet(template: "PrepareForDelete")]
        private Company PrepareForDelete(Company company)
        {
            if (company.Deleted)
                return company;
            else
            {
                company.Deleted = true;
            }

            return company;
        }

        [HttpGet(template: "GetListAsync")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _companyService.GetCompanyListAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }


    }
}
