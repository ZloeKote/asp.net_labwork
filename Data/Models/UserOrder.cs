using java.lang;
using LabWork.Data.Interfaces;
using LabWork.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;

namespace LabWork.Data.Models
{
    public class UserOrder
    {       
        public int Id { get; set; }
        public string createdTime { get; set; }
        public double price { get; set; }
        public string Status { get; set; }
        public string customerId { get; set; }
        public string operatorId { get; set; }
        [NotMapped]
        public IEnumerable<UserOrderItem> OrderItemsList { get; set; }

        public UserOrder()
        {

        }

        public UserOrder(string createdTime, double price, string status, string customerId)
        {
            this.createdTime = createdTime;
            this.price = price;
            Status = status;
            this.customerId = customerId;
        }

        public static UserOrder getOrder(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string id = session.GetString("id") ?? Guid.NewGuid().ToString();
            session.SetString("Id", id);
            return new UserOrder() { Id = Int32.Parse(id) };
        }

        public int validateForm(UserOrderCheckoutModel order)
        {
            if (!Regex.IsMatch(order.name, @"^[A-Za-zА-Яа-яґҐЁёІіЇїЄє'’ʼ-]{2,60}$")) return 21; // if customer name doesn't meet the conditions
            if (order.surname != "" && !Regex.IsMatch(order.surname, @"^[A-Za-zА-Яа-яґҐЁёІіЇїЄє'’ʼ-]{2,60}$")) return 22; // if customer surname doesn't meet the conditions
            if (!Regex.IsMatch(order.email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) return 24; // if customer email doesn't meet the conditions
            return 10;
        }
    }
}
