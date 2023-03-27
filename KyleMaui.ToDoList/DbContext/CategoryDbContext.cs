using System;
using SQLite;

namespace KyleMaui.ToDoList.DbContext
{
    public class CategoryDbContext
    {
        private SQLiteAsyncConnection Connection;
        public CategoryDbContext()
        {
        }

        async Task Init()
        {
            if (Connection is not null) return;

            Connection = new SQLiteAsyncConnection(DbConstants.DatabasePath, DbConstants.Flags);
            var result = Connection.CreateTableAsync<Category>();
        }


        public async Task<List<Category>> GetAsync()
        {
            await Init();
            return await Connection.Table<Category>().ToListAsync();
        }

        public async Task<Category> GetItem(int id)
        {
            await Init();
            return await Connection.Table<Category>()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Save(Category item)
        {
            await Init();
            if (item.Id != 0)
            {
                return await Connection.UpdateAsync(item);
            }

            return await Connection.InsertAsync(item);
        }

        public async Task<int> Delete(Category item)
        {
            await Init();
            return await Connection.DeleteAsync(item);
        }
    }
}

