using System.Collections.Generic;
using TelefonRehberiWeb.Data;
using TelefonRehberiWeb.ExtraClasses;
using TelefonRehberiWeb.Models;

namespace TelefonRehberiWeb.Services
{
    public class AccountServiceImp : AccountService
    {
        private List<User> user;
        private List<Rehber> rehber;


        public AccountServiceImp()
        {



            //using (ApplicationDbContext context = new ApplicationDbContext())
            //{
            //    var selected_user = context.Users.FirstOrDefault(a => a.Username == logging_user.Username && a.Password == logging_user.Password);

            //    if (selected_user != null)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}

            //user = new List<User>
            //{
            //    new User
            //    {
            //        Username="zeynep" ,
            //        Password="123",

            //    },
            //     new User
            //    {
            //        Username="nisa",
            //        Password="123"


            //    }
            //};
        }
        public User Login(string username, string password)
        {
            return user.SingleOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
