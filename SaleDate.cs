using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarSalesViewer
{
    public class SaleDate
    {
        [XmlElement("day")]
        public int Day;
        [XmlElement("month")]
        public int Month;
        [XmlElement("year")]
        public int Year;
        public SaleDate() { 
            Day = 1; 
            Month = 1;
            Year = 1970;
        }
        public SaleDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }
    }
}
