using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.ProductService.Domain;

namespace Shop.ProductService.Application
{
    public class ProductService : IProductService
    {
        public List<Product> GetAll() => new List<Product>()
        {
            new Product()
            {
                Id = Guid.NewGuid(),
                CategoryId = Guid.NewGuid(),
                Name = "Food"
            }
        };
    }
}
