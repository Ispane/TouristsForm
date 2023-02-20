using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristsForm
{
    internal class CityData
    {
        public CityData(int id, string name, double price, double transit)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.transit = transit;
        }

        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public double transit { get; set; }


        public override string ToString()
        {
            return $"{id}";
        }
    }
}
