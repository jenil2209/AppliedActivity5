using System.Diagnostics;

namespace AppliedActivity5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoursesPage : ContentPage
    {
        private List<Course> _courses;
        private List<Course> _availableCourses; // List to store available courses for picker


        public CoursesPage()
        {
            InitializeComponent();
            LoadCourses();
        }

        private async void LoadCourses()
        {
            try
            {
                _courses = await App.DatabaseContext.GetDatabaseConnection().Table<Course>().ToListAsync();
                CoursesListView.ItemsSource = _courses;

                // Populate the available courses list
                _availableCourses = _courses.ToList(); // Copy all courses for now
                AvailableCoursesPicker.ItemsSource = _availableCourses;
            }
            catch (Exception ex)
            {
                // Handle error
            }
        }
        private async void AddCourseButton_Clicked(object sender, EventArgs e)
        {
            var selectedCourse = AvailableCoursesPicker.SelectedItem as Course;

            if (selectedCourse != null)
            {
                // Add selectedCourse to _courses list
                _courses.Add(selectedCourse);
                await App.DatabaseContext.GetDatabaseConnection().InsertAsync(selectedCourse);

                // Refresh the UI
                CoursesListView.ItemsSource = null;
                CoursesListView.ItemsSource = _courses;

                // Reset the selected item in the picker
                AvailableCoursesPicker.SelectedItem = null;
            }
        }


        private async void HandleDeleteButtonClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("HandleDeleteButtonClicked");
            var button = sender as Button;
            // Rest of the code...
            if (button != null)
            {
                var course = button.CommandParameter as Course;

                if (course != null)
                {
                    Debug.WriteLine($"Course to be deleted: {course.Title}");

                    // Remove course from the list
                    _courses.Remove(course);

                    // Remove course from the database
                    await App.DatabaseContext.GetDatabaseConnection().DeleteAsync(course);

                    // Refresh the UI by reassigning the ItemsSource
                    CoursesListView.ItemsSource = null;
                    CoursesListView.ItemsSource = _courses;
                }
            }
        }


    }
}