using System;
namespace KyleMaui.ToDoList.ViewModels
{
    [QueryProperty(nameof(KyleMaui.ToDoList.Models.TodoItem),"TodoItem")]
    public partial class TodoItemDetailViewModel: ObservableObject
    {
        public TodoItemDetailViewModel()
        {
        }

        [ObservableProperty]
        TodoItem todoItem;
    }
}

