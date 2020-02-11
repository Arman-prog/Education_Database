using Education_Database.Models;

namespace Education_Database.Repositories
{
    public class StudentRepository : BaseRepository<Student>
    {
        protected override string Sqlexpression { get; } = "SELECT * FROM Student";

    }
}
