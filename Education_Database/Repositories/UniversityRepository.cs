using Education_Database.Models;

namespace Education_Database.Repositories
{
    public class UniversityRepository : BaseRepository<University>
    {
        protected override string Sqlexpression { get; } = "SELECT * FROM University";

    }
}
