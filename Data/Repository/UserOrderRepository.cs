using com.sun.xml.@internal.bind.v2.model.core;
using java.io;
using LabWork.Data.Interfaces;
using LabWork.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace LabWork.Data.Repository
{
    public class UserOrderRepository : IUserOrder
    {
        private readonly AppDBContent appDBContent;

        public UserOrderRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<UserOrder> allOrders => appDBContent.userOrder;

        public IEnumerable<UserOrder> OrdersByCustomerId(string customerId) {
            return appDBContent.userOrder.Where(p => p.customerId == customerId);
        }

        public IEnumerable<UserOrder> OrdersByOperatorId(string operatorId)
        {
            return appDBContent.userOrder.Where(p => p.operatorId == operatorId);
        }

        public IEnumerable<UserOrder> OrdersByStatus(string status)
        {
            return appDBContent.userOrder.Where(p => p.Status == status);
        }

        public int validateItems(UserOrder order)
        {
            int numKeys = 0;
            int total_price = 0;
            foreach (var item in order.OrderItemsList)
            {
                numKeys = appDBContent.gameKey.Where(p => p.IsActivated == false && p.digitalCopyId == item.item.Id).Count();
                System.Console.WriteLine(item.item.Id + " ordered: " + item.amount + " available: " + numKeys + '\n');
                if (item.amount > numKeys) return 31; // if amount of ordered copies more than available copies on DB
                total_price += item.amount * item.price;
            }
            if (order.price != total_price) return 32; // if final price is different from sum of prices for each ordered copy
            return 10;
        }
        public void addOrder(UserOrder order)
        {
            if (order.OrderItemsList != null)
            {
                UserOrder newOrder = new UserOrder(order.createdTime, order.price, order.Status, order.customerId);
                appDBContent.userOrder.Add(newOrder);
                appDBContent.SaveChanges();
                order.Id = newOrder.Id;

                foreach (var item in order.OrderItemsList)
                {
                    IList<GameKey> keys = appDBContent.gameKey.Where(p => p.IsActivated == false && p.digitalCopyId == item.item.Id).ToList();
                    for (int i = 0; i < item.amount; i++)
                    {
                        keys[i].IsActivated = true;
                        appDBContent.gameKey.Update(keys[i]);
                        appDBContent.orderBasket.Add(new OrderBasket { keyId = keys[i].Id, orderId = order.Id, price = item.price });
                    }
                }
                appDBContent.SaveChanges();
            }
        }
    }
}
