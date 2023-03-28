using CommunityToolkit.Mvvm.Input;

namespace KyleMaui.ToDoList.Controls;

public partial class CalendarView : StackLayout
{

    #region

    public static readonly BindableProperty SelectedDateProperty = BindableProperty.Create(
        nameof(SelectedDate),
        typeof(DateTime),
        typeof(CalendarView),
        defaultBindingMode: BindingMode.TwoWay,
        defaultValue: DateTime.Now,
        propertyChanged: SelectedDatePropertyChanged
        );

    private static void SelectedDatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var controls = (CalendarView)bindable;
        if(newValue is not null)
        {
            var newDate = (DateTime)newValue;

            if(controls._tempDate.Month == newDate.Month &&
                controls._tempDate.Year == newDate.Year)
            {
                var currentDate = controls.Dates.FirstOrDefault(x => x.Date == newDate.Date);
                if(currentDate is not null)
                {
                    foreach (var item in controls.Dates)
                    {
                        item.IsCurrentDate = false;
                    }
                    currentDate.IsCurrentDate = true;
                }
            }
            else
            {
                controls.BindDates(newDate);
            }

        }
    }

    public DateTime SelectedDate
    {
        get => (DateTime)GetValue(SelectedDateProperty);
        set => SetValue(SelectedDateProperty,value);
    }

    private readonly DateTime today = DateTime.Now.Date;

    public static readonly BindableProperty SelectedDateCommandProperty =
        BindableProperty.Create(
            nameof(SelectedDateCommand),
            typeof(Command),
            declaringType: typeof(CalendarView));

    public Command SelectedDateCommand
    {
        get => (Command)GetValue(SelectedDateCommandProperty);
        set => SetValue(SelectedDateCommandProperty, value);
    }

    #endregion

    public ObservableCollection<CalendarViewModel> Dates { get; set; } =
        new ObservableCollection<CalendarViewModel>();

    public CalendarView()
    {
        InitializeComponent();
        BindDates(DateTime.Now);
    }

    private void BindDates(DateTime date)
    {
        Dates.Clear();
        var daysCount = DateTime.DaysInMonth(date.Year, date.Month);

        for (int day = 1; day <= daysCount; day++)
        {
            Dates.Add(new CalendarViewModel
            {
                Date = new DateTime(date.Year, date.Month,
                day),
                IsCurrentDate = date.Date.Day == day

            });
        }
        var selectedDate = Dates.FirstOrDefault(x => x.Date.Date == date.Date);
        //Dates.FirstOrDefault(x=>x.Date)
        if(Dates.Any(x=>x.Date == today))
        {
            Dates.FirstOrDefault(x => x.Date == today).IsToday = true;
        }
        if(selectedDate is not null)
        {
            selectedDate.IsCurrentDate = true;
            _tempDate = selectedDate.Date;
        }
    }
    public event EventHandler<DateTime> OnDateSelected;
    private DateTime _tempDate;


    public Command NextMonthCommand => new Command(() =>
    {
        _tempDate = _tempDate.AddMonths(1);
        BindDates(_tempDate);
    });

    public Command PreviousMonthCommand => new Command(() =>
    {
        _tempDate = _tempDate.AddMonths(-1);
        BindDates(_tempDate);
    });

    public Command CurrentDateCommand => new Command<CalendarViewModel>((cur) =>
    {
        _tempDate = cur.Date;
        SelectedDate = cur.Date;
        OnDateSelected?.Invoke(null, cur.Date);
        SelectedDateCommand?.Execute(cur.Date);
        //foreach (var item in Dates)
        //{
        //    item.IsCurrentDate = false;
        //}
        //cur.IsCurrentDate = true;
    });
}
