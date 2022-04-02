using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.ProductService.Domain;

namespace Shop.ProductService.Application
{
    public interface IProductService
    {
        List<Product> GetAll();
    }
}
