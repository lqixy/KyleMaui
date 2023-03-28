using System;
using CommunityToolkit.Mvvm.Input;

namespace KyleMaui.ToDoList.ViewModels
{
    public partial class CalendarViewModel: PropertyChangedViewModel
    {
        public CalendarViewModel()
        {
            
        }


        public DateTime Date { get; set; }

        public string Week
        {
            get
            {

                return Date.ToString("ddd", new System.Globalization.CultureInfo("zh-cn"));
            }
        }

        [ObservableProperty]
        private bool isCurrentDate;

        [ObservableProperty]
        private bool isToday;

        //public bool IsCurrentDate
        //{
        //    get => _isCurrentDate;
        //    set => SetProperty(ref _isCurrentDate, value);
        //}
         
    }
}

