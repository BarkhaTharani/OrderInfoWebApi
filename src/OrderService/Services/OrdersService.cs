using OrderService.Helpers;
using OrderService.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrderService.Services
{
    public class OrdersService : IOrdersService
    {
        public List<Order> GetAllOrders()
        {
            string path = @"D:\Centiro\OrderInformationWebApi\src\OrderService\Resources\Orders.xml";
            var orderList = OrderParser.DeserializeXml(path);
            return orderList;
        }

        public Order GetOrder(string orderNumber)
        {
            var list = GetAllOrders();
            var order = list.Where(o => o.OrderNumber == orderNumber).FirstOrDefault();
            return order;
        }

        public bool PostOrder()
        {
            List<Order> list = new List<Order>();
            string path1 = @"D:\Centiro\OrderInformationWebApi\src\OrderService\Resources\OrderFiles\Order1.txt";
            OrderParser.Parse(path1, list);

            string path2 = @"D:\Centiro\OrderInformationWebApi\src\OrderService\Resources\OrderFiles\Order2.txt";
            OrderParser.Parse(path2, list);

            string path3 = @"D:\Centiro\OrderInformationWebApi\src\OrderService\Resources\OrderFiles\Order3.txt";
            OrderParser.Parse(path3, list);

            string path = @"D:\Centiro\OrderInformationWebApi\src\OrderService\Resources\orders.xml";

            var isSerialized = OrderParser.SerializeXml(list, path);

            return isSerialized;
        }

    }
}
