using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading;
using System.Web;

namespace WcfKT6
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        [FaultContract(typeof(SecurityException))] // Указываем, что метод может возвращать исключение SecurityException
        List<Order> GetOrders();

        [OperationContract]
        [FaultContract(typeof(SecurityException))]
        Order GetOrder(int orderId);
    }

    // Реализация сервиса
    public class OrderService : IOrderService
    {
        public List<Order> GetOrders()
        {
            // Проверяем, входит ли текущий пользователь в роль "Manager"
            if (!Thread.CurrentPrincipal.IsInRole("Manager"))
                throw new FaultException<SecurityException>(new SecurityException("Access denied."), "Unauthorized");

            // Если пользователь имеет роль "Manager", возвращаем список заказов
            return new List<Order>
        {
            new Order { OrderId = 1, Customer = "John Doe", Total = 100 },
            new Order { OrderId = 2, Customer = "Jane Smith", Total = 200 }
        };
        }

        public Order GetOrder(int orderId)
        {
            // Реализация получения конкретного заказа (для простоты всегда возвращаем один и тот же заказ)
            return new Order { OrderId = orderId, Customer = "John Doe", Total = 100 };
        }
    }
}