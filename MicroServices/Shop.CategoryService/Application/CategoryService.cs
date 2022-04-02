using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.CategoryService.Domain;

namespace Shop.CategoryService.Application
{
    public class CategoryService : ICategoryService
    {
        List<Category> ICategoryService.GetAll() => new List<Category>()
        {
            new Category(){
                Id = Guid.NewGuid(),
                Name = "Category"
            }
        };
    }
}
