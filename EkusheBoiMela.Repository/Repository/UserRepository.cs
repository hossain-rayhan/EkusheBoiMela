
using System.Collections.Generic;
using System.Linq;
using EkusheBoiMela.Model;
using EkusheBoiMela.Model.Entity;

namespace EkusheBoiMela.Repository.Repository
{
    public class UserRepository
    {
        private readonly DataContext _db = new DataContext();
        public List<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public bool IsValidUser(User user)
        {
            var userList = GetAll();
            if (Enumerable.Any(userList, user1 => user.Name == user1.Name && user.Password == user1.Password))
            {
                return true;
            }
            return false;
        }

        public User GetUserByMail(string name)
        {
            return _db.Users.FirstOrDefault(u => u.Name == name);
        }
    }
}
