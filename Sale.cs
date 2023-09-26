using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarSalesViewer
{
    public class Sale
    {
        [XmlElement("model")]
        public string CarModel { get; set; }

        [XmlElement("date")]
        public SaleDate Date { get; set; }

        [XmlElement("price")]
        public double Price { get; set;}

        [XmlElement("dph")]
        public double Dph { get; set;}

        public Sale()
        {
            CarModel = "";
            Date = new SaleDate();
            Price = 0;
            Dph = 0;
        }

        public Sale(string carModel, SaleDate date, double price, double dph)
        {
            CarModel = carModel;
            Date = date;
            Price = price;
            Dph = dph;
        }
    }
}
