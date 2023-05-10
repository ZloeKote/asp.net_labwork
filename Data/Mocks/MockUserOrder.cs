using LabWork.Data.Interfaces;
using LabWork.Data.Models;
using System.Collections.Generic;

namespace LabWork.Data.Mocks
{
    public class MockUserOrder : IUserOrder
    {
        public IEnumerable<UserOrder> allOrders
        {
            get
            {
                return new List<UserOrder>
                {
                    new UserOrder
                    {
                        Id = 0,
                        createdTime = "2022-12-06 22:10:31",
                        price = 124.5,
                        Status = "Виконано",
                        customerId = "3"
                    },
                    new UserOrder
                    {
                        Id = 1,
                        createdTime = "2022-12-08 10:02:57",
                        price = 371,
                        Status = "Виконано",
                        customerId = "3",
                        operatorId = "2"
                    },
                    new UserOrder
                    {
                        Id = 2,
                        createdTime = "2023-01-03 06:46:51",
                        price = 1011,
                        Status = "Виконано",
                        customerId = "4"
                    }
                };
            }
        }

        public void addOrder(UserOrder order)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UserOrder> OrdersByCustomerId(string customerId)
        {
            return null;
        }

        public IEnumerable<UserOrder> OrdersByOperatorId(string customerId)
        {
            return null;
        }

        public IEnumerable<UserOrder> OrdersByStatus(string status)
        {
            return null;
        }

        public int validateItems(UserOrder order)
        {
            throw new System.NotImplementedException();
        }
    }
}
