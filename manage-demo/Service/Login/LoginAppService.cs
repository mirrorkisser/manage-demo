using manage_demo.Data;
using manage_demo.Entity;
namespace manage_demo.Service.Login
{
    public class LoginAppService : ILoginAppService
    {
        private DataContext dataContext;

        public LoginAppService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public int? Login(string account, string password)
        {
            var item = dataContext.Users.FirstOrDefault(i => i.Account == account && i.Password == password);
            return item?.Id;
        }
    }
}
