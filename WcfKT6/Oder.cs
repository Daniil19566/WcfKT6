using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;

namespace WcfKT6
{
    public class Oder
    {
        public int OrderId { get; set; }
        public string Customer { get; set; }
        public decimal Total { get; set; }
    }


    // Определение класса для исключения безопасности
    public class SecurityException : Exception
    {
        public SecurityException(string message) : base(message) { }
    }
}