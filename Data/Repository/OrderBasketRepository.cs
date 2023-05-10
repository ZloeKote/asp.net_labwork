using LabWork.Data.Interfaces;
using LabWork.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace LabWork.Data.Repository
{
    public class OrderBasketRepository : IOrderBasket
    {
        private readonly AppDBContent appDBContent;

        public OrderBasketRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<OrderBasket> allOrderBaskets => appDBContent.orderBasket;

        public IEnumerable<OrderBasket> basketByOrderId(int orderId)
        {
            return appDBContent.orderBasket.Where(p => p.orderId == orderId);
        }
    }
}
