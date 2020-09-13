
using System;
using System.Xml.Serialization;

namespace OrderService.Models 
{
    public class Item
    {        
        [XmlElement(ElementName = "OrderLineNumber")]
        public string OrderLineNumber { get; set; }

        [XmlElement(ElementName = "ProductNumber")]
        public string ProductNumber { get; set; }

        [XmlElement(ElementName = "Quantity")]
        public int Quantity { get; set; }

        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "Price")]
        public decimal Price { get; set; }

        [XmlElement(ElementName = "ProductGroup")]
        public string ProductGroup { get; set; }

        [XmlElement(ElementName = "OrderDate")]
        public DateTime OrderDate { get; set; }

        [XmlElement(ElementName = "CustomerName")]
        public string CustomerName { get; set; }

        [XmlElement(ElementName = "CustomerNumber")]
        public string CustomerNumber { get; set; }
        
    }
}