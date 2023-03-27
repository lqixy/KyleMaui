namespace KyleMaui.Demo;

public partial class MainPage : ContentPage
{
    //int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    //private void OnCounterClicked(object sender, EventArgs e)
    //{
    //    count++;

    //    if (count == 1)
    //        CounterBtn.Text = $"Clicked {count} time";
    //    else
    //        CounterBtn.Text = $"Clicked {count} times";

    //    SemanticScreenReader.Announce(CounterBtn.Text);
    //}

    void ImageButton_Clicked(System.Object sender, System.EventArgs e)
    {
        //Shell.Current.DisplayAlert("test", "imagebutton clicked", "ok");
        var page = new MyBottomSheet();

        page.ShowHandle = true;

        page.Show(Window);
    }
}


