namespace manage_demo.Service.Login
{
    public interface ILoginAppService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        int? Login(string account, string password);
    }
}
