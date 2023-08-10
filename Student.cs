using SQLite;

public class Student
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

public class Course
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Instructor { get; set; }

    // Additional properties for editing and deleting
    [Ignore]
    public bool IsEditing { get; set; }
    [Ignore]
    public bool IsSelected { get; set; }
}
