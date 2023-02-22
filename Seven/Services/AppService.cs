using Seven.Data;
using Seven.Models;

namespace Seven.Services
{
    public class AppService
    {
        AppDbContext _Context;

        public AppService(AppDbContext context)    {

            _Context = new AppDbContext();
        }

        public bool Login(LoginData loginData, out int userId)
        {
            userId = 0;
            var currentUser = _Context.logins.FirstOrDefault(x => x.Id == loginData.Id && x.Password == loginData.Password);
            if (currentUser != null)
            {
                userId = currentUser.Id;
                return true;
            }
            return false;
        }
    }
}
