using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesViewer
{
    public class VatPrice
    {
        public double PriceWithVat { get; set; }
        public double PriceWithoutVat { get; set; }

        public VatPrice()
        {
            PriceWithVat = 0;
            PriceWithoutVat = 0;
        }

        public VatPrice(int priceWithVat, int priceWithoutVat)
        {
            PriceWithVat = priceWithVat;
            PriceWithoutVat = priceWithoutVat;
        }
    }
}
