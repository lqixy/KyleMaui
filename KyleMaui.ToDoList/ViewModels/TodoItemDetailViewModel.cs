using System;
namespace KyleMaui.ToDoList.ViewModels
{
    public partial class TodoItemDetailViewModel: ObservableObject
    {
        public TodoItemDetailViewModel()
        {
        }

        [ObservableProperty]
        TodoItem todoItem;
    }
}

