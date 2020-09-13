using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using OrderService.Models; 

namespace OrderService.Helpers
{
    public class OrderParser
    {
        public static void createXml()
        {
            List<Order> list = new List<Order>();
            string path1 = @"D:\Centiro\OrderInformationWebApi\src\OrderService\Resources\OrderFiles\Order1.txt";
            Parse(path1, list);

            string path2 = @"D:\Centiro\OrderInformationWebApi\src\OrderService\Resources\OrderFiles\Order2.txt";
            Parse(path2, list);

            string path3 = @"D:\Centiro\OrderInformationWebApi\src\OrderService\Resources\OrderFiles\Order3.txt";
            Parse(path3, list);

            string path = @"D:\Centiro\OrderInformationWebApi\src\OrderService\Resources\Orders.xml";
            
            SerializeXml(list, path);
        }
        public static void Parse(string path, List<Order> list)
        {
            Order order = null;
            using (StreamReader reader = File.OpenText(path))
            {
                string line = string.Empty;
                List<Item> itemsList = new List<Item>();
                string orderNumber = string.Empty;
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    string[] res = line.Split("|");
                    orderNumber = res[1];
                    ConverToModel(res, itemsList);
                }
                order = new Order()
                {
                    OrderNumber = orderNumber,
                    Items = itemsList
                };
            }
            list.Add(order);
        }

        public static void ConverToModel (string[] value, List<Item> itemsList)
        {
            Item item = new Item() {
                OrderLineNumber = value[2],
                ProductNumber = value[3],
                Quantity = Convert.ToInt32(value[4]),
                Name = value[5],
                Description = value[6],
                Price = Convert.ToDecimal(value[7]),
                ProductGroup = value[8],
                OrderDate = Convert.ToDateTime(value[9]),
                CustomerNumber = value[10],
                CustomerName = value[11],

            };

            itemsList.Add(item);           

        }

        public static bool SerializeXml(List<Order> orderList, string path)
        {
            try
            {
                System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(orderList.GetType());
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    serializer.Serialize(ms, orderList);
                    ms.Position = 0;
                    xmlDoc.Load(ms);
                    xmlDoc.Save(path);
                    return true;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error occurred while serializing");
            }
            return false;

        }

        public static List<Order> DeserializeXml(string path)
        {
            List<Order> list = new List<Order>();
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                
                XmlSerializer serializer = new XmlSerializer(list.GetType());
                
                using (StreamReader reader = new StreamReader(path))
                {
                    list  = (List<Order>)serializer.Deserialize(reader);
                    return list;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while deserializing");
            }

            return list;
        }
    }
}