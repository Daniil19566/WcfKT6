using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Threading;
using WcfKT6;
using System.Runtime.Serialization;
namespace WcfKT6
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        List<Order> GetOrders();
    }

    // Реализация службы
    public class OrderService : IOrderService
    {
        public List<Order> GetOrders()
        {
            // Проверка роли пользователя
            if (!Thread.CurrentPrincipal.IsInRole("Manager"))
                throw new FaultException<SecurityException>(new SecurityException("Access denied. You must be in the Manager role."), "Unauthorized");

            // Логика получения заказов (пример)
            List<Order> orders = new List<Order>
            {
                new Order { Id = 1, Name = "Order 1", Status = "Pending" },
                new Order { Id = 2, Name = "Order 2", Status = "Completed" }
            };

            return orders;
        }
    }

    // Определение класса заказа
    [DataContract]
    public class Order
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Status { get; set; }
    }
}