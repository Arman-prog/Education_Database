using Education_Database.Models;

namespace Education_Database.Repositories
{
    class Teacher_UniversityRepository : BaseRepository<Teacher_University>
    {
        protected override string Sqlexpression { get; } = "SELECT * FROM Teacher_University";
    }
}
