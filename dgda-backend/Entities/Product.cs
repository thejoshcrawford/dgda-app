using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dgda_backend.Entities
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
    }
}
