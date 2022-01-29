using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saas.Business.Abstract;
using Saas.Entities.Dto;

namespace Saas.WebCoreApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]


    [ApiVersion("1.0")] //,Deprecated = true
    [ApiVersion("2.0")]
    //[Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController :ControllerBase
    {
        private readonly IAuthService _authService;


        /// <summary>
        /// login-token-kullanıcı işlemleri.
        /// </summary>
        /// <param name="authService"></param>
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// giriş için jwt token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto user)
        {
            var userToLogin = _authService.Login(user);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }


        /// <summary>
        /// firmaya ait kullanıcı oluşturmak için kullanılır, firma ve local ıd dolu gönderilmeli
        /// manager kısmında kullanıcı daha önce mail adresiyle kayıt yapılmış mıdır diye kontrol edilir
        /// </summary>
        /// <param name="CompanyFirstRegisterDto"></param>
        /// <returns></returns>
        //[HttpPost("register")]
        [HttpPost("Register")]
        [MapToApiVersion("2.0")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Register(CompanyFirstRegisterDto userForRegisterDto)
        {
            var userExist = _authService.UserExist(userForRegisterDto.Email);
            if (!userExist.Success)
            {
                return BadRequest(userExist.Message);
            }
            var registerResult = _authService.Register(userForRegisterDto);

            if (registerResult.Success)
            {
                var result = _authService.CreateAccessToken(registerResult.Data);
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                return BadRequest(result.Message);
            }
            //test
            return BadRequest(registerResult.Message);
        }

        /// <summary>
        /// ilk firma kaydı için kullanılır.
        /// companyid ve local id bos olur.kayit işleminden sonra dolar.
        /// </summary>
        /// <param name="userForRegisterDto"></param>
        /// <returns></returns>
        [HttpPost("CompanyFirstRegister")]
        public async Task<IActionResult> CompanyFirstRegister(CompanyFirstRegisterDto userForRegisterDto)
        {
            var registerResult = _authService.RegisterForCompany(userForRegisterDto);
            if (registerResult.Success)
            {
                if (registerResult.Success)
                {
                    return Ok(registerResult);
                }
                return BadRequest(registerResult.Message);
            }
            return BadRequest(registerResult.Message);
        }
    }
}
