using manage_demo.Data;
using manage_demo.Entity;
using manage_demo.utils;

namespace manage_demo.Service.Users
{
    public class UserAppService : IUserAppService
    {
        private DataContext dataContext;

        public UserAppService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        // 新增用户
        public int AddUser(UserEntity user)
        {

            var entry = dataContext.Users.Add(user);
            dataContext.SaveChanges();
            return 0;
        }

        //删除用户
        public int DeleteUser(int id)
        {
            var entity = dataContext.Users.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                dataContext.Users.Remove(entity);
                dataContext.SaveChanges();
            }
            return 0;
        }


        // 获取用户列表
        public PagedRequest<UserEntity> GetUsers( int pageNum, int pageSize)
        {
            IQueryable<UserEntity> users = null;


                users = dataContext.Users.Where(r => true).OrderBy(r => r.Id);

            int count = users.Count();      
            List<UserEntity> items;
            if (pageSize > 0)
            {
                items = users.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                items = users.ToList();
            }
            return new PagedRequest<UserEntity>()
            {
                count = count,
                items = items
            };
        }

        //通过姓名查询
        public PagedRequest<UserEntity> GetUsersByName(string name, int pageNum, int pageSize)
        {
            IQueryable<UserEntity> users = null;
            if (!string.IsNullOrEmpty(name))
            {
                users = dataContext.Users.Where(r => r.Name.Contains(name)).OrderBy(r => r.Id);
            }
            else
            {
                users = dataContext.Users.Where(r => true).OrderBy(r => r.Id);
            }
            int count = users.Count();
            List<UserEntity> items;
            if (pageSize > 0)
            {
                items = users.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                items = users.ToList();
            }
            return new PagedRequest<UserEntity>()
            {
                count = count,
                items = items
            };
        }


        // 通过id查询用户信息
        public UserEntity GetUserById(int id)
        {

            var entity = dataContext.Users.FirstOrDefault(r => r.Id == id);
            return entity;
        }
         


        // 修改用户
        public int UpdateUser(UserEntity user)
        {
            dataContext.Users.Update(user);
            dataContext.SaveChanges();
            return 0;
        }
    }
}