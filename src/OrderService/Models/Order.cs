
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OrderService.Models 
{
    [XmlRoot(ElementName ="Orders")]
    public class Order 
    {
        [XmlElement(ElementName = "OrderNumber")]
        public string OrderNumber { get; set; }

        [XmlElement("Item", Type = typeof(Item))]
        public List<Item> Items { get; set; }
        
    }
}