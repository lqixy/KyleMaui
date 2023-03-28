namespace KyleMaui.ToDoList.Pages;

public partial class TodoItemDetailPage : ContentPage
{
    public TodoItemDetailPage(TodoItemDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
