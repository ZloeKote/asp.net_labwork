using LabWork.Data.Interfaces;
using LabWork.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace LabWork.Data.Repository
{
    public class UserRepository : IUsers
    {
        private readonly AppDBContent appDBContent;
        

        public UserRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
            
        }
        public IEnumerable<User> allUsers => appDBContent.Users;

        public IEnumerable<User> UsersByRole(string role)
        {
            return appDBContent.Users.Where(p => p.Role == role);
        }

        public User UserByEmail(string email)
        {
            return appDBContent.Users.FirstOrDefault(p => p.Email == email);
        }

        public User UserById(string id)
        {
            return appDBContent.Users.FirstOrDefault(p => p.Id == id);
        }
    }
}
