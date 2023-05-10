using LabWork.Data.Models;
using LabWork.Models;
using System.Collections.Generic;

namespace LabWork.Data.Interfaces
{
    public interface IUsers
    {
        IEnumerable<User> allUsers { get; }
        User UserById(string id);
        IEnumerable<User> UsersByRole(string role);
        /*User UserByCredentials(string email, string password);*/
        User UserByEmail(string email);
    }
}
