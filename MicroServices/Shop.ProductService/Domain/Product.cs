using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ProductService.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
