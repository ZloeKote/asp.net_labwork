using LabWork.Data.Models;
using System.Collections.Generic;

namespace LabWork.Data.Interfaces
{
    public interface IUserOrder
    {
        IEnumerable<UserOrder> allOrders { get; }
        IEnumerable<UserOrder> OrdersByCustomerId(string customerId);

        IEnumerable<UserOrder> OrdersByOperatorId(string operatorId);
        IEnumerable<UserOrder> OrdersByStatus(string status);
        int validateItems(UserOrder order);
        void addOrder(UserOrder order);
    }
}
