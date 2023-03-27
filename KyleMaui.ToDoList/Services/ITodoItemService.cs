using System;
namespace KyleMaui.ToDoList.Services
{
    public interface ITodoItemService
    {
        //Task<List<TodoItem>> Get(int skipCount, int takeCount = 10);
        Task<List<TodoItem>> GetAll();
        Task Delete(TodoItem item);
        Task<TodoItem> GetById(int id);
        Task Save(TodoItem item);
    }

    public class TodoItemService : ITodoItemService
    {
        //private Random random = new Random();
        //List<TodoItem> items = new List<TodoItem>();

        private readonly Database database;
        public TodoItemService(Database database)
        {
            this.database = database;
            //var repeats = Enum.GetValues(typeof(Repeat)) as Repeat[];

            //items = Enumerable.Range(1, 30)
            //    .Select(x => new TodoItem
            //    {
            //        Id = x,
            //        Content = $"{x}",
            //        Deadline =  DateTime.Now.AddDays(random.Next(-2, 30)),
            //        Time = $"{DateTime.Now.AddHours(random.Next(-4, 12)):HH:mm}",
            //        RemindTime = $"{DateTime.Now.AddHours(random.Next(1, 12)):HH:mm}",
            //        EnableRemind = true,
            //        Repeat = repeats[random.Next(0, repeats.Length)]
            //    }).ToList();
        }

        public async Task Delete(TodoItem item)
        {
            //items.RemoveAll(x => x.Id == id);
            //return Task.CompletedTask;
            await database.Delete(item);
        }

        //public async Task<List<TodoItem>> Get(int skipCount,int takeCount=10)
        //{
        //    //var result =
        //    //    items.OrderBy(x=>x.Deadline).Skip(skipCount).Take(takeCount).ToList();
        //    //return await Task.FromResult<List<TodoItem>>(result);
        //}

        public async Task<List<TodoItem>> GetAll()
        {
            //return await Task.FromResult<List<TodoItem>>(items);
            return await database.GetAsync();
        }

        public async Task<TodoItem> GetById(int id)
        {
            return await database.GetItem(id);
        }

        public async Task Save(TodoItem item)
        {

              await database.Save(item);


        }
    }
}

