using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.ClientXF.Data
{
   public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int UnitsInStock { get; set; }
        public decimal Price { get; set; }
    }
}
