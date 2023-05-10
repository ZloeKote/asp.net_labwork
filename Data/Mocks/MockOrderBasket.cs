using LabWork.Data.Interfaces;
using LabWork.Data.Models;
using System.Collections.Generic;

namespace LabWork.Data.Mocks
{
    public class MockOrderBasket : IOrderBasket
    {
        public IEnumerable<OrderBasket> allOrderBaskets
        {
            get 
            {
                return getOrderBaskets();
            }
        }

        IEnumerable<OrderBasket> IOrderBasket.basketByOrderId(int id)
        {
            var orderBaskets = getOrderBaskets();
            List<OrderBasket> orderBasket = new List<OrderBasket>();
            foreach(var basket in orderBaskets)
            {
                if (basket.orderId == id) orderBasket.Add(basket);
            }
            return orderBasket;
        }

        private IEnumerable<OrderBasket> getOrderBaskets()
        {
            return new List<OrderBasket>
                {
                    new OrderBasket
                    {
                        orderId = 0,
                        //keys = new Dictionary<int, double> { { 0, 124.5 } }
},
                    new OrderBasket
                    {
                        orderId = 1,
                        //keys = new Dictionary<int, double> { { 1, 59 }, { 3, 312 } }
                    },
                    new OrderBasket
                    {
                        orderId = 2,
                        //keys = new Dictionary<int, double> { { 2, 699 }, { 4, 312 } }
                    }
                };
        }
    }
}
