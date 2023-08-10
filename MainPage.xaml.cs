namespace AppliedActivity5;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnListStudentsClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StudentsPage());
    }

    private void OnListCoursesClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CoursesPage());
    }
}

