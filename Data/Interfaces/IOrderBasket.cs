using LabWork.Data.Models;
using System.Collections.Generic;

namespace LabWork.Data.Interfaces
{
    public interface IOrderBasket
    {
        IEnumerable<OrderBasket> allOrderBaskets { get; }
        IEnumerable<OrderBasket> basketByOrderId(int id);
    }
}
