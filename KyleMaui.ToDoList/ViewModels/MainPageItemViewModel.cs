using System;
namespace KyleMaui.ToDoList.ViewModels
{
    public partial class MainPageItemViewModel : ObservableObject
    {
        private Random random = new Random();
        public ObservableCollection<Category> Categories { get; } = new();

        public ObservableCollection<TodoItem> TodoItems { get; } = new();

        public MainPageItemViewModel()
        {
            Categories = new ObservableCollection<Category>
            {
                new Category(1,"所有"),
                new Category(2,"工作"),
                new Category(3,"个人"),
                new Category(4,"心愿单"),
                new Category(5,"生日"),
            };

            var repeats = Enum.GetValues(typeof(Repeat)) as Repeat[];

            var todos = Enumerable.Range(1, 20)
                .Select(x => new TodoItem
                {
                    Id = x,
                    Content = $"{x}",
                    Deadline = DateTime.Now.AddDays(random.Next(1, 30)),
                    Time = $"{DateTime.Now.AddHours(random.Next(1, 12)):HH:mm}",
                    RemindTime = $"{DateTime.Now.AddHours(random.Next(1, 12)):HH:mm}",
                    EnableRemind = true,
                    Repeat = repeats[random.Next(0, repeats.Length)]
                });
            TodoItems = new ObservableCollection<TodoItem>(todos);

        }


        [ObservableProperty]
        Category category;

        [ObservableProperty]
        TodoItem todoItem;
    }
}

