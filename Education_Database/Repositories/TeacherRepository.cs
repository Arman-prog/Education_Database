using Education_Database.Models;

namespace Education_Database.Repositories
{
    public class TeacherRepository : BaseRepository<Teacher>
    {
        protected override string Sqlexpression { get; } = "SELECT * FROM Teacher";

    }
}
