using KyleMaui.ToDoList.Pages;
using KyleMaui.ToDoList.ViewModels;

namespace KyleMaui.ToDoList;

public partial class MainPage : ContentPage
{
    private MainPageItemViewModel _viewModel;
    public MainPage(MainPageItemViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    

    //void ImageButton_Clicked(System.Object sender, System.EventArgs e)
    //{
    //    var page = new CreateTodoItemBottomSheetPage();

    //    page.ShowHandle = true;

    //    page.Show(Window);
    //}
}


