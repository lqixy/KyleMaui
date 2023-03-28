using The49.Maui.BottomSheet;

namespace KyleMaui.ToDoList.Pages;

public partial class CreateTodoItemBottomSheetPage
{
    public CreateTodoItemBottomSheetPage(TodoItemDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
