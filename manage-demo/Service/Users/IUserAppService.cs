using manage_demo.Entity;
using manage_demo.utils;

namespace manage_demo.Service.Users
{
    public interface IUserAppService
    {
        // 获取用户列表
        public PagedRequest<UserEntity> GetUsers( int pageNum, int pageSize);

        //通过姓名查询
        public PagedRequest<UserEntity> GetUsersByName(string name, int pageNum, int pageSize);
        // 通过id查询用户信息
        public UserEntity GetUserById(int id);

        // 新增用户
        public int AddUser(UserEntity user);

        // 修改用户
        public int UpdateUser(UserEntity user);

        //删除用户
        public int DeleteUser(int id);
    }
}