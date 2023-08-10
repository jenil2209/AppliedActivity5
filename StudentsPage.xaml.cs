namespace AppliedActivity5;

public partial class StudentsPage : ContentPage
{
	public StudentsPage()
	{
		InitializeComponent();
        LoadStudents();

    }

    private async void LoadStudents()
    {
        try
        {
            var students = await App.DatabaseContext.GetDatabaseConnection().Table<Student>().ToListAsync();
            StudentsListView.ItemsSource = students;
        }
        catch (Exception ex)
        {
            
            // Handle error
        }
    }
}