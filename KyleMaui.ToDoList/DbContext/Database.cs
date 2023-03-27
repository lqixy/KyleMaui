using System;
using System.Linq.Expressions;
using KyleMaui.ToDoList.Models;
using SQLite;

namespace KyleMaui.ToDoList.DbContext
{
    public class Database
    {
        SQLiteAsyncConnection Connection;


        async Task Init()
        {
            if (Connection is not null) return;

            Connection = new SQLiteAsyncConnection(DbConstants.DatabasePath, DbConstants.Flags);
            var result = await Connection.CreateTableAsync<TodoItem>();
        }

        public async Task<List<TodoItem>> GetAsync()
        {
            await Init();
            return await Connection.Table<TodoItem>().ToListAsync();
        }

        public async Task<List<TodoItem>> Get(Expression<Func<TodoItem,bool>> predExpr)
        {
            await Init();
            return await Connection.Table<TodoItem>()
                .Where(predExpr).ToListAsync();
        }

        public async Task<TodoItem> GetItem(int id)
        {
            await Init();
            return await Connection.Table<TodoItem>()
                .FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<int> Save(TodoItem item)
        {
            await Init();
            if(item.Id != 0)
            {
                return await Connection.UpdateAsync(item);
            }

            return await Connection.InsertAsync(item);
        }

        public async Task<int> Delete(TodoItem item)
        {
            await Init();
            return await Connection.DeleteAsync(item);
        }
    }
}

