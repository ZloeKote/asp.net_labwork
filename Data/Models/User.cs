using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LabWork.Data.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }

        public User()
        {

        }

        public User(string name, string email, string role)
        {
            Name = name;
            Email = email;
            Role = role;
        }

        public User(string name, string surname, string email, string role)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Role = role;
        }
    }
}
