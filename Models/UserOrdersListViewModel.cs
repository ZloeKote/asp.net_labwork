using LabWork.Data.Models;
using System.Collections.Generic;

namespace LabWork.Models
{
    public class UserOrdersListViewModel
    {
        public User userCustomer { get; set; }
        public User userOperator { get; set; }
        public UserOrder order { get; set; }
        public List<(string, string, double, int)> gamePlatformPrice { get; set; } // 1 item - game name, 2 item - platform name, 3 item - price, 4 item - amount of copies
    }
}
