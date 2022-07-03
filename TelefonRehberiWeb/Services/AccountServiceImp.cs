using TelefonRehberiWeb.Data;
using TelefonRehberiWeb.Models;

namespace TelefonRehberiWeb.Services
{
    public class AccountServiceImp : AccountService
    {
        private List<User> user;
        

        public AccountServiceImp()
        {
            user = new List<User>
            {
                new User
                {
                    Username="zeynep" ,
                    Password="123"

                },
                 new User
                {
                    Username="nisa",
                    Password="123"

                }
            };
        }
        public User Login(string username, string password)
        {
            return user.SingleOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
