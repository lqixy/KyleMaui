using System;
namespace KyleMaui.ToDoList.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
    }

    public class CategoryService : ICategoryService
    {
        private readonly CategoryDbContext database;

        public CategoryService(CategoryDbContext database)
        {
            this.database = database;
        }

        public async Task<List<Category>> GetAll()
        {
            return await database.GetAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await database.GetItem(id);
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            await database.Delete(entity);
        }

        public async Task Save(Category item)
        {
            await database.Save(item);
        }
    }
}

