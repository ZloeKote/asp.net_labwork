using LabWork.Data.Interfaces;
using LabWork.Data.Models;
using System.Collections.Generic;

namespace LabWork.Data.Mocks
{
    public class MockUsers : IUsers
    {
        public IEnumerable<User> allUsers
        {
            get
            {
                return getUsers();
            }
        }

        public IEnumerable<User> UsersByRole(string role) { return null; }

        public User UserByCredentials(string email, string password) { return null; }

        public User UserByEmail(string email) { return null; }

        User IUsers.UserById(string id)
        {
            var users = getUsers();
            foreach (var user in users)
            {
                if (user.Id == id) return user;
            }
            return null;
        }

        private IEnumerable<User> getUsers()
        {
            return new List<User>
                {
                    new User
                    {
                        Id = "1",
                        Name = "John",
                        Surname = "Smith",
                        Email = "john.smith@gmail.com",
                        Role = "Admin"
                    },
                    new User
                    {
                        Id = "2",
                        Name = "Will",
                        Surname = "Cohn",
                        Email = "will.cohn@gmail.com",
                        Role = "Manager"
                    },
                    new User
                    {
                        Id = "3",
                        Name = "Григорій",
                        Surname = "Сковорода",
                        Email = "grig.sc@gmail.com",
                        Role = "Customer"
                    },
                    new User
                    {
                        Id = "4",
                        Name = "Тарас",
                        Surname = "Шевченко",
                        Email = "taras.sh@gmail.com",
                        Role = "Customer"
                    }
                };
        }

        public string addUser(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
