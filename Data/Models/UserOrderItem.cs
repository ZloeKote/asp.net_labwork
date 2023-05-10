using System.Collections.Generic;

namespace LabWork.Data.Models
{
    public class UserOrderItem
    {
        public DigitalCopy item { get; set; }
        public int amount { get; set; }
        public int price { get; set; }
    }
}
