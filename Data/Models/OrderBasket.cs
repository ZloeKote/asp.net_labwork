using System.Collections.Generic;

namespace LabWork.Data.Models
{
    public class OrderBasket
    {
        public int orderId { get; set; }
        public int keyId { get; set; }
        public double price { get; set; }
        //public Dictionary<int, double> keys { get; set; } // 1 item - keyId, 2 item - price
    }
}
