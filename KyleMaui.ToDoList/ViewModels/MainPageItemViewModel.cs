using System;
using CommunityToolkit.Mvvm.Input;
using KyleMaui.ToDoList.Services;
using Newtonsoft.Json;

namespace KyleMaui.ToDoList.ViewModels
{
    public partial class MainPageItemViewModel : ObservableObject
    {
        public ObservableCollection<Category> Categories { get; private set; } = new();

        //public ObservableCollection<TodoItem> TodoItems { get; set; } = new();

        public ObservableCollection<TodoItemGroup> TodoItemGroupeds { get; private set; } = new ObservableCollection<TodoItemGroup>();

        private readonly ITodoItemService todoItemService;
        private readonly ICategoryService categoryService;
        //private int skipCount = 0;

        //public string IconPath { get; set; } = "up.png";

        public MainPageItemViewModel(ITodoItemService service, ICategoryService categoryService)
        {
            Categories = new ObservableCollection<Category>
            {
                new Category(1,"所有")
            };

            this.todoItemService = service;
            this.categoryService = categoryService;


            Task.Run(async () => await LoadData());
        }

        async Task LoadData()
        {
            var todos = await todoItemService.GetAll();

            var groupeds = todos.GroupBy(x => x.DeadlineDescript)
                  .Select(x => new TodoItemGroup(x.Key, x.ToList()));

            TodoItemGroupeds = new ObservableCollection<TodoItemGroup>(groupeds);

            var categories = await categoryService.GetAll();
            foreach (var item in categories)
            {
                Categories.Add(item);
            }
        }


        [RelayCommand]
        async void Mark(TodoItem item)
        {
            //await service.Delete(item.Id);
            item.Marked();
            await todoItemService.Save(item);
        }

        [RelayCommand]
        async void Delete(TodoItem item)
        {
            await todoItemService.Delete(item);
        }

        [RelayCommand]
        async void Reload()
        {
           
        }

        [ObservableProperty]
        Category category;

        [ObservableProperty]
        TodoItem todoItem;
    }
}

