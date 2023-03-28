using KyleMaui.ToDoList.Pages;

namespace KyleMaui.ToDoList;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(TodoItemDetailPage), typeof(TodoItemDetailPage));

        Routing.RegisterRoute(nameof(CalendarDetailPage),
            typeof(CalendarDetailPage));
    }
}

