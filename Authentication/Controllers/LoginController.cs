using Authentication.Domain.Dto;
using Authentication.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {
        private readonly SecretService _secret;
        private readonly LoginService _loginService;
        public LoginController(SecretService secret, LoginService loginService)
        {
            this._secret = secret;
            this._loginService = loginService;
        }

        /// <summary>
        /// GetClientLogo
        /// </summary>
        /// <returns></returns>

        [AllowAnonymous]

        [HttpGet(nameof(GetClientLogo))]

        public IActionResult GetClientLogo()
        {
            var result = _loginService.GetClientLogo();

            return Ok(result);
        }

        /// <summary>
        /// RegisterCustomer
        /// </summary>
        /// <returns></returns>

        [AllowAnonymous]

        //[HttpPost(nameof(RegisterCustomer))]

        //public IActionResult RegisterCustomer(RegisterUserDto request)
        //{
        //    var result = _loginService.RegisterCustomer();

        //    return result;
        //}

        /// <summary>
        /// WebLogin
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpGet(nameof(UserLogin))]
        public IActionResult UserLogin([FromQuery] UserLoginDto request)
        {
            var result = _loginService.UserLogin(request);

            return Ok(result);
        }

        /// <summary>
        /// PasswordEncrypt
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>

        [HttpGet(nameof(PasswordEncrypt))]
        public IActionResult PasswordEncrypt(string password)
        {
            return Ok(_secret.EncryptString(password));
        }

        /// <summary>
        /// PasswordDecrypt
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>

        [HttpGet(nameof(PasswordDecrypt))]
        public IActionResult PasswordDecrypt(string password)
        {
            return Ok(_secret.DecryptString(password));
        }

    }
}
