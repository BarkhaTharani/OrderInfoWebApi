using OrderService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Services
{
    public interface IOrdersService
    {
        public List<Order> GetAllOrders();
        public Order GetOrder(string orderNumber);

        public bool PostOrder();
    }
}
