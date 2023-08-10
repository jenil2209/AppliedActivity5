using SQLite;

public class DatabaseContext
{
    readonly SQLiteAsyncConnection _database;

    public DatabaseContext(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);

        // Delete existing data
          _database.DropTableAsync<Student>();
          _database.DropTableAsync<Course>();


        _database.CreateTableAsync<Student>().Wait();
        _database.CreateTableAsync<Course>().Wait();
    }

    public SQLiteAsyncConnection GetDatabaseConnection()
    {
        return _database;
    }

    public async Task<List<Student>> GetStudentsAsync()
    {
        return await _database.Table<Student>().ToListAsync();
    }

    public async Task<List<Course>> GetCoursesAsync()
    {
        return await _database.Table<Course>().ToListAsync();
    }

    public async Task InitializeSampleData()
    {
        var students = new List<Student>
        {
            new Student { Name = "Vinay", Age = 25 },
            new Student { Name = "Sahil", Age = 29 },
            new Student { Name = "Roy", Age = 27 }
        };

        var courses = new List<Course>
        {
            new Course { Title = "botany", Instructor = "mr.patel" },
            new Course { Title = "zoology", Instructor = "Prof.Alex" },
            new Course { Title = "bio tech", Instructor = "ms.sanjana" }
        };

        foreach (var student in students)
        {
            await _database.InsertAsync(student);
        }

        foreach (var course in courses)
        {
            await _database.InsertAsync(course);
        }
    }
}
