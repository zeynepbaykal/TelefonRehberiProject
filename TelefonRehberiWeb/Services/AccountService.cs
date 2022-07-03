using TelefonRehberiWeb.Models;

namespace TelefonRehberiWeb.Services
{
    public interface AccountService
    {
        public User Login(string username, string password);
    }
}
