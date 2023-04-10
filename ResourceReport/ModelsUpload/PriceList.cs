using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceReport.ModelsUpload
{
    internal class PriceList
    {
        public string Item { get; set; }
        public double Price { get; set; }
        public PriceList(string item, double price)
        {
            Item = item;
            Price = price;
        }
    }
}
