using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saas.Business.Abstract;
using Saas.Entities.Models;

namespace Saas.WebCoreApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
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
        [HttpGet(template: "getall")]
        //[Authorize()]
        //[Authorize(Roles = "Company.List,asdas,asdasda,")]
        public IActionResult GetList()
        {
            var result =  _companyService.GetCompanyList();
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
        [HttpGet(template: "getById/{companyId:int}")]
        // [Route("GetById/{companyId:int}")]
        public IActionResult GetById(int companyId)
        {
            var result =  _companyService.GetCompanyById(companyId);
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

        [HttpPost("add")]
        public IActionResult Add(Company company)
        {
            var result =  _companyService.Add(company);
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
        [HttpPut(template: "update")]
        public IActionResult Update(Company company)
        {
            var result =  _companyService.Update(company);
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
        [HttpPost(template: "delete")]
        //  [Route("Delete")]
        public IActionResult Delete(Company company)
        {

            var result =  _companyService.Update(PrepareForDelete(company));
            var CacheUpdate = GetList();
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }

        private static Company PrepareForDelete(Company company)
        {
            if (company.Deleted)
                return company;
            else
            {
                company.Deleted = true;
            }

            return company;
        }

    }
}
