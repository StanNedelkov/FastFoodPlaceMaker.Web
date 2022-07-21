using AutoMapper;
using AutoMapper.QueryableExtensions;

using FastFood.Data;
using FastFood.Models;
using FastFood.Services.Models;
using FastFood.Services.Models.Categories;
using FastFood.Services.Services;

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace FastFood.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public CategoryService(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;   
        }
        public async Task AddCategory(CreateCategoryDTO dto)
        {
            Category category = this.mapper.Map<Category>(dto);
            var categoryExist = context.Categories
                .FirstOrDefault(x => x.Name == category.Name);
            //add message that category already exist TODO and check if context can be detached after .net upgrade to 6
            if (categoryExist != null)
            {
                return;
            }
            context.Categories.Add(category);
            await context.SaveChangesAsync();
        }

        //Can be configured to async (.ToArrayAsync) with .net 6.
        //Need to change the interface as well.
        public ICollection<ListCategoryDTO> GetAll()
        {
            return this.context
                .Categories
                .ProjectTo<ListCategoryDTO>(this.mapper.ConfigurationProvider)
                .ToArray();
        }
    }
}
