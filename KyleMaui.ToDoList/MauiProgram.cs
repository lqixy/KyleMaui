global using System.Collections.ObjectModel;
global using CommunityToolkit.Mvvm.ComponentModel;
global using KyleMaui.ToDoList.Models;
global using KyleMaui.ToDoList.ViewModels;
global using KyleMaui.ToDoList.DbContext;

using Microsoft.Extensions.Logging;
using KyleMaui.ToDoList.Services;
using The49.Maui.BottomSheet;
using KyleMaui.ToDoList.Pages;
using CommunityToolkit.Maui;

namespace KyleMaui.ToDoList;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseBottomSheet()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<MainPageItemViewModel>();
        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddTransient<TodoItemDetailViewModel>();
        builder.Services.AddTransient<TodoItemDetailPage>();

        builder.Services.AddTransient<CalendarDetailPage>();

        builder.Services.AddSingleton<Database>();
        builder.Services.AddSingleton<CategoryDbContext>();
        builder.Services.AddSingleton<ITodoItemService, TodoItemService>();
        builder.Services.AddSingleton<ICategoryService, CategoryService>();

        return builder.Build();
    }
}

