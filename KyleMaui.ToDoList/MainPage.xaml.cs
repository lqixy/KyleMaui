using KyleMaui.ToDoList.ViewModels;

namespace KyleMaui.ToDoList;

public partial class MainPage : ContentPage
{ 
    public MainPage(MainPageItemViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
     
}


