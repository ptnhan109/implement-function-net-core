using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.CategoryService.Domain;

namespace Shop.CategoryService.Application
{
    public interface ICategoryService
    {
        List<Category> GetAll();
    }
}
