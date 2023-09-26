using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarSalesViewer
{
    [Serializable, XmlRoot("salesTable")]
    public class SalesTable
    {
        [XmlElement("sale")]
        public List<Sale> Sales { get; set; }

        public SalesTable() { 
            Sales = new List<Sale>();
        }

        public Dictionary<string, VatPrice> getVatPriceDictionary(bool vatMode)
        {
            var result = new Dictionary<string, VatPrice>();
            foreach (var item in Sales)
            {
                if (!result.ContainsKey(item.CarModel))
                {
                    result.Add(item.CarModel, new VatPrice());
                }
                if (vatMode)
                {
                    // calculation for when price does not contain VAT
                    result[item.CarModel].PriceWithoutVat += item.Price;
                    result[item.CarModel].PriceWithVat += item.Price * (1 + item.Dph / 100);
                }
                else
                {
                    // calculation for when price does contain VAT
                    result[item.CarModel].PriceWithoutVat += item.Price / (1 + item.Dph / 100);
                    result[item.CarModel].PriceWithVat += item.Price;
                }
                
            }
            return result;
        }
    }
}
