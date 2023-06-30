using manage_demo.Entity;
using manage_demo.Service.Users;
using manage_demo.utils;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace manage_demo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
            
        private readonly IUserAppService userAppService;

        public UserController(ILogger<UserController> logger, IUserAppService userAppService)
        {
            this._logger = logger;
            this.userAppService = userAppService;
        }


        // 获取用户列表
        [HttpGet]
        public PagedRequest<UserEntity> GetUsers( int pageNum, int pageSize)
        {
            return userAppService.GetUsers(pageNum,pageSize);
        }

        //通过姓名查询
        [HttpGet]
        public PagedRequest<UserEntity> GetUsersByName(string name, int pageNum, int pageSize)
        {
            return userAppService.GetUsersByName(name,pageNum,pageSize);
        }
        // 获取用户信息
        [HttpGet]
        public UserEntity GetUserByID(int id)
        {
            return userAppService.GetUserById(id);
        }

        /// 新增用户
        [HttpPost]
        public int AddUser(UserEntity user)
        {
            return userAppService.AddUser(user);
        }

        //修改用户
        [HttpPut]
        public int UpdateUser(UserEntity user)
        {
            return userAppService.UpdateUser(user);
        }

        //删除用户
        [HttpDelete]
        public int DeleteUser(int id)
        {
            return userAppService.DeleteUser(id);
        }
    }
}