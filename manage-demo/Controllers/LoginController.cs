using manage_demo.Service.Login;
using Microsoft.AspNetCore.Mvc;

namespace manage_demo.Controllers
{
    /// <summary>
    /// 菜单控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> logger;

        private readonly ILoginAppService loginAppService;

        public LoginController(ILogger<LoginController> logger, ILoginAppService loginAppService)
        {
            this.logger = logger;
            this.loginAppService = loginAppService;
        }


        [HttpGet]
        public int? Login(string account, string password)
        {
            return loginAppService.Login(account, password);
        }
    }
}
